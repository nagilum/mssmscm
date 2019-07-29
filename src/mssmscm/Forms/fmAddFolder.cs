using System.Windows.Forms;

namespace mssmscm.Forms {
    public partial class fmAddFolder : Form {
        public fmAddFolder() {
            InitializeComponent();
        }

        public string FolderName {
            get { return this.tbFolderName.Text; }
        }
    }
}