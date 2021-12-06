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
    public partial class frmBorrarClase : Form
    {
        Logica.Clase objSala = new Logica.Clase(); //Buscar Registros

        public frmBorrarClase()
        {
            InitializeComponent();

            TraerClase();
        }

       

        private void button1_Click(object sender, EventArgs e) //buscar
        {
            if (txtBuscarId.Text.Equals("") )
            {
                MessageBox.Show("Ingrese NOMBRE o APELLIDO para buscar CLASE", "MODIFICAR CLASE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
            else
            {

                MostrarDatos();

            }
         
        }
       
        private void btnBorrar_Click(object sender, EventArgs e) //Botón Buscar
        {
            DialogResult btnpregunta = MessageBox.Show("¿Esta seguro de que desea BORRAR los datos de la Clase?", "Modificar Clase", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (btnpregunta == DialogResult.Yes)
            {

                objSala.BorrarClase(int.Parse(txtBuscarId.Text));

                MessageBox.Show("¡Clase Eliminada!", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtBuscarId.Text = "";

                dgwVer.DataSource = objSala.MostrarClase("");

                btnBorrar.Enabled = false;
            }


            TraerClase();
        }
     
        //Metodos
        
        public void MostrarDatos()
        {
            DataTable objRegistro = new DataTable();


            if (!txtBuscarId.Text.Equals(""))
            {

                objRegistro = objSala.BuscarClase(int.Parse(txtBuscarId.Text));

                if (objRegistro.Rows.Count == 0)
                {
                    MessageBox.Show("No se ha encontrado registros", "Borrar Clase", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    btnBorrar.Enabled = false;
                }

                if (objRegistro.Rows.Count == 1)
                {
                    MessageBox.Show("Se encontro 1 registro. Debera confirmar acción en botón borrar", "Borrar Clase", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dgwVer.DataSource = objSala.FiltrarClase(int.Parse(txtBuscarId.Text));
                    btnBorrar.Enabled = true;

                }
            }
           
        }

        public void TraerClase()
        {
            Logica.Clase objTraerTodo = new Logica.Clase();

            //uso metodo traer todo para pasarle la base de datos   
            dgwVer.DataSource = objTraerTodo.MostrarClase("");
            dgwVer.Columns[1].HeaderText = "Profesor";
        }


        // Eventos 

       
        private void BuscarNombre(object sender, EventArgs e) //Evento cuando escribo me tira la lista actualizada
        {
            dgwVer.DataSource = objSala.BuscarClase(int.Parse(txtBuscarId.Text));
        }

        private void SoloNumeros(object sender, KeyPressEventArgs e) //Evento Keypres
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error SOLO NUMEROS SE PUEDE INGRESAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void SoloNombres(object sender, KeyPressEventArgs e) //Evento Keypres
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Error solo LETRAS SE PUEDE INGRESAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
        //Vale

        private void SeleccionarCelda(object sender, DataGridViewCellEventArgs e)
        {
            if (dgwVer.SelectedRows.Count > 0)
            {
                txtBuscarId.Text = dgwVer.CurrentRow.Cells["Id"].Value.ToString();


                MessageBox.Show($"Acaba de seleccionar la fila a ELIMINAR: \n  ID: {txtBuscarId.Text} ", "Borrar Profesor", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }


            btnBorrar.Enabled = true;
        }
    }
}
