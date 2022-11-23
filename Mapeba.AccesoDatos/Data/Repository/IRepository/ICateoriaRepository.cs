using Mapeba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Mapeba.AccesoDatos.Data.Repository.IRepository
{
    public interface ICateoriaRepository:IRepository<Categoria>
    {
        IEnumerable<SelectListItem> GetListaCategoria();

        void Update(Categoria categoria);
    }
}
