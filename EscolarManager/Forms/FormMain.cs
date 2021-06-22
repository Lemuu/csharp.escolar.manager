using EscolarManager.Consts;
using System;
using System.Windows.Forms;

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
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            new FormLogin().ShowDialog();
        }
    }
}
