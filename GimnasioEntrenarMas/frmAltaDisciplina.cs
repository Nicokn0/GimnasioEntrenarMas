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
    public partial class frmAltaDisciplina : Form
    {
        Logica.Disciplina objLogicaDisciplina = new Logica.Disciplina();
        Entidades.Disciplina objEntidadDisciplina = new Entidades.Disciplina();

        public frmAltaDisciplina()
        {
            InitializeComponent();
            TraerDisciplinas();
        }

        private void button2_Click(object sender, EventArgs e) // sALIR
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) //agregar
        {
            if (this.Validar().Equals(""))
            {
                AgregarValores();

                MessageBox.Show("Disciplina agregada a la lista con EXITO !!!", "AGREGAR DISCIPLINA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetearValores();

                TraerDisciplinas();
            }
            else
            {
                MessageBox.Show(Validar(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) // Resetear Valores 
        {
            ResetearValores();
        }
        public void TraerDisciplinas()
        {
            Logica.Disciplina objTraerTodo = new Logica.Disciplina();

            //uso metodo traer todo para pasarle la base de datos   
            dgwVer.DataSource = objTraerTodo.TraerTodos("");
            dgwVer.Enabled = true;
        }

        public string Validar()
        {
            string mensaje = "";

            if (txtNombre.Text.Equals("") )
            {
                mensaje += "Ingrese un nombre válido \n";

            }

            if (txtId.Text.Equals(""))
            {
                mensaje += "Ingrese un ID Valido \n";

            }


            if (txtDescripcion.Text.Equals(""))
            {
                mensaje += "Ingrese una Descripción Valida \n";

            }

           

            return mensaje;

        }

        public void ResetearValores()
        {
            txtId.ResetText();
            txtNombre.ResetText();
            txtDescripcion.ResetText();
           
        }
        
        public void AgregarValores ()
        {
            objEntidadDisciplina.Id = int.Parse(txtId.Text);
            objEntidadDisciplina.Descripcion = txtDescripcion.Text;
            objEntidadDisciplina.Nombre = txtNombre.Text;


            objLogicaDisciplina.AgregarDisciplina(objEntidadDisciplina);
        }

        private void IngresoValoresNumericos(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error SOLO NUMEROS SE PUEDE INGRESAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void SoloLetras(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error solo LETRAS SE PUEDE INGRESAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void IngresoEnt(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNombre.Focus();
            }
        }

        private void EnterTec(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescripcion.Focus();
            }
        }

    }
}
