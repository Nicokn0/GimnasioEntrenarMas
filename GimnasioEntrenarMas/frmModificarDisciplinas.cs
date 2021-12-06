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
    public partial class frmModificarDisciplinas : Form
    {
        Logica.Disciplina objDisciplina = new Logica.Disciplina(); //Buscar Registros

        Entidades.Disciplina objProEnt = new Entidades.Disciplina(); //Confirmar
        DataTable objRegistro = new DataTable();

        public frmModificarDisciplinas()
        {
            InitializeComponent();
            TraerDisciplina();
        }
       
        private void btnBuscar_Click(object sender, EventArgs e) //Buscar
        {
            if (txtBuscarId.Text.Equals("") && txtBuscarNombre.Text.Equals(""))
            {
                MessageBox.Show("Ingrese NOMBRE o APELLIDO para buscar DISCIPLINA", "MODIFICAR DISCIPLINA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                MostrarDatos();

            }

        }



        private void btnConfirmar_Click(object sender, EventArgs e) //Confirmar
        {
            DialogResult btnpregunta = MessageBox.Show("¿Esta seguro de que desea MODIFICAR DISCIPLINA SELECCIONADA?", "Modificar Autor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (btnpregunta == DialogResult.Yes)
            {

                objProEnt.Nombre = txtNomMod.Text;
                objProEnt.Descripcion = txtDescriMod.Text;
                objProEnt.Id = int.Parse(txtModificarId.Text);


                objDisciplina.ModificarDisciplina(objProEnt);

                MessageBox.Show("¡DISCIPLINA  MODIFICADA!", "MODIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetearControles();
                DesabilitarControles();

                dgwVer.DataSource = objDisciplina.TraerTodos("");

               
            }
        }
      
        private void button2_Click(object sender, EventArgs e) //Salir
        {
            this.Close();
        }

        //Metodos

        public void TraerDisciplina()
        {
            Logica.Disciplina objTraerTodo = new Logica.Disciplina();

            dgwVer.DataSource = objTraerTodo.TraerTodos("");

            dgwVer.Enabled = true;

            DesabilitarControles();
        }
      
        public void MostrarDatos()
        {
         
            if (txtBuscarId.Text.Equals("") && !txtBuscarNombre.Text.Equals(""))  //Busqueda por palabra clave
            {
                objRegistro = objDisciplina.BuscarDisciplina(txtBuscarNombre.Text);

                if (objRegistro.Rows.Count == 0)
                {
                    MessageBox.Show("No se ha encontrado registros", "MODIFICAR Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnConfirmar.Enabled = false;

                }

                if (objRegistro.Rows.Count == 1)
                {
                    MessageBox.Show("Se ha encontrado 1 registro. Debera MODIFICAR DISICPLINA EN LA LISTA. \n CONFIRMAR acción en el boton CONFIRMAR", "Borrar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.DataSource = objRegistro;

                    txtModificarId.Text = objRegistro.Rows[0]["Id"].ToString();
                    txtNomMod.Text = objRegistro.Rows[0]["Nombre"].ToString();
                    txtDescriMod.Text = objRegistro.Rows[0]["Descripcion"].ToString();
                    HabilitaControles();
                }

                if (objRegistro.Rows.Count > 1)
                {
                    MessageBox.Show("Se ha encontrado mas de 1 DISCIPLINA. Debera seleccionar de la lista para poder MODIFICAR DISCIPLINA", "MODIFICAR DISCIPLINA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    HabilitaControles();
                    dgwVer.Enabled = true;
                    dgwVer.DataSource = objRegistro;
                    dgwVer.Visible = true;
                }

            }
            else if (!txtBuscarId.Text.Equals("") && txtBuscarNombre.Text.Equals(""))
            {


                objRegistro = objDisciplina.BuscarDisciplina(int.Parse(txtBuscarId.Text));

                if (objRegistro.Rows.Count == 0)
                {
                    MessageBox.Show("No se ha encontrado registros", "Modificar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnConfirmar.Enabled = false;
                }

                if (objRegistro.Rows.Count == 1)
                {
                    MessageBox.Show("Se ha encontrado 1 registro. Debera MODIFICAR DISICPLINA EN LA LISTA. \n CONFIRMAR acción en el boton CONFIRMAR", "Modificar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);



                    dgwVer.DataSource = objRegistro;

                    txtModificarId.Text = objRegistro.Rows[0]["Id"].ToString();
                    txtNomMod.Text = objRegistro.Rows[0]["Nombre"].ToString();
                    txtDescriMod.Text = objRegistro.Rows[0]["Descripcion"].ToString();

                    HabilitaControles();

              
                }
            }
            else if (!txtBuscarId.Text.Equals("") && !txtBuscarNombre.Text.Equals(""))
            {
                objRegistro = objDisciplina.BuscarDisciplina(int.Parse(txtBuscarId.Text), txtBuscarNombre.Text);

                if (objRegistro.Rows.Count == 0)
                {

                    MessageBox.Show("No se ha encontrado registros", "Borrar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnConfirmar.Enabled = false;
                }

                if (objRegistro.Rows.Count == 1)
                {
                    MessageBox.Show("Se ha encontrado 1 registro. Debera MODIFICAR DISICPLINA EN LA LISTA. \n CONFIRMAR acción en el boton CONFIRMAR", "Modificar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    dgwVer.DataSource = objRegistro;

                    txtModificarId.Text = objRegistro.Rows[0]["Id"].ToString();
                    txtNomMod.Text = objRegistro.Rows[0]["Nombre"].ToString();
                    txtDescriMod.Text = objRegistro.Rows[0]["Descripcion"].ToString();

                    HabilitaControles();
                }

                if (objRegistro.Rows.Count > 1)
                {
                    MessageBox.Show("Se ha encontrado mas de una Disciplina. Debera seleccionar de la lista para poder eliminar DISCIPLINA", "Modificar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.Enabled = true;
                    dgwVer.DataSource = objRegistro;
                    dgwVer.Visible = true;
                }


            }

        }

        public void DesabilitarControles()
        {
            txtNomMod.Enabled = false;
            txtDescriMod.Enabled = false;
            txtModificarId.Enabled = false;
            btnConfirmar.Enabled = false;
        }

        public void HabilitaControles()
        {
            txtNomMod.Enabled = true;
            txtDescriMod.Enabled = true;
            txtModificarId.Enabled = true;
            btnConfirmar.Enabled = true;
        }

        public void ResetearControles()
        {
            txtBuscarNombre.ResetText();
            txtBuscarId.ResetText();
            txtNomMod.ResetText();
            txtDescriMod.ResetText();
            txtModificarId.ResetText();
            txtModificarId.Text = "";
            txtNomMod.Text = "";

        }

        // Eventos

        private void ActualizarLista(object sender, EventArgs e)
        {
            dgwVer.DataSource = objDisciplina.BuscarDisciplina(txtBuscarNombre.Text);
        }

        // EVENTOS BUSQUEDA 

        private void txtBuscarId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error SOLO NUMEROS SE PUEDE INGRESAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void txtBuscarId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBuscarNombre.Focus();
                

            }
        }

        private void txtBuscarNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                btnBuscar.Focus();

            }
        }
        //Eventos

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if ( objRegistro.Rows.Count == 1)
            {
                txtModificarId.Text = dgwVer.CurrentRow.Cells["Id"].Value.ToString();
                txtNomMod.Text = dgwVer.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescriMod.Text = dgwVer.CurrentRow.Cells["Descripcion"].Value.ToString();

                btnConfirmar.Enabled = true;

            }
          
        }

        private void dgwVer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtModificarId.Text = dgwVer.CurrentRow.Cells["Id"].Value.ToString();
            txtNomMod.Text = dgwVer.CurrentRow.Cells["Nombre"].Value.ToString();
            txtDescriMod.Text = dgwVer.CurrentRow.Cells["Descripcion"].Value.ToString();

            MessageBox.Show($"Usted va MODIFICAR la DISCIPLINA seleccionada{txtBuscarNombre.Text}", "Modificar Diciplina", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnConfirmar.Enabled = true;
        }
        // Fin de eventos

        private void btnSalir_Click(object sender, EventArgs e)
        {
            txtModificarId.ResetText();
            txtModificarId.Text = "";
            txtDescriMod.ResetText();
            txtNomMod.Text = "";
        }
    }
}
