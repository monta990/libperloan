using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libAccesoBD;
using MySql.Data.MySqlClient;

namespace libperloan
{
    public class Deudores
    {
        public static MySqlDataReader Lector;
        public static string Error;
        MySQL mysql = new libAccesoBD.MySQL();
        /// <summary>
        /// Ingrea a base de datos deudor nuevo
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="ap1">Apellido Paterno</param>
        /// <param name="ap2">Apellido Materno</param>
        /// <param name="ine">Nuemero de INE</param>
        /// <param name="calle">Calle</param>
        /// <param name="nodom">Domicilio</param>
        /// <param name="colonia">Colonia</param>
        /// <param name="ciudad">Ciudad</param>
        /// <param name="codpostal">Codigo Postal</param>
        /// <param name="estado">Estado</param>
        /// <param name="tel">Telefono</param>
        /// <param name="AvalNombre">Nombre de Aval</param>
        /// <param name="AvalTelefono">Telefono de Aval</param>
        /// <param name="email">Email</param>
        /// <returns></returns>
        public bool Insertar(string nombre, string ap1, string ap2, string ine, string calle, string nodom, string colonia, string ciudad, string codpostal, string estado, string tel, string AvalNombre, string AvalTelefono, string email)
        {
            bool res = false;
            if (mysql.Insertar("deudores", "`nombre`, `ap1`, `ap2`, `ine`, `calle`, `nodom`, `colonia`, `ciudad`, `codpostal`, `estado`, `tel`, `AvalNombre`, `AvalTelefono`, `email`", "'" + nombre + "', '" + ap1 + "', '" + ap2 + "', '" + ine + "', '" + calle + "', '" + nodom + "', '" + colonia + "', '" + ciudad + "', '" + codpostal + "', '" + estado + "', '" + tel + "', '" + AvalNombre + "', '" + AvalTelefono + "', '" + email + "'") == true)
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
        /// Actualiza datos de Deudor
        /// </summary>
        /// <param name="id">ID de duedor a actualizar</param>
        /// <param name="nombre">Nombre de Dudor</param>
        /// <param name="ap1"></param>
        /// <param name="ap2"></param>
        /// <param name="ine"></param>
        /// <param name="calle"></param>
        /// <param name="nodom"></param>
        /// <param name="colonia"></param>
        /// <param name="ciudad"></param>
        /// <param name="codpostal"></param>
        /// <param name="estado"></param>
        /// <param name="tel"></param>
        /// <param name="AvalNombre"></param>
        /// <param name="AvalTelefono"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool Actualizar(string id, string nombre, string ap1, string ap2, string ine, string calle, string nodom, string colonia, string ciudad, string codpostal, string estado, string tel, string AvalNombre, string AvalTelefono, string email)
        {
            bool res = false;
            if (mysql.Actualizar("deudores", "nombre = '" + nombre + "', ap1 = '" + ap1 + "', ap2 = '" + ap2 + "', ine = '" + ine + "', calle = '" + calle + "', nodom = '" + nodom + "', colonia = '" + colonia + "', ciudad = '" + ciudad + "', codpostal = '" + codpostal + "', estado = '" + estado + "', tel = '" + tel + "', AvalNombre = '" + AvalNombre + "', AvalTelefono = '" + AvalTelefono + "', email = '" + email + "'", "id", "'" + id + "'") == true)
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
        /// Lee lista de dudores
        /// </summary>
        /// <returns>Lista de dudores</returns>
        public bool Leer()
        {
            bool res = true;
            if (mysql.Leer("*", "deudores") == true)
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
        /// Elimina a deudor
        /// </summary>
        /// <param name="Id">ID de deudor a eliminar</param>
        /// <returns></returns>
        public bool Eliminar(string Id)
        {
            bool res = false;
            if (mysql.Eliminar("deudores", "id", Id) == true)
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
