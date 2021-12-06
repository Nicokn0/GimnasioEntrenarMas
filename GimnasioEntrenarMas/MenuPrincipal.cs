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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        // evento para poder cambiar el color del fondo
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = Color.DarkKhaki;
                }

            }
        }

        //Agregar Alta Clase
        private void agregarClaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarForm(new frmAltaClase());
        }
        private void modificarClaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarForm(new frmModificarClase());
        }

        private void borrarClaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarForm(new frmBorrarClase());
        }

        private void verClasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarForm(new frmVerListaClase());
        }

        // Fin Formularios para clase

        //Inicio Profesores

        private void agregarProfesorToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            MostrarForm(new frmAltaProfesor());
        }

        private void verProfesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarForm(new frmVerListaProfesores());
        }

        private void borrarProfesorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarForm(new frmBajaProfesor());
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarForm(new frmModificarProfesor());
        }

        // Fin formularios profesores

        //Inicio disciplina

        private void agregarDisciplinaToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            MostrarForm(new frmAltaDisciplina());
        }

        private void modificarDisciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarForm(new frmModificarDisciplinas());
        }

        private void borrarDisciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarForm(new frmBorrarDisciplina());
        }

        private void verDisciplinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarForm(new frmVerListaDisciplinas());
        } 
        
        // Fin disciplinas

        //Inicio de Sala

        private void agregarSalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarForm(new frmAltaSala());
        }

        private void modificarSalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarForm(new frmModificarSala());
        }

        private void borrarSalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarForm(new frmBorrarSala());
        }

        private void verSalasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarForm(new frmVerListaSala());
        }

        // Metodo para mostrar todos los formulario

        private void MostrarForm(Form pForm) //recibe por parametro un formulario
        {
            pForm.MdiParent = this; // se va a relacionar con el padre
            pForm.StartPosition = FormStartPosition.CenterScreen; // donde se va a posicionarf 
            pForm.Show(); // para que se observe en pantalla 
        }
    }
}
