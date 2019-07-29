using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using mssmscm.Properties;

namespace mssmscm.Forms {
    public partial class fmMain : Form {
        public fmMain() {
            InitializeComponent();
        }

        #region Form Methods

        private void FmMain_FormClosing(object sender, FormClosingEventArgs e) {
            // Save position.
            Settings.Default.MainFormWindowState = (int) this.WindowState;

            if (this.WindowState == FormWindowState.Normal) {
                Settings.Default.MainFormWindowTop = this.Top;
                Settings.Default.MainFormWindowLeft = this.Left;
                Settings.Default.MainFormWindowWidth = this.Width;
                Settings.Default.MainFormWindowHeight = this.Height;
            }

            Settings.Default.Save();
        }

        private void FmMain_Load(object sender, EventArgs e) {
            // Load position.
            var mfwt = Settings.Default.MainFormWindowTop;
            var mfwl = Settings.Default.MainFormWindowLeft;
            var mfww = Settings.Default.MainFormWindowWidth;
            var mfwh = Settings.Default.MainFormWindowHeight;

            if (mfwt != -99 && mfwl != -99) {
                this.Location = new Point(mfwl, mfwt);
            }

            if (mfww > 0 && mfwh > 0) {
                this.Size = new Size(mfww, mfwh);
            }

            this.WindowState = (FormWindowState) Settings.Default.MainFormWindowState;

            // Load config.
            this.ReloadConfig();

            // Set tree view as active control.
            this.tvConnections.Focus();

            // Do we need to popup config?
            if (string.IsNullOrWhiteSpace(Settings.Default.MSSMSExec)) {
                using (var dlg = new fmSettings()) {
                    dlg.ShowDialog(this);
                }
            }
        }

        /// <summary>
        /// Clear nodes and populate with loaded config.
        /// </summary>
        private void ReloadConfig() {
            this.ReloadConfig(null, Config.Load());
        }

        /// <summary>
        /// Add all children as new nodes.
        /// </summary>
        private void ReloadConfig(TreeNode node, List<ConnectionNode> list) {
            if (node == null) {
                this.tvConnections.Nodes.Clear();
            }

            foreach (var item in list.OrderBy(n => n.Name)) {
                var nd = new TreeNode();

                // Setup node.
                switch (item.Type) {
                    case "folder":
                        nd.Text = item.Name;
                        nd.ImageIndex = 0;
                        nd.SelectedImageIndex = 0;
                        nd.Tag = "FOLDER";

                        break;

                    case "connection":
                        nd.Text = item.Name;
                        nd.ImageIndex = 1;
                        nd.SelectedImageIndex = 1;
                        nd.Tag = string.Format(
                            "CNT;Hostname={0};Database={1};Username={2};Password={3}",
                            item.Hostname,
                            item.Database,
                            item.Username,
                            item.Password);

                        break;

                    default:
                        // This shouldn't happen, but yeah..
                        continue;
                }

                // Add children.
                if (item.Children != null && item.Children.Any()) {
                    this.ReloadConfig(nd, item.Children);
                }

                // Add to treeview.
                if (node != null) {
                    node.Nodes.Add(nd);

                    if (Settings.Default.AutoExpandOnLoad) {
                        node.Expand();
                    }
                }
                else {
                    this.tvConnections.Nodes.Add(nd);
                }
            }
        }

        #endregion

        #region Form Control Methods

        private void BtAdd_Click(object sender, EventArgs e) {
            this.cmAdd.Show(
                this,
                this.btAdd.Location,
                ToolStripDropDownDirection.Right);
        }

        private void BtConnect_Click(object sender, EventArgs e) {
            OpenSms(this.tvConnections.SelectedNode);
        }

        private void BtSettings_Click(object sender, EventArgs e) {
            using (var dlg = new fmSettings()) {
                dlg.ShowDialog(this);
            }
        }

        private void MiAddFolder_Click(object sender, EventArgs e) {
            using (var dlg = new fmAddFolder()) {
                dlg.ShowDialog(this);

                if (string.IsNullOrWhiteSpace(dlg.FolderName)) {
                    return;
                }

                var node = new TreeNode(dlg.FolderName) {
                    Tag = "FOLDER"
                };

                if (this.tvConnections.SelectedNode != null) {
                    this.tvConnections.SelectedNode.Nodes.Add(node);

                    if (Settings.Default.AutoExpandOnLoad) {
                        this.tvConnections.SelectedNode.Expand();
                    }
                }
                else {
                    this.tvConnections.Nodes.Add(node);
                }

                // Save and reload config.
                Config.Save(this.tvConnections.Nodes);
                this.ReloadConfig();
            }
        }

        private void MiAddConnection_Click(object sender, EventArgs e) {
            using (var dlg = new fmAddConnection()) {
                if (dlg.ShowDialog(this) == DialogResult.Cancel) {
                    return;
                }

                if (string.IsNullOrWhiteSpace(dlg.Hostname) ||
                    string.IsNullOrWhiteSpace(dlg.Username) ||
                    string.IsNullOrWhiteSpace(dlg.Password)) {

                    MessageBox.Show(
                        "All fields must be filled out.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                var node = new TreeNode {
                    Text = string.Format(
                        "{0}@{1}",
                        dlg.Username,
                        dlg.Hostname),
                    Tag = string.Format(
                        "CNT;Hostname={0};Database={1};Username={2};Password={3}",
                        dlg.Hostname,
                        dlg.Database,
                        dlg.Username,
                        dlg.Password)
                };

                if (this.tvConnections.SelectedNode != null) {
                    this.tvConnections.SelectedNode.Nodes.Add(node);

                    if (Settings.Default.AutoExpandOnLoad) {
                        this.tvConnections.SelectedNode.Expand();
                    }
                }
                else {
                    this.tvConnections.Nodes.Add(node);
                }

                // Save and reload config.
                Config.Save(this.tvConnections.Nodes);
                this.ReloadConfig();
            }
        }

        private void MiDelete_Click(object sender, EventArgs e) {
            if (this.tvConnections.SelectedNode == null) {
                return;
            }

            var retval = MessageBox.Show(
                "Are you sure?",
                "Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (retval == DialogResult.No) {
                return;
            }

            this.tvConnections.SelectedNode.Remove();

            // Save and reload config.
            Config.Save(this.tvConnections.Nodes);
            this.ReloadConfig();
        }

        private void TvConnections_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            OpenSms(e.Node);
        }

        private void TvConnections_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Enter) {
                return;
            }

            OpenSms(this.tvConnections.SelectedNode);
        }

        #endregion

        #region Custom Functions

        private void OpenSms(TreeNode node) {
            if (node == null) {
                return;
            }

            var tag = node.Tag.ToString();

            if (tag == "FOLDER") {
                node.Expand();
            }
            else {
                var sections = tag.Split(';');

                if (sections.Length != 5 &&
                    sections[0] != "CNT") {

                    return;
                }

                var hostname = sections[1].Substring(9);
                var database = sections[2].Substring(9);
                var username = sections[3].Substring(9);
                var password = sections[4].Substring(9);

                if (string.IsNullOrWhiteSpace(Settings.Default.MSSMSExec)) {
                    MessageBox.Show(
                        "You must set the exec path in settings first.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                var args = string.Format(
                    "-S {0} -d {1} -U {2} -p {3}",
                    hostname,
                    database,
                    username,
                    password);

                Process.Start(
                    Settings.Default.MSSMSExec,
                    args);
            }
        }

        #endregion
    }
}