using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semana9
{
    public class Persona
    {
        public string nombre { get; set; }
        public int edad { get; set; }

        public Persona(string nombre, int edad) { 
            this.nombre = nombre;
            this.edad = edad;
        } 
       
        public string Imprime()
        {
            return nombre + " " + edad;
        }

    }
}
