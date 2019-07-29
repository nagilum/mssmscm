using System.Windows.Forms;

namespace mssmscm.Forms {
    public partial class fmAddConnection : Form {
        public fmAddConnection() {
            InitializeComponent();
        }

        public string Hostname {
            get { return this.tbHostname.Text.Trim(); }
        }

        public string Database {
            get { return this.tbDatabase.Text.Trim(); }
        }

        public string Username {
            get { return this.tbUsername.Text.Trim(); }
        }

        public string Password {
            get { return this.tbPassword.Text.Trim(); }
        }
    }
}