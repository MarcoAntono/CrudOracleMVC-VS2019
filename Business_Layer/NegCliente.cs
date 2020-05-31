using DataAccess;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
   public class NegCliente
    {

        public string Actualizar(ClienteBO dto)
        {
            daoCliente dao = new daoCliente();
            return dao.Actualizar(dto);
        }

        public string Eliminar(string dto)
        {
            daoCliente dao = new daoCliente();
            return dao.Eliminar(dto);
        }
        public string Insert(ClienteBO dto )
        {
            daoCliente dao = new daoCliente();
            return dao.Insertar(dto);
        }
        public List<ClienteBO> Listar()
        {
            daoCliente dao = new daoCliente();
            return dao.Listar();
        }

    }
}
