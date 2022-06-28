using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using SDLX.DTO;
using SDLX.Constantes;

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
            using (SqlCommand cmd = new SqlCommand("SELECT nombre,puesto,salario FROM vendedores WHERE claveVendedor=@Cve", sqlConnection))
            {
                cmd.Parameters.AddWithValue("@cve", cve);
                using (SqlDataReader reader = cmd.ExecuteReader())
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
    