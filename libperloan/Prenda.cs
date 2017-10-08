using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libAccesoBD;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace libperloan
{
    /// <summary>
    /// Administra todas la intecciones que se realizan en la Prenda realizada por los usuarios
    /// </summary>
    public class Prenda
    {
        MySQL mysql = new libAccesoBD.MySQL(); //conexion a base de datos mysql
        public static MySqlDataReader Lector; //lector mysql
        public static string Error;
        /// <summary>
        /// Agrega nueva prenda, usando los parametros tipo, nombre, descripción, detalles
        /// </summary>
        /// <param name="tipo">tipo de prenda</param>
        /// <param name="nombre">nombre de prenda</param>
        /// <param name="descripcion">descripción de prenda</param>
        /// <param name="detalles">detalles de prenda</param>
        /// <returns></returns>
        public bool Insertar(string tipo, string nombre, string descripcion, string detalles)
        {
            bool res = false;
            if (mysql.Insertar("prenda", "`tipo`, `nombre`, `descripcion`, `detalles`", "'" + tipo + "', '" + nombre + "', '" + descripcion + "', '" + detalles + "'") == true)
            {
                res = true;
            }
            else
            {
                Error = MySQL.Error;
            }
            return res;
        }
        /// <summary>
        /// Actualiza datos de prenda
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipo"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="detalles"></param>
        /// <returns></returns>
        public bool Actualizar(string id, string tipo, string nombre, string descripcion, string detalles)
        {
            bool res = false;
            if (mysql.Actualizar("prenda", "tipo = '" + tipo + "', nombre = '" + nombre + "', descripcion = '" + descripcion + "', detalles = '" + detalles + "'", "id", "'" + id + "'") == true)
            {
                res = true;
            }
            else
            {
                Error = MySQL.Error;
            }
            return res;
        }
        /// <summary>
        /// Lee todas las prendas
        /// </summary>
        /// <returns>Regresa lista de prendas</returns>
        public bool Leer() //lectura de datos
        {
            bool res = true;
            if (mysql.Leer("*", "prenda") == true)
            {
                Lector = MySQL.Lector;
                res = true;
            }
            else
            {
                Error = MySQL.Error;
            }
            return res;
        }
        /// <summary>
        /// Elimina prenda
        /// </summary>
        /// <param name="prenda">Prenda a eliminar</param>
        /// <returns>True o False</returns>
        public bool Eliminar(string prenda) //eliminar datos
        {
            bool res = false;
            if (mysql.Eliminar("prenda", "id", prenda) == true)
            {
                res = true;
            }
            else
            {
                Error = MySQL.Error;
            }
            return res;
        }
    }
}