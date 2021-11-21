using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioPropuesto1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ListaProducto lista = new ListaProducto();
        int posicionSeleccionada = -1;
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Producto nuevoProducto = new Producto();
            nuevoProducto.ID = ListaProducto.nuevoID();
            nuevoProducto.nombre = txtNombre.Text;
            nuevoProducto.precio = double.Parse(txtPrecio.Text);

            lista.agregarProducto(nuevoProducto);
            actualizarTabla();
        }

        private void actualizarTabla()
        {

            dataGridView1.Rows.Clear();
            List<Producto> aux = lista.getList();
            for (int y = 0; y < aux.Count; y++)
            {
                agregarProductoALista(aux[y]);
            }
        }

        private void agregarProductoALista(Producto prod)
        {

            int filaAgregada = dataGridView1.Rows.Add();
            DataGridViewRow nuevaFila = dataGridView1.Rows[filaAgregada];
            nuevaFila.Cells[0].Value = prod.ID;
            nuevaFila.Cells[1].Value = prod.nombre;
            nuevaFila.Cells[2].Value = prod.precio;

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                    posicionSeleccionada = filaSeleccionada.Index;
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (posicionSeleccionada > -1)
            {
                lista.eliminarProducto(posicionSeleccionada);
                actualizarTabla();
            }
            else
            {
                MessageBox.Show("Selecciona un producto");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            lista.escribirListaEnArchivo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lista.cargarListaDesdeArchivo();
            actualizarTabla();
        }
    }
}
