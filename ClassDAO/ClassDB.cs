using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ClassDAO
{
    public class ClassDB
    {
        /// <summary>
        /// Metodo que se encarga de devolver la conexion de sql.
        /// </summary>
        /// <returns>Devuelve la conexion de Sql.</returns>
        public static System.Data.SqlClient.SqlConnection GetConexionSQLServer(String pConexion)
        {
            System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection();
            try
            {
                //Se lee la llave del registro con la contraseña.
                String pConexionEnviar = pConexion;
                cnn.ConnectionString = pConexionEnviar;
            }
            catch
            {
                cnn.ConnectionString = "Data Source=184.168.194.60;Initial Catalog=h2ksoft84_genApp;User Id=genAppAdm;Password=Col2018_;";
                //cnn.ConnectionString = "";
            }
            return cnn;
        }
        /// <summary>
        /// Metodo que realiza una consulta de la base de datos.
        /// </summary>
        /// <param name="pSql">Variable String que contiene la sentencia a ejecutar.</param>
        /// <param name="pError">Variable String que devuelve el error si lo hay.</param>
        /// <returns>Devuelve un DataTable con el resultado de la consulta.</returns>
        public DataTable GetConsulta(String pConexion, String pSql, ref String pError)
        {
            DataTable dtResultado = new DataTable();
            pError = "";
            System.Data.SqlClient.SqlConnection conn = GetConexionSQLServer(pConexion);
            try
            {
                string sql = pSql;
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dtResultado = ds.Tables[0];
            }
            catch (Exception Error)
            {
                pError = Error.Message;
            }
            finally
            {
                conn.Close();
            }
            return dtResultado;
        }
        /// <summary>
        /// Metodo que realiza el insert de una sentencia y devuelve el Id generado.
        /// </summary>
        /// <param name="pSql">Variable String que contiene la sentencia a ejecutar.</param>
        /// <param name="pError">Variable String que contiene el error si lo hay.</param>
        /// <returns>Devuelve el Id del registro adicionado.</returns>
        public Int64 SetInsertId(String pConexion, String pSql, ref String pError)
        {
            Int64 pId = 0;
            pError = "";
            System.Data.SqlClient.SqlConnection conn = GetConexionSQLServer(pConexion);
            try
            {
                conn.Open();
                string sql = pSql;
                SqlCommand command = new SqlCommand(sql, conn);
                pId = Convert.ToInt64(command.ExecuteScalar());
            }
            catch (Exception Error)
            {
                pError = Error.Message;
            }
            finally
            {
                conn.Close();
            }
            return pId;
        }
        /// <summary>
        /// Metodo que se encarga de ejecutar una operacion de la base de datos.
        /// </summary>
        /// <param name="pSql">Variable String que contiene la operacion que se va a ejecutar.</param>
        /// <param name="pError">Variable String que contiene el error si lo hay.</param>
        public void SetOperacion(String pConexion, String pSql, ref String pError)
        {
            pError = "";
            System.Data.SqlClient.SqlConnection conn = GetConexionSQLServer(pConexion);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(pSql, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception Error)
            {
                pError = Error.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        #region Varios
        public String MensajeAlerta(String Mensaje)
        {
            String pClientScript = "";
            pClientScript = "<script language='javascript'> ";
            pClientScript += " alert('" + Mensaje + "'); ";
            pClientScript += " </script>";
            return pClientScript;
        }
        public String MensajeAlertaCerrarVentana(String Mensaje)
        {
            String pClientScript = "";
            pClientScript = "<script language='javascript'> ";
            pClientScript += " alert('" + Mensaje + "'); ";
            pClientScript += " window.close(); ";
            pClientScript += " </script>";
            return pClientScript;
        }
        public String FuncionJavaScript(String Mensaje)
        {
            String pClientScript = "";
            pClientScript = "<script language='javascript'> ";
            pClientScript += " " + Mensaje + "; ";
            pClientScript += " </script>";
            return pClientScript;
        }

        public String GenerarMD5(String pMensaje)
        {
            String pResultado = "";
            using (MD5 md5Hash = MD5.Create())
            {
                pResultado = GetMd5Hash(md5Hash, pMensaje);
            }
            return pResultado;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }



        #endregion
    }
}
