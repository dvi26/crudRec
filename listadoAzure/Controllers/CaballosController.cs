using System.Collections.ObjectModel;
using DAL;
using ENT;
using listadoAzure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace listadoAzure.Controllers
{
    public class CaballosController : Controller
    {
        public ActionResult Index()
        {
            
            List<clsRaza> listadoRazas = listadoDAL.ObtenerRazas();
            List<clsCaballoConRaza> listadoCompleto= new List<clsCaballoConRaza>(); ; 
            foreach (clsCaballo caballo in listadoDAL.ObtenerCaballos())
            {
                clsCaballoConRaza caballoNuevo = new clsCaballoConRaza(caballo, listadoRazas);
                listadoCompleto.Add(caballoNuevo);

            }
            return View(listadoCompleto);
        }

        public ActionResult Edit(int id)
        {

            return View();
        }

    }
}
