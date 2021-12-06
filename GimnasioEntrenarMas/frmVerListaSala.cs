using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GimnasioEntrenarMas
{
    public partial class frmVerListaSala : Form
    {
        Logica.Sala objTraerTodo = new Logica.Sala();
        public frmVerListaSala()
        {
            InitializeComponent();
 
            dgwVer.DataSource = objTraerTodo.TraerTodos("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable objRegistro = new DataTable();

            try
            {
                objRegistro = objTraerTodo.BuscarSala(int.Parse(txtBucarClase.Text));
               
                if (txtBucarClase.Text.Equals(""))
                {
                    MessageBox.Show("Debe ingresar ID, para buscar SALA", "Ver SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (objRegistro.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontro la SALA", "Ver SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        txtBucarClase.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Consulta encontrada", "Ver SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        dgwVer.DataSource = objRegistro;
                        txtBucarClase.Text = "";

                    }

                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingreso PALABRAS. ID SE BUSCA POR NUMEROS", "Ver SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
            
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error SOLO NUMEROS SE PUEDE INGRESAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dgwVer.DataSource = objTraerTodo.TraerTodos("");
        }
    }
}
