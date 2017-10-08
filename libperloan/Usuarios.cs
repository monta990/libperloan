using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libAccesoBD; //usuamos la libreria de acceso a base de datos
using MySql.Data.MySqlClient;

namespace libperloan
{
    public class Usuarios
    {
        public static MySqlDataReader Lector; //lector mysql
        public static string Error;
        public static string nombre, ApellidoP, ApellidoM, nivel; //datos del usuario activo
        public static int valor; //nivel de acceso
        // inicio middleware con MySQL
        MySQL mysql = new libAccesoBD.MySQL();
        /// <summary>
        /// Autentifica usuario
        /// </summary>
        /// <param name="usuario">Nombre de Usuarios</param>
        /// <param name="pass">Contraseña</param>
        /// <returns>El menú correspondiente</returns>
        public bool Login(string usuario, string pass) //Verifica acceso y mueve al form correcto
        {
            bool res = false;
            if (mysql.Leer("*", "usuarios WHERE user= '"+ usuario +"' AND pass= '"+ pass +"'") == true)
            {
                try
                {
                    if (!Lector.HasRows)
                    {
                        Error = "Usuario y contraseña incorrectos. ";
                        res = false;
                    }
                    else
                    {
                        while (Lector.Read())
                        {
                            if (Lector.GetString(7) == "No") //verifica si usuario esta activo
                            {
                                Error = "Usuario Inactivo. ";
                                res = false;
                            }
                            else
                            {
                                nombre = Lector.GetString(3);
                                ApellidoP = Lector.GetString(4);
                                ApellidoM = Lector.GetString(5);
                                nivel = Lector.GetString(0);
                                if (Lector.GetString(0) == "Administrador") //verifica si es admin
                                {
                                    valor = 0;
                                    res = true;
                                }
                                if (Lector.GetString(0) == "Cobrador") //verifica si es cobrador
                                {
                                    valor = 1;
                                    res = true;
                                }
                            }

                        }
                    }
                }
                catch (MySqlException mse)
                {
                    Error = "Error SQL al Seleccionar. " + mse.Message;
                }
                catch (Exception gen)
                {
                    Error = "Error de conexión a la BD. " + gen.Message;
                }
                finally
                {
                    
                }
            }
            return res;
        }
        /// <summary>
        /// Crea usuario para el sistema
        /// </summary>
        /// <param name="nivel">Nivel</param>
        /// <param name="usuario">Nombre de usuario</param>
        /// <param name="pass">Contraseña</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="ap1">Apellido Paterno</param>
        /// <param name="ap2">Apellido Materno</param>
        /// <param name="email">email</param>
        /// <param name="estado">Activo o inactivo</param>
        /// <returns></returns>
        public bool Insertar(string nivel, string usuario, string pass, string nombre, string ap1, string ap2, string email, string estado)
        {
            bool res = false;
            if (mysql.Insertar("usuarios", "`nivel`, `user`, `pass`, `nombre`, `ap1`, `ap2`, `email`, `estado`", "'" + nivel + "', '" + usuario + "', '" + pass + "', '" + nombre + "', '" + ap1 + "', '" + ap2 + "', '" + email + "', '" + estado + "'") == true)
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
        /// Actualiza datos del usuario
        /// </summary>
        /// <param name="nivel"></param>
        /// <param name="usuario"></param>
        /// <param name="pass"></param>
        /// <param name="nombre"></param>
        /// <param name="ap1"></param>
        /// <param name="ap2"></param>
        /// <param name="email"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        public bool Actualizar(string nivel, string usuario, string pass, string nombre, string ap1, string ap2, string email, string estado)
        {
            bool res = false;
            if (mysql.Actualizar("usuarios", "nivel = '" + nivel + "', pass = '" + pass + "', nombre = '" + nombre + "', ap1 = '" + ap1 + "', ap2 = '" + ap2 + "', email = '" + email + "', estado = '" + estado + "'", "user", "'" + usuario + "'") == true)
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
        /// Lee todo los usuarios
        /// </summary>
        /// <returns></returns>
        public bool Leer()
        {
            bool res = true;
            if (mysql.Leer("*","usuarios")==true)
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
        /// Elimina usuario del sistema
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool Eliminar(string usuario)
        {
            bool res = false;
            if (mysql.Eliminar("usuarios", "user", usuario) == true)
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