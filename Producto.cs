using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPropuesto1
{
    class Producto
    {

        public string ID { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }

        public Producto() { }
        public Producto(string cadena) {
            String[] propiedades = cadena.Split(',');
            ID = propiedades[0];
            nombre = propiedades[1];
            precio = double.Parse(propiedades[2]);
        }
        
        public string lineaArchivo { get {

                return ID + "," + nombre + "," + precio;
            } 
        }
    
    }
}
