using Mapeba.AccesoDatos.Data.Repository.IRepository;
using Mapeba.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeba.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Categoria = new CategoriaRepository(_db);
        }

        public ICateoriaRepository Categoria { get; private set; }

        public void Dispose()
        {
            _db.Dispose();  
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
