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
    public partial class frmVerListaDisciplinas : Form
    {
        Logica.Disciplina objTraerTodo = new Logica.Disciplina();

        public frmVerListaDisciplinas()
        {
            InitializeComponent();

            dgwVer.DataSource = objTraerTodo.TraerTodos("");
        }

    
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable objRegistro = new DataTable();

            objRegistro = objTraerTodo.BuscarDisciplina(int.Parse(txtBucarClase.Text));

            if (txtBucarClase.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar ID, para buscar Profesor", "Ver Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (objRegistro.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontro la CLASE", "Ver Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                else
                {
                    MessageBox.Show("Consulta encontrada", "Ver Disciplina", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBucarClase.Text = "";
                    dgwVer.DataSource = objRegistro;

                }
              
            }
            
        
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dgwVer.DataSource = objTraerTodo.TraerTodos("");
        }
    }
}
