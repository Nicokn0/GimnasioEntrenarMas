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
    public partial class frmModificarProfesor : Form
    {
        Logica.Profesor objProfe = new Logica.Profesor(); //Buscar Registros

        Entidades.Profesor objProEnt = new Entidades.Profesor(); //Confirmar
        DataTable objRegistro = new DataTable();

        private string Sexo = "";

        public frmModificarProfesor()
        {
            InitializeComponent();

            TraerProfesores();

            DeshabilitarControles();
        }

        private void button3_Click(object sender, EventArgs e) //buscar
        {

            if (txtBuscarApellido.Text.Equals("") && txtBuscarId.Text.Equals(""))
            {
                MessageBox.Show("Ingrese NOMBRE o APELLIDO para buscar PROFESOR", "MODIFICAR PROFESOR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TraerProfesores();
            }
            else
            {

                MostrarDatos( txtBuscarApellido.Text);
                
             
            }

        }

        private void button1_Click(object sender, EventArgs e) // confirmar
        {
            DialogResult btnpregunta = MessageBox.Show("¿Esta seguro de que desea modificar los datos del autor?", "Modificar Autor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (btnpregunta == DialogResult.Yes)
            {
                ModificarProfesor();

                MessageBox.Show("¡Profesor Modificado!", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetearValores();

                dgwVer.DataSource = objProfe.TraerTodos("");

                DeshabilitarControles();
            }

        }


        // Metodos
        
        public void CargarDatosDgw()
        {
            txtBuscarId.Text = dgwVer.CurrentRow.Cells["Id"].Value.ToString();
            txtNombre.Text = dgwVer.CurrentRow.Cells["Nombre"].Value.ToString();
            txtApellido.Text = dgwVer.CurrentRow.Cells["Apellido"].Value.ToString();
            string sexo = dgwVer.CurrentRow.Cells["Sexo"].Value.ToString();
           
            if (sexo.Equals("F"))
            {
                rbtF.Checked = true;
            }
            if (sexo.Equals("M"))
            {
                rbtM.Checked = true;
            }
            if (sexo.Equals("O"))
            {
                rbtOtro.Checked = true;
            }
            txtCelular.Text = dgwVer.CurrentRow.Cells["Celular"].Value.ToString();
            txtTelefono.Text = dgwVer.CurrentRow.Cells["Telefono"].Value.ToString();
            txtTelFamiliar.Text = dgwVer.CurrentRow.Cells["TelFamiliar"].Value.ToString();
            txtNombreFam.Text = dgwVer.CurrentRow.Cells["NomFamiliar"].Value.ToString();
        }
        

        //Modificar Profes

        public void ModificarProfesor()
        {
           
            objProEnt.Id = int.Parse(txtBuscarId.Text);
            objProEnt.Nombre = txtNombre.Text;
            objProEnt.Apellido = txtApellido.Text;
            objProEnt.Celular = int.Parse(txtCelular.Text);
            objProEnt.Telefono = int.Parse(txtTelefono.Text);
            objProEnt.TelFamiliar = int.Parse(txtTelFamiliar.Text);
            objProEnt.NomFamiliar = txtNombreFam.Text;

          
            foreach (Control control in this.gbxSexo.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;

                    if (radio.Checked)
                    {
                        Sexo = radio.Text;

                        if (Sexo.Equals("M"))
                        {
                            objProEnt.Sexo = "Masculino";
                        }
                        else if (Sexo.Equals("F"))
                        {
                            objProEnt.Sexo = "Femenino";
                        }
                        else
                        {
                            objProEnt.Sexo = "Otro";
                        }
                    }
                }
            }
           
            objProfe.ModificarProfe(objProEnt);
        }
      
        
        // Metodo traer todos los profesores

        public void TraerProfesores()
        {
            Logica.Profesor objTraerTodo = new Logica.Profesor();

            //uso metodo traer todo para pasarle la base de datos   
            dgwVer.DataSource = objTraerTodo.TraerTodos("");
           
            dgwVer.Columns[3].HeaderText = "Genero";
            dgwVer.Columns[4].HeaderText = "Teléfono";
            dgwVer.Columns[6].HeaderText = "Teléfono Familiar";
            dgwVer.Columns[7].HeaderText = "Nombre Familiar";
        }

        // Metodo para validar datos ingresados

        public string Validar()
        {
            string mensaje = "";
            if (txtNombre.Text.Equals("") || txtNombreFam.Text.Equals(""))
            {
                mensaje += "Ingrese un nombre válido \n";

            }
            if (txtApellido.Text.Equals(""))
            {
                mensaje += "Ingrese un apellido Valido \n";

            }


            if (txtTelefono.Text.Equals("") || txtTelFamiliar.Text.Equals(""))
            {
                mensaje += "Ingrese un Teléfono Valido \n";

            }

            if (txtCelular.Text.Equals(""))
            {
                mensaje += "Ingrese un celular Valido \n";

            }

            if (gbxSexo.Text == "")
            {
                mensaje += "Ingrese una Nacionalidad \n";
            }

            if (rbtM.Text.Equals("") && rbtF.Text.Equals("") && rbtOtro.Text.Equals(""))
            {
                mensaje += "Ingrese una SEXO \n";
            }

            return mensaje;

        }

        //Resetear Valores

        public void ResetearValores()
        {
            txtApellido.ResetText();
            txtNombre.ResetText();
            txtCelular.ResetText();
            txtNombreFam.ResetText();
            txtTelefono.ResetText();
            txtTelFamiliar.ResetText();

            txtBuscarApellido.ResetText();
            txtBuscarId.ResetText();

            rbtM.Checked = default;
            rbtF.Checked = default;
            rbtOtro.Checked = default;
        }

        //Deshabilitar controles
        public void DeshabilitarControles()
        {
            btnCofirmar.Enabled = false;
            txtApellido.Enabled = false;
            txtNombre.Enabled = false;
            txtCelular.Enabled = false;
            txtNombreFam.Enabled = false;
            txtTelefono.Enabled = false;
            txtTelFamiliar.Enabled = false;
            gbxSexo.Enabled = false;
        }

        //Habilitar Controles
        public void HabilitarControles()
        {
            txtApellido.Enabled = true;
            txtNombre.Enabled = true;
            txtCelular.Enabled = true;
            txtNombreFam.Enabled = true;
            txtTelefono.Enabled = true;
            txtTelFamiliar.Enabled = true;
            gbxSexo.Enabled = true;
        }


        public void MostrarDatos( string apellido)
        {
             objRegistro = objProfe.BuscarProfe(apellido);

          
            if (!txtBuscarApellido.Text.Equals("") || txtBuscarId.Text.Equals(""))
            {

                if (objRegistro.Rows.Count == 0)
                {
                    dgwVer.DataSource = objRegistro;

                   
                   dgwVer.Visible = false;

                    MessageBox.Show("No se han encontrado resultados", "MODIFICAR PROFESOR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    ResetearValores();

                    DeshabilitarControles();

                    TraerProfesores();
                    
                }

                else if (objRegistro.Rows.Count == 1)
                {
                    MessageBox.Show("Hay un solo registro, se habilitara los controles para modiicar profesores", "MODIFICAR PROFESOR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.Visible = true;
                    dgwVer.DataSource = objRegistro;

                    CargarDatosDgw();

                  

                    HabilitarControles();
                    btnCofirmar.Enabled = true;
                }

              else   if (objRegistro.Rows.Count > 1)
                {

                    MessageBox.Show("Debera seleccionar PROFESOR", "MODIFICAR PROFESOR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                    dgwVer.Visible = true;
                    dgwVer.DataSource = objProfe.BuscarProfe(apellido); ;
                    
                    dgwVer.Enabled = true;
                    btnCofirmar.Enabled = true;
                }
            }
            else
            {
                if (txtBuscarApellido.Text.Equals("") || !txtBuscarId.Text.Equals(""))
                {
                    DataTable objRegistroB = objProfe.BuscarProfe(int.Parse(txtBuscarId.Text));

                    if (objRegistroB.Rows.Count == 0)
                    {
                        dgwVer.DataSource = objRegistroB;


                        dgwVer.Visible = false;

                        MessageBox.Show("No se han encontrado resultados", "MODIFICAR PROFESOR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        ResetearValores();

                        DeshabilitarControles();

                        TraerProfesores();

                    }

                    else if (objRegistroB.Rows.Count == 1)
                    {
                        MessageBox.Show("Hay un solo registro, se habilitara los controles para modiicar profesores", "MODIFICAR PROFESOR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        dgwVer.Visible = true;
                        dgwVer.DataSource = objRegistroB;

                        txtBuscarId.Text = objRegistroB.Rows[0]["Id"].ToString();
                        txtApellido.Text = objRegistroB.Rows[0]["Apellido"].ToString();
                        txtNombre.Text = objRegistroB.Rows[0]["Nombre"].ToString(); ;
                        txtCelular.Text = objRegistroB.Rows[0]["Celular"].ToString();
                        txtNombreFam.Text = objRegistroB.Rows[0]["NomFamiliar"].ToString();
                        txtTelefono.Text = objRegistroB.Rows[0]["Telefono"].ToString();
                        txtTelFamiliar.Text = objRegistroB.Rows[0]["TelFamiliar"].ToString();
                        gbxSexo.Text = objRegistroB.Rows[0]["Sexo"].ToString();

                     
                        dgwVer.Visible = true;
                        dgwVer.DataSource = objProfe.BuscarProfe(int.Parse(txtBuscarId.Text)); ;

                        dgwVer.Enabled = true;
                        btnCofirmar.Enabled = true;

                        HabilitarControles();
                        btnCofirmar.Enabled = true;
                    }

                    
                }
            }

         
         
        }

        //Evento 
        
        private void ProfesorSeleccionado(object sender, DataGridViewCellEventArgs e) //cellclick
        {

            CargarDatosDgw();
            HabilitarControles();

            MessageBox.Show($"Usted va MODIFICAR la DISCIPLINA seleccionada {txtApellido.Text}", "Modificar Diciplina", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnCofirmar.Enabled = true;

        }
        
        private void SeleProfesor(object sender, EventArgs e)
        {

           CargarDatosDgw();


           HabilitarControles();

           btnCofirmar.Enabled = true;

        }
        

        private void AceptarNumeros(object sender, KeyPressEventArgs e) // Evento key Press
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error SOLO NUMEROS SE PUEDE INGRESAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void IngresoLetras(object sender, KeyPressEventArgs e) // Evento Key Press
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error solo LETRAS SE PUEDE INGRESAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        //Evento KeyDown

        private void IngresoEntApellido(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNombre.Focus();
            }
        } 

        private void IngresoEnterNombre(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gbxSexo.Focus();
            }
        }

        private void IngresoEnterSe(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelefono.Focus();
            }
        }

        private void IngresoEnterTel(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCelular.Focus();
            }
        }

        private void IngresoEnterCelu(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelFamiliar.Focus();
            }
        }

        private void InresoEnterTelFam(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNombreFam.Focus();
            }
        }

        private void IngresoEnterNomFam(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCofirmar.Focus();
            }
        }

        private void IngresoEnNom(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBuscarApellido.Focus();
            }
        }

        private void IngresEnterBuscar(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.Focus();
            }
        }

        private void BuscarApellido(object sender, EventArgs e) //Change
        {
            dgwVer.DataSource = objProfe.BuscarProfe(txtBuscarApellido.Text);
         
        }

       
        private void SoloNum(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error SOLO NUMEROS SE PUEDE INGRESAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgwVer_SelectionChanged(object sender, EventArgs e)
        {
            if (objRegistro.Rows.Count == 1)
            {
                CargarDatosDgw();

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            ResetearValores();
        }

        // FIN Evento KeyDown



    }
}
