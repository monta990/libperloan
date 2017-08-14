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
        BD mysql = new libAccesoBD.BD();
        public bool Insertar(string nombre, string ap1, string ap2, string ine, string calle, string nodom, string colonia, string ciudad, string codpostal, string estado, string tel, string AvalNombre, string AvalTelefono, string email)
        {
            bool res = false;
            if (mysql.Insertar("deudores", "`nombre`, `ap1`, `ap2`, `ine`, `calle`, `nodom`, `colonia`, `ciudad`, `codpostal`, `estado`, `tel`, `AvalNombre`, `AvalTelefono`, `email`", "'" + nombre + "', '" + ap1 + "', '" + ap2 + "', '" + ine + "', '" + calle + "', '" + nodom + "', '" + colonia + "', '" + ciudad + "', '" + codpostal + "', '" + estado + "', '" + tel + "', '" + AvalNombre + "', '" + AvalTelefono + "', '" + email + "'") == true)
            {
                res = true;
            }
            else
            {
                Error = BD.Error;
            }
            return res;
        }
        public bool Actualizar(string id, string nombre, string ap1, string ap2, string ine, string calle, string nodom, string colonia, string ciudad, string codpostal, string estado, string tel, string AvalNombre, string AvalTelefono, string email)
        {
            bool res = false;
            if (mysql.Actualizar("deudores", "nombre = '" + nombre + "', ap1 = '" + ap1 + "', ap2 = '" + ap2 + "', ine = '" + ine + "', calle = '" + calle + "', nodom = '" + nodom + "', colonia = '" + colonia + "', ciudad = '" + ciudad + "', codpostal = '" + codpostal + "', estado = '" + estado + "', tel = '" + tel + "', AvalNombre = '" + AvalNombre + "', AvalTelefono = '" + AvalTelefono + "', email = '" + email + "'", "id", "'" + id + "'") == true)
            {
                res = true;
            }
            else
            {
                Error = BD.Error;
            }
            return res;
        }
        public bool Leer()
        {
            bool res = true;
            if (mysql.Leer("*", "deudores") == true)
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
        public bool Eliminar(string deudor)
        {
            bool res = false;
            if (mysql.Eliminar("deudores", "id", deudor) == true)
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
