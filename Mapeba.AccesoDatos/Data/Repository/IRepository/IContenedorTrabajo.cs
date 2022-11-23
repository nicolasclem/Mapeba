using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapeba.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo: IDisposable
    {
        ICateoriaRepository Categoria { get; }
        // se agregan los diferentes repositorios

        void Save();
    }
}
