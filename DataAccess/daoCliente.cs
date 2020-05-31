using DataAccess.Contract;
using DataAccess.Repository;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class daoCliente : OracleConexion, IOperacionCrud<ClienteBO>
    {
        public string Actualizar(ClienteBO dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_UPDATE_CLIENTE", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_DNI", OracleType.VarChar)).Value = dto.DNI;
                        command.Parameters.Add(new OracleParameter("P_NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("P_APELLIDO", OracleType.VarChar)).Value = dto.APELLIDO;
                        command.Parameters.Add(new OracleParameter("P_EMAIL", OracleType.VarChar)).Value = dto.EMAIL;
                        command.Parameters.Add(new OracleParameter("P_TELEFONO", OracleType.Number)).Value = dto.TELEFONO;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar,50)).Direction = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public string Eliminar(string dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_DELETE_CLIENTE", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_DNI", OracleType.VarChar)).Value = dto;                     
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar,50)).Direction = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public string Insertar(ClienteBO dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_INSERT_CLIENTE", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_DNI", OracleType.VarChar)).Value = dto.DNI;
                        command.Parameters.Add(new OracleParameter("P_NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("P_APELLIDO", OracleType.VarChar)).Value = dto.APELLIDO;
                        command.Parameters.Add(new OracleParameter("P_EMAIL", OracleType.VarChar)).Value = dto.EMAIL;
                        command.Parameters.Add(new OracleParameter("P_TELEFONO", OracleType.Number)).Value = dto.TELEFONO;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar,50)).Direction = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        result =Convert.ToString( command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<ClienteBO> Listar()
        {
            List<ClienteBO> list = new List<ClienteBO>();
            ClienteBO dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_SELECT_CLIENTE", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_CURSOR", OracleType.Cursor)).Direction = System.Data.ParameterDirection.Output;
                        using (OracleDataReader dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                dto = new ClienteBO();
                                dto.DNI = dr["DNI"].ToString();
                                dto.NOMBRE = Convert.ToString( dr["NOMBRE"]);
                                dto.APELLIDO = Convert.ToString(dr["APELLIDO"]);
                                dto.EMAIL = Convert.ToString(dr["EMAIL"]);
                                dto.TELEFONO = Convert.ToInt32(dr["TELEFONO"]);
                                list.Add(dto);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception("Error el metodo Listar "+  ex.Message);
            }
            return list;
        }
    }
}
