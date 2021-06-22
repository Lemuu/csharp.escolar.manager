using EscolarManager.Consts;
using EscolarManager.Forms.Management;
using System;
using System.Windows.Forms;

namespace EscolarManager.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.Text = $"{FormConsts.TextForm} - Login";
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            this.Close();
            new FormManagementMain().Show();
        }
    }
}
