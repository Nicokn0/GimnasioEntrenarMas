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
    public partial class frmVerListaProfesores : Form
    {

        Logica.Profesor objTraerTodo = new Logica.Profesor();

        public frmVerListaProfesores()
        {
            InitializeComponent();


            //uso metodo traer todo para pasarle la base de datos   
            dgwVer.DataSource = objTraerTodo.TraerTodos("");
            dgwVer.DataSource = objTraerTodo.TraerTodos("");
            dgwVer.Columns[3].HeaderText = "Genero";
            dgwVer.Columns[4].HeaderText = "Teléfono";
            dgwVer.Columns[6].HeaderText = "Teléfono Familiar";
            dgwVer.Columns[7].HeaderText = "Nombre Familiar";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgwVer.DataSource = objTraerTodo.TraerTodos("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable objRegistro = new DataTable();

            dgwVer.DataSource = objTraerTodo.BuscarProfe(int.Parse(txtBucarClase.Text));

            objRegistro = objTraerTodo.BuscarProfe(int.Parse(txtBucarClase.Text));

            if (txtBucarClase.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar ID, para buscar Profesor", "Ver Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (objRegistro.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontro Profesor BUSCADO", "Ver Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                else
                {
                    MessageBox.Show("Consulta encontrada", "Ver Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 
                    dgwVer.DataSource = objRegistro;
                    txtBucarClase.Text = "";
                }

     
            }
           
        }
    }
}
