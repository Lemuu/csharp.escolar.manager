using EscolarManager.Forms.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscolarManager.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            new FormManagementMain().ShowDialog();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            new FormLogin().ShowDialog();
        }
    }
}
