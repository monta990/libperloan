using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libAccesoBD;
using MySql.Data.MySqlClient;

namespace libperloan
{
    public class Prestamo
    {
        BD mysql = new libAccesoBD.BD();
        public static MySqlDataReader Lector; //lector mysql
        public static string Error;
        public bool Insertar(string id_deudor, string monto, string plazo, string id_prenda, string nom_prenda, string nom_deudor)
        {
            bool res = false;
            if (mysql.Insertar("prestamos", "`id_deudor`, `monto`, `plazo`, `id_prenda`, `nom_prenda`, `nom_deudor`", "'" + id_deudor + "', '" + monto + "', '" + plazo + "', '" + id_prenda + "', '" + nom_prenda + "', '" + nom_deudor + "'") == true)
            {
                res = true;
                AsignarPrenda(id_prenda, id_deudor);
            }
            else
            {
                Error = BD.Error;
            }
            return res;
        }
        public bool Leer()
        {
            bool res = false;
            if (mysql.Leer("*", "prestamos") == true)
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
        public bool Eliminar(string usuario)
        {
            bool res = false;
            if (mysql.Eliminar("prestamos", "id", usuario) == true)
            {
                res = true;
            }
            else
            {
                Error = BD.Error;
            }
            return res;
        }
        public bool Actualizar(string id, string id_deudor, string monto, string plazo, string id_prenda, string nom_prenda, string nom_deudor)
        {
            bool res = false;
            if (mysql.Actualizar("prestamos", "id_deudor = '" + id_deudor + "', monto = '" + monto + "', plazo = '" + plazo + "', id_prenda = '" + id_prenda + "', nom_prenda = '" + nom_prenda + "', nom_deudor = '" + nom_deudor + "'","id",id) ==true)
            {
                res = true;
            }
            else
            {
                Error = BD.Error;
            }
            return res;
        }
        public bool AsignarPrenda(string id, string id_deudor) // asiga prenda al crear deudor
        {
            bool res = false;
            if (mysql.Actualizar("prenda", "id_deudor = '" + id_deudor + "'", "id", id) == true)
            {
                res = true;
                
            }
            else
            {
                Error = BD.Error;
            }
            return res;
        }
        public bool LeerDuedorID(string id)
        {
            bool res = false;
            if (mysql.Leer("*", "deudores WHERE id = '" + id + "'") == true)
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
        public bool LeerPrendaID(string id)
        {
            bool res = false;
            if (mysql.Leer("*", "prenda WHERE id = '" + id + "'") == true)
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
    }
}
