using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contract
{
  public  interface IOperacionCrud<T>
    {
        string Insertar(T dto);
        string Actualizar(T dto);
        string Eliminar(string dto);
        List<T> Listar();
    }
}
