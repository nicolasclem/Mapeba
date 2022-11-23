using Mapeba.AccesoDatos.Data.Repository.IRepository;
using Mapeba.Data;
using Mapeba.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mapeba.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IContenedorTrabajo contenedorTrabajo;
        private readonly ApplicationDbContext context;

        public CategoriasController(IContenedorTrabajo contenedorTrabajo,ApplicationDbContext context)
        {
            this.contenedorTrabajo = contenedorTrabajo;
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria  categoria) 
        {
            if (ModelState.IsValid)
            {
                contenedorTrabajo.Categoria.Add(categoria);
                contenedorTrabajo.Save();
                return RedirectToAction("Index");
            }

                return View(categoria);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categoria categoria = new Categoria();
            categoria = contenedorTrabajo.Categoria.Get(id);
            if(categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                contenedorTrabajo.Categoria.Update(categoria);
                contenedorTrabajo.Save();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        #region  llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            //opcion 1
            return Json(new { data = contenedorTrabajo.Categoria.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            var objfromDb = contenedorTrabajo.Categoria.Get(id);  
            if(objfromDb == null) 
            {
                return  Json(new {success= false, message="Error Borrando Categoria"}); 
            }

            contenedorTrabajo.Categoria.Remove(objfromDb);
            contenedorTrabajo.Save();
            return Json(new { success = true, message = "Categoria borrada!" });
        }

        #endregion
    
    }



}
