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
    public partial class frmBorrarDisciplina : Form
    {
        Logica.Disciplina objDisciplina = new Logica.Disciplina(); //Buscar Registros

        public frmBorrarDisciplina()
        {
            InitializeComponent();
            TraerDisciplina();
            btnBorrar.Enabled = false;
        }

        public void TraerDisciplina()
        {
            Logica.Disciplina objTraerTodo = new Logica.Disciplina();
            
            dgwVer.DataSource = objTraerTodo.TraerTodos("");
        }

        private void btnBucar_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnBorrar_Click(object sender, EventArgs e) //Borrar
        {
            DialogResult btnpregunta = MessageBox.Show("¿Esta seguro de que desea BORRAR DISCIPLINA SELECCIONADA?", "Modificar Autor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (btnpregunta == DialogResult.Yes)
            {
               objDisciplina.BorrarDisciplina(int.Parse(txtBuscarId.Text));
               
                MessageBox.Show("¡DISCIPLINA  Eliminada!", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtBuscarId.Text = "";
                txtBuscarNombre.Text = "";

                dgwVer.DataSource = objDisciplina.TraerTodos("");

                btnBorrar.Enabled = false;
            }



            TraerDisciplina();
        }

    

        private void BuscarDisciplina(object sender, EventArgs e) //Evento para actualizar el dgw
        {
            dgwVer.DataSource = objDisciplina.BuscarDisciplina(txtBuscarNombre.Text);

          
        }

        public void MostrarDatos() //METODO PARA ENCONTRAR BUSQUEDA DE RESULTADOS
        {
            DataTable objRegistro = new DataTable();


            if (txtBuscarId.Text.Equals("") && !txtBuscarNombre.Text.Equals(""))  //Busqueda por palabra clave
            {
                objRegistro = objDisciplina.BuscarDisciplina(txtBuscarNombre.Text);

                if (objRegistro.Rows.Count == 0)
                {
                    MessageBox.Show("No se ha encontrado registros", "Borrar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnBorrar.Enabled = false;

                }

                if (objRegistro.Rows.Count == 1)
                {
                    MessageBox.Show("Se ha encontrado 1 registro. Debera confirmar acción en el boton BORRAR", "Borrar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.DataSource = objRegistro;
                    btnBorrar.Enabled = true;
                }

                if (objRegistro.Rows.Count > 1)
                {
                    MessageBox.Show("Se ha encontrado mas de 1 profesor. Debera seleccionar de la lista para poder eliminar Profesor", "Borrar Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 
                    dgwVer.Enabled = true;
                    dgwVer.DataSource = objRegistro;
                    dgwVer.Visible = true;
                }

            }

            //busqueda por id
            else if (!txtBuscarId.Text.Equals("") && txtBuscarNombre.Text.Equals(""))
            {


                objRegistro = objDisciplina.BuscarDisciplina(int.Parse(txtBuscarId.Text));

                if (objRegistro.Rows.Count == 0)
                {
                    MessageBox.Show("No se ha encontrado registros", "Borrar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnBorrar.Enabled = false;
                }

                if (objRegistro.Rows.Count == 1)
                {
                    MessageBox.Show("Se encontro 1 registro. Debera confirmar acción en botón borrar", "Borrar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    dgwVer.DataSource = objRegistro;
                    btnBorrar.Enabled = true;

                    btnBorrar.Enabled = true;
                }
            }
            else if (!txtBuscarId.Text.Equals("") && !txtBuscarNombre.Text.Equals(""))
            {
                objRegistro = objDisciplina.BuscarDisciplina(int.Parse(txtBuscarId.Text), txtBuscarNombre.Text);

                if (objRegistro.Rows.Count == 0)
                {

                    MessageBox.Show("No se ha encontrado registros", "Borrar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnBorrar.Enabled = false;
                }

                if (objRegistro.Rows.Count == 1)
                {
                    MessageBox.Show("Se encontro 1 registro. Debera confirmar acción en botón borrar", "Borrar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.DataSource = objRegistro;
                    btnBorrar.Enabled = true;
                }

                if (objRegistro.Rows.Count > 1)
                {
                    MessageBox.Show("Se ha encontrado mas de una Disciplina. Debera seleccionar de la lista para poder eliminar DISCIPLINA", "Borrar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.Enabled = true;
                    dgwVer.DataSource = objRegistro;
                    dgwVer.Visible = true;
                }


            }

        }

        private void dgwVer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwVer.SelectedRows.Count > 0)
            {
                txtBuscarId.Text = dgwVer.CurrentRow.Cells["Id"].Value.ToString();
                txtBuscarNombre.Text = dgwVer.CurrentRow.Cells["Nombre"].Value.ToString();

                MessageBox.Show($"Usted va eliminar la DISCIPLINA seleccionada Disciplina: {txtBuscarNombre.Text}", "Borrar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnBorrar.Enabled = true;

            }
            else
            {
                    txtBuscarId.Text = dgwVer.CurrentRow.Cells["Id"].Value.ToString();
                    txtBuscarNombre.Text = dgwVer.CurrentRow.Cells["Nombre"].Value.ToString();


                    btnBorrar.Enabled = true;

            }
        }

        private void dgwVer_SelectionChanged(object sender, EventArgs e)
        {
            /*
            if (dgwVer.SelectedRows.Count == 1 )
            {
                txtBuscarId.Text = dgwVer.CurrentRow.Cells["Id"].Value.ToString();
                txtBuscarNombre.Text = dgwVer.CurrentRow.Cells["Nombre"].Value.ToString();

                MessageBox.Show($"Usted va eliminar la DISCIPLINA seleccionada Disciplina: {txtBuscarNombre.Text}", "Borrar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnBorrar.Enabled = true;

            }
            */
        }
    }
}
