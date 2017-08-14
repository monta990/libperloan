using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libAccesoBD;
using MySql.Data.MySqlClient;

namespace libperloan
{
    /// <summary>
    /// Administra todas la intecciones que se realizan en la Prenda realizada por los usuarios
    /// </summary>
    public class Prenda
    {
        BD mysql = new libAccesoBD.BD(); //conexion a base de datos mysql
        public static MySqlDataReader Lector; //lector mysql
        public static string Error;
        public bool Insertar(string tipo, string nombre, string descripcion, string detalles)
        {
            bool res = false;
            if (mysql.Insertar("prenda", "`tipo`, `nombre`, `descripcion`, `detalles`", "'" + tipo + "', '" + nombre + "', '" + descripcion + "', '" + detalles + "'") == true)
            {
                res = true;
            }
            else
            {
                Error = BD.Error;
            }
            return res;
        }
        public bool Actualizar(string id, string tipo, string nombre, string descripcion, string detalles)
        {
            bool res = false;
            if (mysql.Actualizar("prenda", "tipo = '" + tipo + "', nombre = '" + nombre + "', descripcion = '" + descripcion + "', detalles = '" + detalles + "'", "id", "'" + id + "'") == true)
            {
                res = true;
            }
            else
            {
                Error = BD.Error;
            }
            return res;
        }
        public bool Leer() //lectura de datos
        {
            bool res = true;
            if (mysql.Leer("*", "prenda") == true)
            {
                Lector = BD.Lector;
                res = true;
            }
            else
            {
                Error = BD.Error;
            }
            return res;
        }
        public bool Eliminar(string prenda) //eliminar datos
        {
            bool res = false;
            if (mysql.Eliminar("prenda", "id", prenda) == true)
            {
                res = true;
            }
            else
            {
                Error = BD.Error;
            }
            return res;
        }
    }
}