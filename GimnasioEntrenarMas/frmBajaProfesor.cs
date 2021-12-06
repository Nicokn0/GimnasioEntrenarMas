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
    public partial class frmBajaProfesor : Form
    {
        Logica.Profesor objProfe = new Logica.Profesor(); //Buscar Registros
        DataTable dt = new DataTable();

        public frmBajaProfesor()
        {
            InitializeComponent();
            TraerProfesores();
        }

        private void dgwVer_SelectionChanged(object sender, EventArgs e)
        {
            if (dgwVer.SelectedRows.Count == 1)
            {

                btnBorrar.Enabled = true;
            }
            else
            {
                if (dgwVer.SelectedRows.Count > 0)
                {

                    MessageBox.Show($"Acaba seleccionar la fila a Modificar: \n Id: {txtId.Text} \n Apellido: {txtApellido.Text} ", "Modificar Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        public void CargarDatosDgw()
        {
            txtId.Text = dgwVer.CurrentRow.Cells["Id"].Value.ToString();
        
            txtApellido.Text = dgwVer.CurrentRow.Cells["Apellido"].Value.ToString();
     
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text.Equals("") && txtId.Text.Equals(""))
            {
                MessageBox.Show("Ingrese La busqueda por ID o Apellido", "Borrar Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if ((!txtId.Text.Equals("") && txtApellido.Text.Equals("")) || (txtId.Text.Equals("") && !txtApellido.Text.Equals("")))
            {
                MostrarDatos();

            }
        }

        public void TraerProfesores() //Metodo traer
        {
            Logica.Profesor objTraerTodo = new Logica.Profesor();

            //uso metodo traer todo para pasarle la base de datos   
            dgwVer.DataSource = objTraerTodo.TraerTodos("");
            dgwVer.DataSource = objTraerTodo.TraerTodos("");
            dgwVer.Columns[3].HeaderText = "Genero";
            dgwVer.Columns[4].HeaderText = "Teléfono";
            dgwVer.Columns[6].HeaderText = "Teléfono Familiar";
            dgwVer.Columns[7].HeaderText = "Nombre Familiar";
        }
        
        public void MostrarDatos()
        {
 

            //Busqueda por palabra clave
            if (txtId.Text.Equals("") && !txtApellido.Text.Equals(""))
            {
                dt = objProfe.BuscarProfe(txtApellido.Text);

                if (dt.Rows.Count == 0)
                {
                    dgwVer.DataSource = dt;
                    MessageBox.Show("No se ha encontrado registros", "Borrar Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnBorrar.Enabled = false;


                }

                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Se ha encontrado 1 registro. Debera confirmar acción en el boton BORRAR", "Borrar Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.DataSource = dt;
                    btnBorrar.Enabled = true;
                }

                if (dt.Rows.Count > 1)
                {
                    MessageBox.Show("Se ha encontrado mas de 1 profesor. Debera seleccionar de la lista para poder eliminar Profesor", "Borrar Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgwVer.Enabled = true;
                    dgwVer.DataSource = dt;
                    dgwVer.Visible = true;
                }

            }

            //busqueda por id
            else if (!txtId.Text.Equals("") && txtApellido.Text.Equals(""))
            {


                dt = objProfe.BuscarProfe(int.Parse(txtId.Text));

                if (dt.Rows.Count == 0)
                {

                    MessageBox.Show("No se ha encontrado registros", "Borrar Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnBorrar.Enabled = false;
                }

                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Se encontro 1 registro. Debera confirmar acción en botón borrar", "Borrar Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    dgwVer.DataSource = dt;
                    btnBorrar.Enabled = true;

                    btnBorrar.Enabled = true;
                }
            }
            else if (!txtId.Text.Equals("") && !txtApellido.Text.Equals(""))
            {
                dt = objProfe.BuscarProfe(int.Parse(txtId.Text), txtApellido.Text);

                if (dt.Rows.Count == 0)
                {

                    MessageBox.Show("No se ha encontrado registros", "Borrar Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnBorrar.Enabled = false;
                }

                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Se encontro 1 registro. Debera confirmar acción en botón borrar", "Borrar Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.DataSource = dt;
                    btnBorrar.Enabled = true;
                }

                if (dt.Rows.Count > 1)
                {
                    MessageBox.Show("Se ha encontrado mas de 1 profesor. Debera seleccionar de la lista para poder eliminar Profesor", "Borrar Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.Enabled = true;
                    dgwVer.DataSource = dt;
                    dgwVer.Visible = true;
                }
            }

        }
       
        
        private void dgwVer_SelectionChanged_1(object sender, EventArgs e)
        {
         

            if (dgwVer.SelectedRows.Count == 1)
            {
                txtId.Text = dgwVer.CurrentRow.Cells["Id"].Value.ToString();
   
                txtApellido.Text = dgwVer.CurrentRow.Cells["Apellido"].Value.ToString();
                btnBorrar.Enabled = true;
            }
            else
            {
                if (dgwVer.SelectedRows.Count > 0)
                {

                    MessageBox.Show($"Debera seleccionar la fila a Borrar: \n Id: {txtId.Text} \n Apellido: {txtApellido.Text} ", "Modificar Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void txtApellido_TextChanged(object sender, EventArgs e) //Evento desde el txt
        {
            
            dgwVer.DataSource = objProfe.BuscarProfe(txtApellido.Text);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult btnpregunta = MessageBox.Show($"¿Esta seguro de que desea BORRAR los datos del Profesor seleccionado \n Id: {txtId.Text} \n Profesor: {txtApellido.Text} ?", "Borrar Autor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (btnpregunta == DialogResult.Yes)
            {
                if (!txtId.Text.Equals("") && !txtApellido.Text.Equals("") || (!txtId.Text.Equals("")) && (txtApellido.Text.Equals("")))
                {
                    objProfe.BorrarProfesor(int.Parse(txtId.Text));
                }
                else
                {
                    objProfe.BorrarProfesor(txtId.Text, txtApellido.Text);
                }


                MessageBox.Show("¡PROFESOR ELIMINADO!", "Borrar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtApellido.Text = "";
                txtId.Text = "";

                dgwVer.DataSource = objProfe.TraerTodos("");


            }

            TraerProfesores();
        }

        private void dgwVer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarDatosDgw();
        }
    }
}
