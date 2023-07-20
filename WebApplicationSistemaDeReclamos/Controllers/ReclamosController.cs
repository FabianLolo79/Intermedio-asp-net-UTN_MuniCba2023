using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSistemaDeReclamos.Models;
using WebApplicationSistemaDeReclamos.Models.ViewModels;
using WebApplicationSistemaDeReclamos.Services;

namespace WebApplicationSistemaDeReclamos.Controllers
{
    public class ReclamosController : Controller
    {
        // GET: ReclamosController

        //public ActionResult Buscar()
        //{
        //    ReclamosService reclamosService = new ReclamosService();
        //    List<Reclamo> reclamos = reclamosService.RecuperarListadoDeReclamos(TextoBuscar);
        //}

        public ActionResult Index()
        {
            ReclamosService reclamosService = new ReclamosService();
            List<Reclamo> reclamos = reclamosService.RecuperarListadoDeReclamos();

            List<ReclamoViewModel> reclamosViewModel = new List<ReclamoViewModel>();

            foreach (Reclamo r in reclamos)
            {
                reclamosViewModel.Add(new ReclamoViewModel()
                {
                    Id = r.Id,
                    Titulo = r.Titulo,
                    Descripcion = r.Descripcion,
                    Estado = r.Estado,
                    FechaAlta = r.FechaAlta,
                }); 
            }
            return View(reclamosViewModel);
        }

        // GET: ReclamosController/Details/5
        public ActionResult Details(int id)
        {
            ReclamosService reclamosService = new ReclamosService();
            //To do: tengo que recuperar un reclamo....

            ReclamoViewModel reclamoViewModel = new ReclamoViewModel();
            reclamoViewModel.Id = id;
            reclamoViewModel.Titulo = "Ejemplo editar";
            reclamoViewModel.Descripcion = "Ejemplo editar 1234314";
            reclamoViewModel.Estado = "Inicial";
            reclamoViewModel.FechaAlta = DateTime.Now;

            return View(reclamoViewModel);
        }

        // GET: ReclamosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReclamosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReclamoViewModel reclamoViewModel)
        {
            if(ModelState.IsValid)
            {
                ReclamosService reclamosService = new ReclamosService();
                Reclamo reclamo = new Reclamo();
                reclamo.Titulo = reclamoViewModel.Titulo;
                reclamo.Descripcion = reclamoViewModel.Descripcion;
                reclamo.Estado = reclamoViewModel.Estado;
                reclamo.FechaAlta = DateTime.Now;

                reclamosService.AltaReclamo(reclamo);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //HAY ALGÚN ERROR DE VALIDACION...VUELVO A MOSTRAR EL FORMULARIO
                return View();
            }
        }

        // GET: ReclamosController/Edit/5
        public ActionResult Edit(int id)
        {
            ReclamoViewModel reclamoViewModel = new ReclamoViewModel();
            reclamoViewModel.Id = id;
            reclamoViewModel.Titulo = "Ejemplo editar";
            reclamoViewModel.Descripcion = "Ejemplo editar 1234314"; 
            reclamoViewModel.Estado = "Inicial";
            reclamoViewModel.FechaAlta = DateTime.Now;
            return View(reclamoViewModel);
        }

        // POST: ReclamosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReclamoViewModel reclamoViewModel)
        {
            if(ModelState.IsValid)
            {
                // To do: HACER EL EDIT EN LA BASE DE DATOS...
                // VOLVER AL LISTADO RECLAMOS
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //HAY ALGUN ERROR DE VALIDACION ...
                //VUELVO A MOSTRAR EL FORMULARIO
                return View();
            }
        }

        // GET: ReclamosController/Delete/5
        public ActionResult Delete(int id)
        {
            //To do borra de la base de datos el reclamo
            ReclamosService reclamoService = new ReclamosService();
            reclamoService.BorrarReclamo(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
