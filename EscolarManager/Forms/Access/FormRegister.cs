﻿using EscolarManager.Consts;
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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            this.Text = $"{FormConsts.TextForm} - Cadastro";
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
