using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
   public class OracleConexion
    {
        protected string strOracle = string.Empty;
        public OracleConexion()
        {
            strOracle = ConfigurationManager.ConnectionStrings["oracleConex"].ConnectionString;
        }
    }
}
