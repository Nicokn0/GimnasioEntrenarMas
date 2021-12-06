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
    public partial class frmModificarSala : Form
    {
        Logica.Sala objSala = new Logica.Sala(); //Buscar Registros

        Entidades.Sala objProEnt = new Entidades.Sala(); //Confirmar

        public frmModificarSala()
        {
            InitializeComponent();
            TraerSala();
        }


        private void btnBuscar_Click(object sender, EventArgs e) //bUSCAR
        {
            if (txtBuscarId.Text.Equals("") && txtBuscarNombre.Text.Equals(""))
            {
                MessageBox.Show("Ingrese NOMBRE  para buscar SALA", "MODIFICAR SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                MostrarDatos();

            }
        }
    
        private void button3_Click(object sender, EventArgs e) //cONFIRMAR 
        {
            DialogResult btnpregunta = MessageBox.Show("¿Esta seguro de que desea MODIFICAR DISCIPLINA SELECCIONADA?", "Modificar Autor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (btnpregunta == DialogResult.Yes)
            {

                CargarModificaciones();

                MessageBox.Show("¡SALA  MODIFICADA!", "MODIFICAR", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetearControles();

                dgwVer.DataSource = objSala.TraerTodos("");

                btnConfirmar.Enabled = false;
            }
        }
        
        private void button2_Click(object sender, EventArgs e) //Salir
        {
            this.Close();
        }
     

        // METODOS
        public void TraerSala()
        {
            Logica.Sala objTraerTodo = new Logica.Sala();

            //uso metodo traer todo para pasarle la base de datos   
            dgwVer.DataSource = objTraerTodo.TraerTodos("");
        }
       
        public void MostrarDatos()
        {
            DataTable objRegistro = new DataTable();


            if (txtBuscarId.Text.Equals("") && !txtBuscarNombre.Text.Equals(""))  //Busqueda por palabra clave
            {
                objRegistro = objSala.BuscarSala(txtBuscarNombre.Text);

                if (objRegistro.Rows.Count == 0)
                {
                    MessageBox.Show("No se ha encontrado registros", "MODIFICAR SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnConfirmar.Enabled = false;

                }

                if (objRegistro.Rows.Count == 1)
                {
                    MessageBox.Show("Se ha encontrado 1 registro. Debera MODIFICAR SALA. \n CONFIRMAR acción en el boton CONFIRMAR", "Modificar SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnConfirmar.Enabled = true;
                    dgwVer.DataSource = objRegistro;

                    txtModificarxId.Text = objRegistro.Rows[0]["Id"].ToString();
                    txtModificarxNombre.Text = objRegistro.Rows[0]["Nombre"].ToString();
                  
                }

                if (objRegistro.Rows.Count > 1)
                {
                    MessageBox.Show("Se ha encontrado mas de 1 SALA. Debera seleccionar de la lista para poder MODIFICAR SALA", "MODIFICAR SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    HabilitaControles();
                    dgwVer.Enabled = true;
                    dgwVer.DataSource = objRegistro;
                    dgwVer.Visible = true;
                }

            }
            else if (!txtBuscarId.Text.Equals("") && txtBuscarNombre.Text.Equals(""))
            {


                objRegistro = objSala.BuscarSala(int.Parse(txtBuscarId.Text));

                if (objRegistro.Rows.Count == 0)
                {
                    MessageBox.Show("No se ha encontrado registros", "Modificar Sala", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnConfirmar.Enabled = false;
                }

                if (objRegistro.Rows.Count == 1)
                {
                    MessageBox.Show("Se ha encontrado 1 registro. Debera MODIFICAR SALA EN LA LISTA. \n CONFIRMAR acción en el boton CONFIRMAR", "Modificar Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    btnConfirmar.Enabled = true;

                    dgwVer.DataSource = objRegistro;

                    txtModificarxId.Text = objRegistro.Rows[0]["Id"].ToString();
                    txtModificarxNombre.Text = objRegistro.Rows[0]["Nombre"].ToString();

                    HabilitaControles();


                }
            }
            else if (!txtBuscarId.Text.Equals("") && !txtBuscarNombre.Text.Equals(""))
            {
                objRegistro = objSala.BuscarSala(int.Parse(txtBuscarId.Text), txtBuscarNombre.Text);

                if (objRegistro.Rows.Count == 0)
                {

                    MessageBox.Show("No se ha encontrado registros", "Modificar SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnConfirmar.Enabled = false;
                }

                if (objRegistro.Rows.Count == 1)
                {
                    MessageBox.Show("Se ha encontrado 1 registro. Debera MODIFICAR SALA EN LA LISTA. \n CONFIRMAR acción en el boton CONFIRMAR", "Modificar SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    dgwVer.DataSource = objRegistro;
                    txtModificarxId.Text = objRegistro.Rows[0]["Id"].ToString();
                    txtModificarxNombre.Text = objRegistro.Rows[0]["Nombre"].ToString();
                    btnConfirmar.Enabled = true;
             

                    HabilitaControles();
                }

                if (objRegistro.Rows.Count > 1)
                {
                    MessageBox.Show("Se ha encontrado mas de una SALA. Debera seleccionar de la lista para poder modificar SAlA", "Modificar SALA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.Enabled = true;
                    dgwVer.DataSource = objRegistro;
                    dgwVer.Visible = true;
                    btnConfirmar.Enabled = true;
                }


            }

        }

        public void CargarModificaciones ()
        {
            objProEnt.Nombre = txtModificarxNombre.Text;

            objProEnt.Id = int.Parse(txtModificarxId.Text);


            objSala.ModificarSala(objProEnt);
        }
        
        public void DesabilitarControles()
        {
            txtModificarxId.Enabled = false;
            txtModificarxNombre.Enabled = false;
            txtBuscarId.Enabled = false;
            txtBuscarNombre.Enabled = false;
        }

        public void HabilitaControles()
        {
            txtModificarxId.Enabled = true;
            txtModificarxNombre.Enabled = true;
         
        }

        public void ResetearControles()
        {
            txtBuscarNombre.ResetText();
            txtBuscarId.ResetText();
            txtModificarxId.ResetText();
            
            txtModificarxNombre.ResetText();
            
        }

        private void ActualizarInfo(object sender, EventArgs e)
        {
            dgwVer.DataSource = objSala.BuscarSala(txtBuscarNombre.Text);
        }

        //Evento

        private void ClickCell(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwVer.SelectedRows.Count > 0)
            {
                txtModificarxId.Text = dgwVer.CurrentRow.Cells["Id"].Value.ToString();
                txtModificarxNombre.Text = dgwVer.CurrentRow.Cells["Nombre"].Value.ToString();
   

                MessageBox.Show($"Usted va MODIFICAR la SALA seleccionada{txtBuscarNombre.Text}", "Modificar SALA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnConfirmar.Enabled = true;

            }
        }

        private void CeldaClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwVer.SelectedRows.Count > 0)
            {
                txtModificarxId.Text = dgwVer.CurrentRow.Cells["Id"].Value.ToString();
                txtModificarxNombre.Text = dgwVer.CurrentRow.Cells["Nombre"].Value.ToString();


                MessageBox.Show($"Usted va MODIFICAR la SALA seleccionada{txtBuscarNombre.Text}", "Modificar SALA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnConfirmar.Enabled = true;

            }
        }
    }
}
