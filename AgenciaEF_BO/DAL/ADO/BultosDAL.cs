using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using AgenciaEF_BO.Models;

namespace AgenciaEF_BO.DAL.ADO
{
    public class BultosDal
    {
        private SqlConnection _connection;

        public bool InsertarCargos(int piBultoLocal, int piBltNumero)
        {
            bool bRetorno;

            using (_connection = Acceso.ObtenerConexion())
            {
                bRetorno = _connection.Query<bool>(@"PROC_INSERTAR_CARGOS", new { piBultoLocal, piBltNumero }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                
            }

            return false;
        }

        /*public Agencias ObtenerAgenciaPorCodigo(string ageCodigo, int tipoBusqueda = 1)
        {
            Agencias _agencia = null;
            using (_connection = Acceso.ObtenerConexion())
            {
                _agencia = _connection.Query<Agencias>(@"sp_sopv2_ObtenerAgenciaPorCodigo", new { ageCodigo, tipoBusqueda }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return _agencia;
        }
         */ 

        /*public ICollection<Agencias> ObtenerAgencias(string parametro, int tipoBusqueda)
        {
            ICollection<Agencias> _agencias;
            using (_connection = Acceso.ObtenerConexion())
            {
                _agencias = _connection.Query<Agencias>("sp_sopv2_ObtenerAgencias", new { parametro, tipoBusqueda }, commandType: CommandType.StoredProcedure).ToList();
            }
            return _agencias;
        }*/

        /*public string ObtenerDescripcionAgencia(string ageCodigo)
        {
            string _descripcionAgencia = null;
            using (_connection = Acceso.ObtenerConexion())
            {
                _descripcionAgencia = _connection.Query<string>("sp_sopv2_ObtenerDescripcionAgencia", new
                {
                    ageCodigo
                }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return _descripcionAgencia;
        }*/
    }
}
