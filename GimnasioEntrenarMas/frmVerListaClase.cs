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
    public partial class frmVerListaClase : Form
    {
        Logica.Clase objTraerTodo = new Logica.Clase();
        public frmVerListaClase()
        {
            InitializeComponent();

            //uso metodo traer todo para pasarle la base de datos   
            dgwVer.DataSource = objTraerTodo.MostrarClase("");
            dgwVer.Columns[1].HeaderText = "Profesor";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable objRegistro = new DataTable();

            dgwVer.DataSource = objTraerTodo.FiltrarClase(int.Parse(txtBucarClase.Text));
            objRegistro = objTraerTodo.FiltrarClase(int.Parse(txtBucarClase.Text));

            if (txtBucarClase.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar ID, para buscar CLASE", "Ver CLASE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (objRegistro.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontro la CLASE", "Ver CLASE", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.DataSource = objTraerTodo.MostrarClase("");
                }
                else
                {
                    MessageBox.Show("Consulta encontrada", "Ver CLASE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBucarClase.Text = "";

                }
            }

        }

        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error SOLO NUMEROS SE PUEDE INGRESAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

    

     
    }
}
