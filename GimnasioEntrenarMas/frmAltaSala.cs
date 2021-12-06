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
    public partial class frmAltaSala : Form
    {
        Logica.Sala objLogicaSala = new Logica.Sala();
        Entidades.Sala objEntidadSala = new Entidades.Sala();

        public frmAltaSala()
        {
            InitializeComponent();
            TraerSala();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (this.Validar().Equals(""))
            {

                AgregarSalaValores();

                MessageBox.Show("Sala agregada a la lista con EXITO !!!", "AGREGAR SALA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetearValores();

                TraerSala();
            }
            else
            {
                MessageBox.Show(Validar(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public string Validar()
        {
            string mensaje = "";

            if (txtNombre.Text.Equals(""))
            {
                mensaje += "Ingrese un nombre válido \n";

            }

            if (txtId.Text.Equals(""))
            {
                mensaje += "Ingrese un ID Valido \n";

            }


            btnAgregar.Enabled = false;



            return mensaje;

        }
        
        public void ResetearValores()
        {
            txtId.ResetText();
            txtNombre.ResetText();
          
        }
       
        public void TraerSala()
        {
            Logica.Sala objTraerTodo = new Logica.Sala();

            dgwVer.DataSource = objTraerTodo.TraerTodos("");
            dgwVer.Enabled = true;
        }
  
        public void AgregarSalaValores ()
        {
            objEntidadSala.Id = int.Parse(txtId.Text);

            objEntidadSala.Nombre = txtNombre.Text;


            objLogicaSala.Agregar(objEntidadSala);
        }

        //Evento 

        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error, solo LETRAS SE PUEDE INGRESAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAgregar.Focus();
             

            }
        }

    }
}
