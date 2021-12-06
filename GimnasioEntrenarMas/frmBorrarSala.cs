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
    public partial class frmBorrarSala : Form
    {
        Logica.Sala objSala = new Logica.Sala(); //Buscar Registros


        public frmBorrarSala()
        {
            InitializeComponent();
            TraerSala();

            btnBorrar.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e) //Borrar
        {
            DialogResult btnpregunta = MessageBox.Show("¿Esta seguro de que desea BORRAR los datos de la SALA?", "Modificar Autor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (btnpregunta == DialogResult.Yes)
            {
             
                objSala.BorrarSala(int.Parse(txtBuscarId.Text));

                MessageBox.Show("¡Sala Eliminada!", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtBuscarId.Text = "";
                txtBuscarNombre.Text = "";

                dgwVer.DataSource = objSala.TraerTodos("");

                btnBorrar.Enabled = false;
            }


            ResetearValores();
            TraerSala();

        }

        public void MostrarDatos()
        {
            DataTable objRegistro = new DataTable();


            if (txtBuscarId.Text.Equals("") && !txtBuscarNombre.Text.Equals(""))  //Busqueda por palabra clave
            {
                objRegistro = objSala.BuscarSala(txtBuscarNombre.Text);

                if (objRegistro.Rows.Count == 0)
                {
                    MessageBox.Show("No se ha encontrado registros", "Borrar Sala", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnBorrar.Enabled = false;

                }

                if (objRegistro.Rows.Count == 1)
                {
                    MessageBox.Show("Se ha encontrado 1 registro. Debera confirmar acción en el boton BORRAR", "Borrar Sala", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.DataSource = objRegistro;
                    btnBorrar.Enabled = true;
                }

                if (objRegistro.Rows.Count > 1)
                {
                    MessageBox.Show("Se ha encontrado mas de 1 SALA. Debera seleccionar de la lista para poder eliminar Profesor", "Borrar Sala", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgwVer.Enabled = true;
                    dgwVer.DataSource = objRegistro;
                    dgwVer.Visible = true;
                }

            }

            //busqueda por id
            else if (!txtBuscarId.Text.Equals("") && txtBuscarNombre.Text.Equals(""))
            {


                objRegistro = objSala.BuscarSala(int.Parse(txtBuscarId.Text));

                if (objRegistro.Rows.Count == 0)
                {
                    MessageBox.Show("No se ha encontrado registros", "Borrar SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnBorrar.Enabled = false;
                }

                if (objRegistro.Rows.Count == 1)
                {
                    MessageBox.Show("Se encontro 1 registro. Debera confirmar acción en botón borrar", "Borrar SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    dgwVer.DataSource = objRegistro;
                    btnBorrar.Enabled = true;

                    btnBorrar.Enabled = true;
                }
            }
            else if (!txtBuscarId.Text.Equals("") && !txtBuscarNombre.Text.Equals(""))
            {
                objRegistro = objSala.BuscarSala(int.Parse(txtBuscarId.Text), txtBuscarNombre.Text);

                if (objRegistro.Rows.Count == 0)
                {

                    MessageBox.Show("No se ha encontrado registros", "Borrar SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnBorrar.Enabled = false;
                }

                if (objRegistro.Rows.Count == 1)
                {
                    MessageBox.Show("Se encontro 1 registro. Debera confirmar acción en botón borrar", "Borrar SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.DataSource = objRegistro;
                    btnBorrar.Enabled = true;
                }

                if (objRegistro.Rows.Count > 1)
                {
                    MessageBox.Show("Se ha encontrado mas de 1 SALA. Debera seleccionar de la lista para poder eliminar SALA", "Borrar SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.Enabled = true;
                    dgwVer.DataSource = objRegistro;
                    dgwVer.Visible = true;
                }


            }

        }

        private void button1_Click(object sender, EventArgs e) //Buscar
        {
            MostrarDatos();
        }

        public void ResetearValores()
        {
            txtBuscarId.ResetText();
            txtBuscarNombre.ResetText();


        }

        public void TraerSala()
        {
            Logica.Sala objTraerTodo = new Logica.Sala();

            dgwVer.DataSource = objTraerTodo.TraerTodos("");
        }

        private void SeleccionarCelda(object sender, EventArgs e) //Evento
        {
            if (dgwVer.SelectedRows.Count > 0)
            {
                txtBuscarId.Text = dgwVer.CurrentRow.Cells["Id"].Value.ToString();
                txtBuscarNombre.Text = dgwVer.CurrentRow.Cells["Nombre"].Value.ToString();

                MessageBox.Show($"Usted va eliminar la SALA seleccionada ID: {txtBuscarId.Text} \n Sala: {txtBuscarNombre.Text}", "Borrar Sala", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnBorrar.Enabled = true;

            }


        }

        private void BuscarNombre(object sender, EventArgs e)
        {
            dgwVer.DataSource = objSala.BuscarSala(txtBuscarNombre.Text);
        }

        private void CeldaClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwVer.SelectedRows.Count > 0)
            {
                txtBuscarId.Text = dgwVer.CurrentRow.Cells["Id"].Value.ToString();
                txtBuscarNombre.Text = dgwVer.CurrentRow.Cells["Nombre"].Value.ToString();

                MessageBox.Show($"Acaba de seleccionar la SALA a ELIMINAR: \n  ID: {txtBuscarId.Text} \n Sala: {txtBuscarNombre.Text} ", "Borrar Sala", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }


            btnBorrar.Enabled = true;
        }
    }

}