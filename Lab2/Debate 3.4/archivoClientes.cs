﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace Debate_3._2
{
    internal class archivoClientes
    {


        public string nombreArchivo = "clientes.csv";


        public void grabar(string codigo, string nombre, string deuda, string limite) 

        
        {
            StreamWriter AD = new StreamWriter(nombreArchivo,true);

            AD.Write(codigo);
            AD.Write(";");
            AD.Write(nombre);

            AD.Write(";");
            AD.Write(deuda);

            AD.Write(";");

            AD.WriteLine(limite);
            AD.Close();
            AD.Dispose();
        }


        public void listar(DataGridView grilla)
        {
            grilla.Rows.Clear();
            string datosLeidos = "";
            string[] vector = new string[4];
            StreamReader AD = new StreamReader(nombreArchivo);

            datosLeidos = AD.ReadLine();

            while (datosLeidos != null)
            {

                vector = datosLeidos.Split(';');

                
                
                grilla.Rows.Add(vector[0], vector[1], vector[2], vector[3]);
                    
                
                datosLeidos = AD.ReadLine();

            }

            AD.Close ();
            AD.Dispose  ();

        }
        public void listarDeudores(DataGridView grilla)
        {
            grilla.Rows.Clear();
            string datosLeidos = "";
            string[] vector = new string[4];
            StreamReader AD = new StreamReader(nombreArchivo);

            datosLeidos = AD.ReadLine();

            while (datosLeidos != null)
            {

                vector = datosLeidos.Split(';');

                if (Convert.ToInt32(vector[2]) > 0)
                {
                    grilla.Rows.Add(vector[0], vector[1], vector[2], vector[3]);

                }
                datosLeidos = AD.ReadLine();

            }

            AD.Close();
            AD.Dispose();

        }


        public int contarClientes()
        {
            string datosLeidos = "";
            int contador = 0;

            StreamReader AD = new StreamReader(nombreArchivo);
            datosLeidos = AD.ReadLine();

            while (datosLeidos != null)
            {
                datosLeidos = AD.ReadLine() ;

                contador++;

            }
            AD.Close () ;
            AD.Dispose () ;
            return contador;

        }

        public int contarClientesDeudores()
        {
            string datosLeidos = "";
            int contador = 0;
            string[] vector = new string[4];


            StreamReader AD = new StreamReader(nombreArchivo);
            datosLeidos = AD.ReadLine();

            while (datosLeidos != null)
            {
                vector = datosLeidos.Split(';');

                if (Convert.ToInt32( vector[2]) > 0)
                {
                    contador++;

                }
                datosLeidos = AD.ReadLine();



            }
            AD.Close();
            AD.Dispose();
            return contador;

        }

        public decimal calcularTotalDeuda()
        {

            decimal total = 0;
            string datosLeidos = "";
            string[] vector = new string[4];
            StreamReader AD = new StreamReader(nombreArchivo);

            datosLeidos = AD.ReadLine();

            while (datosLeidos != null)
            {

                vector = datosLeidos.Split(';');

                total = total + Convert.ToDecimal(vector[2]);


                datosLeidos = AD.ReadLine();

            }
            AD.Close();
            AD.Dispose();
            return total;

          

        }



        public decimal calcularTotalDeudaDeudores()
        {

            decimal total = 0;
            string datosLeidos = "";
            string[] vector = new string[4];
            StreamReader AD = new StreamReader(nombreArchivo);

            datosLeidos = AD.ReadLine();

            while (datosLeidos != null)
            {

                vector = datosLeidos.Split(';');

                if (Convert.ToInt32(vector[2]) > 0)
                {
                    total = total + Convert.ToDecimal(vector[2]);

                }



                datosLeidos = AD.ReadLine();

            }
            AD.Close();
            AD.Dispose();
            return total;



        }

        public decimal calcularPromedio()
        {
            decimal total = 0;
            int contador = 0;
            string datosLeidos = "";
            string[] vector = new string[4];
            StreamReader AD = new StreamReader(nombreArchivo);

            datosLeidos = AD.ReadLine();

            while (datosLeidos != null)
            {

                vector = datosLeidos.Split(';');

                total = total + Convert.ToDecimal(vector[2]);
                contador++;


                datosLeidos = AD.ReadLine();

            }
            AD.Close();
            AD.Dispose();
            return total/contador;

        }
        public decimal calcularPromedioDeudores()
        {
            decimal total = 0;
            int contador = 0;
            string datosLeidos = "";
            string[] vector = new string[4];
            StreamReader AD = new StreamReader(nombreArchivo);

            datosLeidos = AD.ReadLine();

            while (datosLeidos != null)
            {

                vector = datosLeidos.Split(';');

                if (Convert.ToInt32(vector[2]) > 0)
                {
                    total = total + Convert.ToDecimal(vector[2]);
                    contador++;

                }

                


                datosLeidos = AD.ReadLine();

            }
            AD.Close();
            AD.Dispose();
            return total / contador;

        }
        public void generarReporte()
        {
            int contador = 0;
            decimal total = 0;
            
            string datosLeidos = "";
            string[] vector = new string[4];
            StreamWriter Reporte = new StreamWriter("Reporte.csv",false);
            Reporte.WriteLine("Titulo de ejemplo");
            Reporte.WriteLine("");
            Reporte.WriteLine("Codigo;Nombre;Deuda;Limite");



            StreamReader AD = new StreamReader(nombreArchivo, true);
            datosLeidos = AD.ReadLine();

            while (datosLeidos != null)
            {
                vector = datosLeidos.Split(';');
                contador++;
                total = total + Convert.ToDecimal(vector[2]);


                


                Reporte.Write(vector[0]);
                Reporte.Write(";");
                Reporte.Write(vector[1]);
                Reporte.Write(";");

                Reporte.Write(vector[2]);
                Reporte.Write(";");

                Reporte.WriteLine(vector[3]);


                datosLeidos = AD.ReadLine();

            }

            AD.Close();
            AD.Dispose();
            Reporte.WriteLine("");

            Reporte.Write("Total:;;;");
            Reporte.WriteLine(total);
            Reporte.Write("Cantidad:;;;");
            Reporte.WriteLine(contador);
            Reporte.Write("Promedio:;;;");
            Reporte.WriteLine(total / contador);




            Reporte.Close();
            Reporte.Dispose();
        }


    }
}
