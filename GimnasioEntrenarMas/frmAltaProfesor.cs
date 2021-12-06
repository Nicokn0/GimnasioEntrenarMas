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
    public partial class frmAltaProfesor : Form
    {

        Entidades.Profesor objEntidadProfesor = new Entidades.Profesor(); // instancio
        private string Sexo = "";

        Logica.Profesor objLogicaProfe = new Logica.Profesor();

        public frmAltaProfesor()
        {
            InitializeComponent();
            TraerProfesores();
        }

        private void button1_Click(object sender, EventArgs e) //Confirmar
        {
            BorrarMensajeError();

            if (this.Validar().Equals(""))
            {
                CargarValoresProfesores();

                MessageBox.Show(" Profesor agregado a la lista con EXITO !!!", "AGREGAR AUTOR", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                ResetearValores();

                TraerProfesores();
            }
            else
            {
                MessageBox.Show(Validar(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void button2_Click(object sender, EventArgs e) // cerrar
        {
            ResetearValores();
        }
       
        // Metodos

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
            
            dgwVer.Enabled = true;
        }

        // Metodo para validar datos ingresados

        public string Validar()
        {
            string mensaje = "";
            if (txtNombre.Text.Equals("") || txtNombreFam.Text.Equals(""))
            {
                mensaje += "Ingrese un nombre válido \n";
                errorProvider1.SetError(txtNombre, mensaje);

            }
            if (txtApellido.Text.Equals(""))
            {
                mensaje += "Ingrese un apellido Valido \n";
                errorProvider1.SetError(txtApellido, mensaje);

            }
            if (txtNombreFam.Text.Equals(""))
            {
                mensaje += "Ingrese un nombre de FAMILIAR \n";
                errorProvider1.SetError(txtNombreFam, mensaje);

            }

            if (txtTelefono.Text.Equals("") )
            {
                mensaje += "Ingrese un Teléfono Valido \n";
                errorProvider1.SetError(txtTelefono, mensaje);

            }

            if (txtCelular.Text.Equals("") )
            {
                mensaje += "Ingrese un celular Valido \n";
                errorProvider1.SetError(txtCelular, mensaje);

            }
            if (txtTelFamiliar.Text.Equals(""))
            {
                mensaje += "Ingrese un TEL FAMILIAR  Valido \n";
                errorProvider1.SetError(txtTelFamiliar, mensaje);

            }

            foreach (Control control in this.gbxSexo.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;

                    if (radio.Checked)
                    {
                        objEntidadProfesor.Sexo = radio.Text;
                        if (radio.Text.Equals(""))
                        {
                            mensaje += "Ingrese sexo Correspondiente";

                            
                        }
                      
                    }
                }
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
            radioButton2.Checked = default;
            radioButton3.Checked = default;
            radioButton4.Checked = default;
        
        }

        //Cargar datos Profesor
        public void CargarValoresProfesores()
        {
            objEntidadProfesor.Apellido = txtApellido.Text;
            objEntidadProfesor.Nombre = txtNombre.Text;
            objEntidadProfesor.Telefono = int.Parse(txtTelefono.Text);
            objEntidadProfesor.Celular = int.Parse(txtCelular.Text);
            objEntidadProfesor.TelFamiliar = int.Parse(txtTelFamiliar.Text);
            objEntidadProfesor.NomFamiliar = txtNombreFam.Text;

            foreach (Control control in this.gbxSexo.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;

                    if (radio.Checked)
                    {
                      
                        Sexo = radio.Text;

                        if(Sexo.Equals("M"))
                        {
                            objEntidadProfesor.Sexo = "Masculino";
                        }
                        else if(Sexo.Equals("F"))
                        {
                            objEntidadProfesor.Sexo = "Femenino";
                        }
                        else
                        {
                            objEntidadProfesor.Sexo = "Otro";
                        }
                    }
                }
            }

            objLogicaProfe.Agregar(objEntidadProfesor);
        }
       
        private void BorrarMensajeError()
        {
            errorProvider1.SetError(txtApellido, "");
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtNombreFam, "");
            errorProvider1.SetError(txtCelular, "");
            errorProvider1.SetError(txtTelefono, "");
            errorProvider1.SetError(txtTelFamiliar, "");
        }

        //Eventos
        private void AceptarNumeros(object sender, KeyPressEventArgs e) //Evento Key Press para aceptar solamente valores numericoso
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error SOLO NUMEROS SE PUEDE INGRESAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            
            }

        }

        private void IngresoLetras(object sender, KeyPressEventArgs e) //Evento  Key PRess solo letras
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error, solo LETRAS SE PUEDE INGRESAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

            }
        }

        private void IngresoTeclaEnter(object sender, KeyEventArgs e) // Evento KeyDown
        {
            if( e.KeyCode == Keys.Enter)
            {
                txtNombre.Focus();
            }   

         }

        private void IngresoEnterNom(object sender, KeyEventArgs e) //Evento kd
        {
            if (e.KeyCode == Keys.Enter)
            {
                gbxSexo.Focus();
                radioButton2.Focus();
                
            }
        }

        private void EnterM(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                radioButton3.Focus();

            }
        }
      
        private void EnterF(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                radioButton4.Focus();

            }

        }

        private void EnterOtro(object sender, KeyEventArgs e)
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

        private void IngresoAceptarFamel(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNombreFam.Focus();
            }
        }

        private void IngresoAcepNomFam(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirmar.Focus();
            }
        }

       


        // FIN DE EVENTOS

    }
}
