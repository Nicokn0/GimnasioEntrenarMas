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
    public partial class frmModificarClase : Form
    {
        Logica.Clase objClase = new Logica.Clase(); //Buscar Registros
        private int ID;


        DataTable objRegistro = new DataTable();
     

        public frmModificarClase()
        {
            InitializeComponent();

            CargarClases(this.dgwVer);
         
            DeshabilitarControles();
        }

     
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            BorrarMensajeError();

            if (ValidarCamposVacios())
            {

                DialogResult btn = MessageBox.Show("¿Esta seguro de que desea Modificar los datos de la clase?", "Modificar clase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (btn == DialogResult.Yes)
                {
                    Entidades.Clase cl1 = new Entidades.Clase();

                    cl1.Id = ID;
                    cl1.Profesor = int.Parse(cbProfe.SelectedValue.ToString());
                    cl1.Disciplina = int.Parse(cboClase.SelectedValue.ToString());
                    cl1.Sala = int.Parse(cbxSala.SelectedValue.ToString());
                    cl1.Duracion = int.Parse(txtDuracion.Text);

                    Logica.Clase.ModificarClase(cl1);

                    CargarClases(this.dgwVer);

                    DeshabilitarControles();
                }
                else
                {
                    DeshabilitarControles();
                }
            }
        }
     
      

        private void btnModificar_Click(object sender, EventArgs e) 
        {
            DialogResult btn = MessageBox.Show("¿Esta seguro de que desea Modificar los datos de la clase?", "Modificar clase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (btn == DialogResult.Yes)
            {
                Entidades.Clase cl1 = new Entidades.Clase();

                cl1.Id = ID;
                cl1.Profesor = int.Parse(cbProfe.SelectedValue.ToString());
                cl1.Disciplina = int.Parse(cboClase.SelectedValue.ToString());
                cl1.Sala = int.Parse(cbxSala.SelectedValue.ToString());
                cl1.Duracion = int.Parse(txtDuracion.Text);

                Logica.Clase.ModificarClase(cl1);

                CargarClases(this.dgwVer);

                DeshabilitarControles();
            }
            else
            {
                DeshabilitarControles();
            }
        }

        //Metodos

        public void DeshabilitarControles ()
        {
           
            txtDuracion.Enabled = false;
            cbxSala.Enabled = false;
            cbProfe.Enabled = false;
            cboClase.Enabled = false;
          
            btnAgregar.Enabled = false;
        }
        
        public void HabilitarControles()
        {
            txtDuracion.Enabled = true;
            cbxSala.Enabled = true;
            cbProfe.Enabled = true;
            cboClase.Enabled = true;
            dgwVer.Enabled = true;
            btnAgregar.Enabled = true;
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
            cboClase.Text = "";
            cbProfe.Text = "";
            cbxSala.Text = "";
            txtDuracion.Text = "";
            
        }
    
        private void CargarClases(DataGridView cb)
        {
            cb.DataSource = Logica.Clase.MostrarClasesID();

            dgwVer.Columns["IDPROF"].Visible = false;
            dgwVer.Columns["IDDIS"].Visible = false;
            dgwVer.Columns["IDSAL"].Visible = false;

        }

        private void CargarDisciplina(ComboBox cb)
        {
            cb.DataSource = Logica.Disciplina.TraerTodos();
            cb.DisplayMember = "Nombre";
            cb.ValueMember = "ID";
        }

        private void CargarProfesor(ComboBox cb)
        {
            cb.DataSource = Logica.Profesor.MostrarProfesor();
            cb.DisplayMember = "Profesor";
            cb.ValueMember = "ID";
        }

        public void CargarSala(ComboBox cbx)
        {
            cbx.DataSource = Logica.Sala.TraerTodos();

            cbx.DisplayMember = "Nombre";
            cbx.ValueMember = "ID";
        }

     
        //Evento

        private void EnterId(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAgregar.Focus();
            }
        }

        private void BTNlIMPIAR_Click(object sender, EventArgs e) //Limpiar controles
        {
            DialogResult btn = MessageBox.Show("¿Esta seguro de que desea LIMPIAR los datos de la clase ?", "Modificar clase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (btn == DialogResult.Yes)
            {
                LimpiarControles();
            }
              
        }

        private void txtBuscarxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error SOLO NUMEROS SE PUEDE INGRESAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
              

            }
        }

        private void dgwVer_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CargarDisciplina(cboClase);
            CargarProfesor(cbProfe);
            CargarSala(cbxSala);

            try
            {
                cboClase.SelectedValue = dgwVer.CurrentRow.Cells["IDDIS"].Value.ToString();
                cbProfe.SelectedValue = dgwVer.CurrentRow.Cells["IDPROF"].Value.ToString();
                cbxSala.SelectedValue = dgwVer.CurrentRow.Cells["IDSAL"].Value.ToString();
                txtDuracion.Text = dgwVer.CurrentRow.Cells["Duracion"].Value.ToString();
                ID = int.Parse(dgwVer.CurrentRow.Cells["Id"].Value.ToString());
                btnAgregar.Enabled = true;
                HabilitarControles();
            }
            catch (FormatException)
            {
                MessageBox.Show("¡No se puede seleccionar esa celda!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DeshabilitarControles();
            }
        }
    }
}
