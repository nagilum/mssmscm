using System;
using System.Windows.Forms;
using mssmscm.Properties;

namespace mssmscm.Forms {
    public partial class fmSettings : Form {
        public fmSettings() {
            InitializeComponent();
        }

        private void FmSettings_Load(object sender, EventArgs e) {
            this.tbExec.Text = Settings.Default.MSSMSExec;
            this.cbAutoExpand.Checked = Settings.Default.AutoExpandOnLoad;
        }

        private void BtSave_Click(object sender, EventArgs e) {
            Settings.Default.MSSMSExec = this.tbExec.Text.Trim();
            Settings.Default.AutoExpandOnLoad = this.cbAutoExpand.Checked;
            Settings.Default.Save();
        }

        private void BtBrowse_Click(object sender, EventArgs e) {
            using (var dlg = new OpenFileDialog()) {
                dlg.CheckFileExists = true;
                dlg.Multiselect = false;
                dlg.Filter = "Ssms.exe|Ssms.exe|All files|*.*";
                dlg.FileName = this.tbExec.Text;

                dlg.ShowDialog(this);

                this.tbExec.Text = dlg.FileName;
            }
        }
    }
}