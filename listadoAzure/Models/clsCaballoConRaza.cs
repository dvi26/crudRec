using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ENT;

namespace listadoAzure.Models
{
    public class clsCaballoConRaza : clsCaballo 
    {
        private string nombreRaza;

        [Display(Name = "Nombre de la Raza")]
        public string NombreRaza
        {
            get { return nombreRaza; }
        }
        public clsCaballoConRaza(clsCaballo caballo, List<clsRaza> listadoParam)
        {
            this.IdCaballo = caballo.IdCaballo;
            this.Nombre = caballo.Nombre;
            this.IdRaza = caballo.IdRaza;
            nombreRaza = listadoParam.Where(x => x.IdRaza == IdRaza).FirstOrDefault().Nombre;
        }


        }
}
