using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class clsCaballo
    {
        
        public int IdCaballo { get; set; }
        public string Nombre { get; set; }
        public int IdRaza { get; set; }

        public clsCaballo(int idCaballo, string nombre, int idRaza)
        {
            Nombre = nombre;
            IdCaballo = idCaballo;
            IdRaza = idRaza;
        }
        public clsCaballo(int idCaballo)
        {
            IdCaballo = idCaballo;
        }

        public clsCaballo() { }

        public clsCaballo(string nombre, int idRaza)
        {
            Nombre = nombre;
            IdRaza = idRaza;
        }
    }
}
