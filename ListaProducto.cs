using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace EjercicioPropuesto1
{
    class ListaProducto
    {

        List<Producto> productos = new List<Producto>();

        public static string nuevoID() {
            DateTime fechaActual = DateTime.Now;
            String valor=fechaActual.ToLongTimeString();
            return valor;
        }

        public void agregarProducto(Producto prod) {
            productos.Add(prod);
        }

        public void eliminarProducto(int index) {
            productos.RemoveAt(index);
        }

        public List<Producto> getList() {
            return productos;        
        }

        public void cargarListaDesdeArchivo() 
        {
            productos = new List<Producto>();

            try
            {

                StreamReader sr = new StreamReader("ArchivoTextual");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    productos.Add(new Producto(line));                    
                }
                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("El archivo no se pudo leer: ");
                MessageBox.Show(e.Message);
            }

        }

        public void escribirListaEnArchivo() 
        {
            try
            {

                StreamWriter sw = new StreamWriter("ArchivoTextual",false);
                for(int u = 0; u < productos.Count; u++)
                {
                    sw.WriteLine(productos[u].lineaArchivo);
                }
                sw.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("No se puede escribir en el archive");
                MessageBox.Show(e.Message);
            }

        }
    }
}
