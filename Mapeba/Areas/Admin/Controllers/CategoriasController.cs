using Mapeba.AccesoDatos.Data.Repository.IRepository;
using Mapeba.Data;
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







        #region  llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            //opcion 1
            return Json(new { data = contenedorTrabajo.Categoria.GetAll() });
        }


        #endregion
    }
}
