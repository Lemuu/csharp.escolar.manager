using EscolarManager.Consts;
using System;
using System.Windows.Forms;
using EscolarManager.Repository.Users;
using EscolarManager.Repository.Services;
using EscolarManager.Models.User;

namespace EscolarManager.Forms
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();
            this.Text = FormConsts.TextForm;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            UserRepository repo = new(StorageServices.DbConnection().Connection);

            User user = new(
                    "lemu",
                    "lemu@email.com",
                    "123456"
                );
            MessageBox.Show(""+user.Id);
            bool result = repo.Insert(user);
            MessageBox.Show("" + user.Id);
            MessageBox.Show("" + result);
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            new FormLogin().ShowDialog();
        }
    }
}
