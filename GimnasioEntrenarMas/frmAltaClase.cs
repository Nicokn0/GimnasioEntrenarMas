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
    public partial class frmAltaClase : Form
    {
        Logica.Clase objLogicaClase = new Logica.Clase();
        Entidades.Clase objEntidadClase = new Entidades.Clase();
      

        public frmAltaClase()
        {
            InitializeComponent();
            TraerClase();
        }


        private void button1_Click(object sender, EventArgs e) //Agregar
        {
            BorrarMensajeError();

            if (ValidarCamposVacios())
            {
                DialogResult btn = MessageBox.Show("¿Esta seguro de que desea Guardar los datos de la clase?", "Guardar clase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (btn == DialogResult.Yes)
                {
                    Datos.Clase.Agregar(CrearClase());

                    MessageBox.Show("¡Clase Guardada!", "Guardar Clase", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarControles();

                    TraerClase();
                }
            }
        }

        public void TraerClase()
        {
            Logica.Clase objTraerTodo = new Logica.Clase();

         
            dgwVer.DataSource = objTraerTodo.MostrarClase("");
            dgwVer.Columns[1].HeaderText = "Profesor";
        }
      
        
        private Entidades.Clase CrearClase()
        {
            Entidades.Clase objClaseNew = new Entidades.Clase();

            objClaseNew.Profesor = cbProfe.SelectedIndex + 1;
            objClaseNew.Sala = cbxSala.SelectedIndex + 1;
            objClaseNew.Disciplina = cboClase.SelectedIndex + 1;
            objClaseNew.Duracion = int.Parse(txtDuracion.Text);

            return objClaseNew;
        }


        private void BorrarMensajeError()
        {
            errorProvider1.SetError(cbProfe, "");
            errorProvider1.SetError(cbxSala, "");
            errorProvider1.SetError(cboClase, "");
            errorProvider1.SetError(txtDuracion, "");
        }

        private bool ValidarCamposVacios()
        {
            bool ok = true;

            if (cbxSala.Text == "")
            {
                ok = false;
                errorProvider1.SetError(cbxSala, "Seleccione una Sala");
            }
            if (cbProfe.Text == "")
            {
                ok = false;
                errorProvider1.SetError(cbProfe, "Seleccione un Profesor");
            }
            if (cboClase.Text == "")
            {
                ok = false;
                errorProvider1.SetError(cboClase, "Seleccione una Clase");
            }
            if (txtDuracion.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtDuracion, "Ingrese las horas de duracion de la clase");
            }

            return ok;
        }

        private void LimpiarControles()
        {
            foreach (Control ct in this.Controls)
            {
                if (ct is ComboBox)
                {
                    ct.Text = null;
                }
                if (ct is TextBox)
                {
                    ct.Text = "";
                }
            }
        }

        public void CargarProfesor(ComboBox cbx)
        {
            cbx.DataSource = Logica.Profesor.MostrarProfesor();

            cbx.DisplayMember = "Profesor";
            cbx.ValueMember = "ID";
            
        }
       
        
        public void CargarDisciplina(ComboBox cbx)
        {
            cbx.DataSource = Logica.Disciplina.TraerTodos();

            cbx.DisplayMember = "Nombre";
            cbx.ValueMember = "ID";
        }
       
        public void CargarSala(ComboBox cbx)
        {
            cbx.DataSource = Logica.Sala.TraerTodos();

            cbx.DisplayMember = "Nombre";
            cbx.ValueMember = "ID";
        }

     
        
        private void cbProfe_DropDown(object sender, EventArgs e)
        {
            CargarProfesor(cbProfe);
        }

      
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            CargarSala(cbxSala);
        }

        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void cboClase_DropDown(object sender, EventArgs e)
        {
            CargarDisciplina(cboClase);
        }
    }
}
