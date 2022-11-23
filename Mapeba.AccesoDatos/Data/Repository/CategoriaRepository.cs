using Mapeba.AccesoDatos.Data.Repository.IRepository;
using Mapeba.Data;
using Mapeba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mapeba.AccesoDatos.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICateoriaRepository
    {
        private readonly ApplicationDbContext context;

        public CategoriaRepository(ApplicationDbContext context):base(context)
        {
            this.context = context;
        }
        public IEnumerable<SelectListItem> GetListaCategoria()
        {
            return context.Categorias.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Id.ToString()
            });
        }
        public void Update(Categoria categoria)
        {
            var objetoDesdeDb = context.Categorias.FirstOrDefault(s => s.Id ==  categoria.Id);
            objetoDesdeDb.Nombre = categoria.Nombre;
            objetoDesdeDb.Orden = categoria.Orden;
            context.SaveChanges();
        }
    }
}
