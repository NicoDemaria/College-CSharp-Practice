﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepasoArchivos
{
    public partial class FormAcercaDe : Form
    {
        public FormAcercaDe()
        {
            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
        }

        private void FormAcercaDe_Load(object sender, EventArgs e)
        {
            this.Text = "Acerca de...";
        }
    }
}
