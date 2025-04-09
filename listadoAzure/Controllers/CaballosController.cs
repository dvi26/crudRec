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
        public IActionResult Details(int id)
        {
            var caballo = listadoDAL.buscarCaballoPorId(id);

            return View(caballo);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( string Nombre, int idRaza)
        {
            try
            {
                clsCaballo caballoNuevo = new clsCaballo(Nombre, idRaza);
                crudListado.crearCaballo(caballoNuevo);
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int Id)
        {
            var caballo = listadoDAL.buscarCaballoPorId(Id);
            return View(caballo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(clsCaballo caballo)
        {
            try
            {
                crudListado.editarCaballo(caballo);
                return RedirectToAction(nameof(Edit));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            clsCaballo caballoSeleccionado = listadoDAL.buscarCaballoPorId(id);
            return View(caballoSeleccionado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int nCaballosBorrados = crudListado.deleteCaballoDAL(id);
                //ViewData["Dato"] = nPersonasBorradas;
                clsCaballo caballoSeleccionado = listadoDAL.buscarCaballoPorId(id);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

    }
}
