﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad_Práctica_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            funciones.cargarCombo(comboBoxRubros);

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data data = new data();
            data.ShowDialog();
        }

        private void buttonListar_Click(object sender, EventArgs e)
        {
            funciones funciones = new funciones();

            funciones.cargarGrilla(dataGridView1,comboBoxRubros);


            labelCantidadArticulos.Text = Convert.ToString(funciones.contar(dataGridView1));

            labelTotal.Text = Convert.ToString(funciones.CalcularTotal(dataGridView1, comboBoxRubros));


        }

        private void comboBoxRubros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRubros != null)
            {
                buttonListar.Visible = true;
                buttonExportar.Visible = true;
            }
            
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            funciones.exportarGrilla(dataGridView1, comboBoxRubros);
            MessageBox.Show("Datos exportados correctamente en el archivo: Reporte.csv");
        }
    }
}
