using System.Windows.Forms;

namespace mssmscm.Forms
{
    partial class fmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.tvConnections = new System.Windows.Forms.TreeView();
            this.cmAdd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btConnect = new System.Windows.Forms.Button();
            this.btSettings = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.ilIcons = new System.Windows.Forms.ImageList(this.components);
            this.cmAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvConnections
            // 
            this.tvConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvConnections.ContextMenuStrip = this.cmAdd;
            this.tvConnections.ImageIndex = 0;
            this.tvConnections.ImageList = this.ilIcons;
            this.tvConnections.Location = new System.Drawing.Point(12, 12);
            this.tvConnections.Name = "tvConnections";
            this.tvConnections.SelectedImageIndex = 0;
            this.tvConnections.Size = new System.Drawing.Size(559, 568);
            this.tvConnections.TabIndex = 0;
            this.tvConnections.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(this.TvConnections_NodeMouseDoubleClick);
            this.tvConnections.KeyUp += new KeyEventHandler(TvConnections_KeyUp);
            // 
            // cmAdd
            // 
            this.cmAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddFolder,
            this.miAddConnection,
            this.miDelete});
            this.cmAdd.Name = "cmAdd";
            this.cmAdd.Size = new System.Drawing.Size(162, 70);
            // 
            // miAddFolder
            // 
            this.miAddFolder.Name = "miAddFolder";
            this.miAddFolder.Size = new System.Drawing.Size(161, 22);
            this.miAddFolder.Text = "Add &Folder";
            this.miAddFolder.Click += new System.EventHandler(this.MiAddFolder_Click);
            // 
            // miAddConnection
            // 
            this.miAddConnection.Name = "miAddConnection";
            this.miAddConnection.Size = new System.Drawing.Size(161, 22);
            this.miAddConnection.Text = "Add &Connection";
            this.miAddConnection.Click += new System.EventHandler(this.MiAddConnection_Click);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(161, 22);
            this.miDelete.Text = "&Delete";
            this.miDelete.Click += new System.EventHandler(this.MiDelete_Click);
            // 
            // btConnect
            // 
            this.btConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btConnect.Location = new System.Drawing.Point(389, 586);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(88, 34);
            this.btConnect.TabIndex = 1;
            this.btConnect.Text = "&Connect";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.BtConnect_Click);
            // 
            // btSettings
            // 
            this.btSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSettings.Location = new System.Drawing.Point(483, 586);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(88, 34);
            this.btSettings.TabIndex = 2;
            this.btSettings.Text = "&Settings";
            this.btSettings.UseVisualStyleBackColor = true;
            this.btSettings.Click += new System.EventHandler(this.BtSettings_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAdd.Location = new System.Drawing.Point(12, 586);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(33, 34);
            this.btAdd.TabIndex = 3;
            this.btAdd.Text = "+";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // ilIcons
            // 
            this.ilIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcons.ImageStream")));
            this.ilIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilIcons.Images.SetKeyName(0, "folder-green.ico");
            this.ilIcons.Images.SetKeyName(1, "sql-runner.ico");
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 632);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btSettings);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.tvConnections);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credential Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FmMain_FormClosing);
            this.Load += new System.EventHandler(this.FmMain_Load);
            this.cmAdd.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvConnections;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btSettings;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.ContextMenuStrip cmAdd;
        private System.Windows.Forms.ToolStripMenuItem miAddFolder;
        private System.Windows.Forms.ToolStripMenuItem miAddConnection;
        private ToolStripMenuItem miDelete;
        private ImageList ilIcons;
    }
}