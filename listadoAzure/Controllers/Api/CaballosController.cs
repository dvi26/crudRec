using DAL;
using ENT;
using listadoAzure.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace listadoAzure.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaballosController : ControllerBase
    {
        // GET: api/<CaballosController>
        [HttpGet]
        public ActionResult Get()
        {
            List<clsCaballo> listaCaballos = new List<clsCaballo>();
            ActionResult res;
            try
            {
                listaCaballos=listadoDAL.ObtenerCaballos();
            }
            catch (Exception e)
            {
                res = NotFound("Error en la base de datos al obtener los caballos");
            }
            if (listaCaballos == null || listaCaballos.Count == 0)
            {
                res= NotFound("No se encontraron personas.");
            }
            else
            {
                res = Ok(listaCaballos);
            }
            return res;  
        }

        // GET api/<CaballosController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            clsCaballo caballo= new clsCaballo();
            ActionResult res;
            try
            {
                caballo = listadoDAL.buscarCaballoPorId(id);
            }
            catch (Exception e)
            {
                res = NotFound("Error en la base de datos al obtener el caballo");
            }
            if (caballo == null)
            {
                res = NotFound($"Persona con ID {id} no encontrada.");
            }
            else
            {
                res = Ok(caballo);
            }
            return res;
        }

        // POST api/<CaballosController>
        [HttpPost]
        public ActionResult Post([FromBody] clsCaballo caballo)
        {
            ActionResult res;
            if (caballo == null)
            {
                res = BadRequest("El objeto persona es nulo.");
            }
            else
            {
                try
                {
                    if (crudListado.crearCaballo(caballo) > 0)
                    {
                        res = CreatedAtAction(nameof(Get), new { id = caballo.IdCaballo }, caballo);
                    }
                    else
                    {
                        res = NotFound("Error en la base de datos al insertar el caballo");
                    }
                }
                catch (Exception e)
                {
                    res = NotFound("Error en la base de datos al insertar el caballo");
                }

                return res;
            }
        }

        // PUT api/<CaballosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CaballosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
