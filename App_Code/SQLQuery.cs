using SDLX.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for SQLQuery
/// </summary>
/// 
namespace SDLX.SQL
{
    public class SQLQuery : SQL
    {

        public DTOEmpleado EmpleadoDTO(string cve, bool close = true)
        {
            DTOEmpleado dtoRespuesta = new DTOEmpleado();
            using (MySqlCommand cmd = new MySqlCommand("SELECT nombre,puesto,salario FROM vendedores WHERE claveVendedor=@Cve", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@cve", cve);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dtoRespuesta.nombre = reader.GetString(reader.GetOrdinal("nombre"));
                        dtoRespuesta.puesto = reader.GetString(reader.GetOrdinal("puesto"));
                        dtoRespuesta.salario = reader.GetString(reader.GetOrdinal("salario"));
                    }
                    Close(close);
                    return dtoRespuesta;
                }
            }
        }
    }
}
