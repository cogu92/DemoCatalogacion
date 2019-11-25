using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ClassDAO
{
    public class cl_Usuarios
    {
        protected Int64 _Id { get; set; }
        protected String _Usuario { get; set; }
        protected String _Clave { get; set; }
        protected String _Email { get; set; }
        protected Int64 _Estado { get; set; }
        protected String _Nombre { get; set; }
        protected String _Apellido { get; set; }
        protected String _Identificacion { get; set; }

        //Constructor sin parámetros
        public cl_Usuarios()
        {
            _Id = 0;
            _Usuario = "";
            _Clave = "";
            _Email = "";
            _Estado = 1;
            _Nombre = "";
            _Apellido = "";
            _Identificacion = "";
        }

        //Constructor con parámetros
        public cl_Usuarios(
            Int64 pId,
            String pUsuario,
            String pClave,
            String pEmail,
            Int64 pEstado,
            String pNombre,
            String pApellido,
            String pIdentificacion
            )
        {
            _Id = pId;
            _Usuario = pUsuario;
            _Clave = pClave;
            _Email = pEmail;
            _Estado = pEstado;
            _Nombre = pNombre;
            _Apellido = pApellido;
            _Identificacion = pIdentificacion;
        }

        #region Metodos

        public DataTable Consult(String pConexion, ref String pError)
        {
            pError = "";
            DataTable dtResultado = new DataTable();
            ClassDB AccesoDB = new ClassDB();
            try
            {
                dtResultado = AccesoDB.GetConsulta(pConexion, "SELECT U.* FROM CT_Ct_Usuarios U ", ref pError);
            }
            catch (Exception ex)
            {
                pError = ex.Message;
            }
            return dtResultado;
        }

        public DataTable ConsultActive(String pConexion, ref String pError)
        {
            pError = "";
            DataTable dtResultado = new DataTable();
            ClassDB AccesoDB = new ClassDB();
            try
            {
                dtResultado = AccesoDB.GetConsulta(pConexion, "SELECT U.* FROM Ct_Usuarios U WHERE U.Estado = 1 ", ref pError);
            }
            catch (Exception ex)
            {
                pError = ex.Message;
            }
            return dtResultado;
        }

        public DataTable ValidarUsuario(String pConexion, String pUsuario, String pContrasena, ref String pError)
        {
            DataTable dtResultado = new DataTable();
            ClassDB AccesoDB = new ClassDB();
            try
            {
                dtResultado = AccesoDB.GetConsulta(pConexion, " SELECT U.*,(R.IdRol)as IdRol FROM Ct_Usuarios U LEFT JOIN Ct_Rol_Usuario R ON R.IdUsuario = U.Id WHERE U.Usuario = '" + pUsuario + "' and U.Estado = 1 ", ref pError);
                if (dtResultado.Rows.Count > 0)
                {
                    String pMD5Contrasena = dtResultado.Rows[0]["clave"].ToString();
                    String pMD5 = AccesoDB.GenerarMD5(pContrasena);
                    //if (!pMD5.Equals(pMD5Contrasena))
                    //{
                    //    dtResultado.Rows.Clear();
                    //}
                }
            }
            catch (Exception ex)
            {
                pError = ex.Message;
            }
            return dtResultado;
        }

        public Boolean insertar(String pConexion, cl_Usuarios pUsers, ref String pError)
        {
            pError = "";
            Boolean Resultado = true;
            string psql;

            ClassDB AccesoDB = new ClassDB();
            try
            {
                psql = "SET dateformat dmy INSERT INTO Ct_Usuarios ([usuario],[clave],[email],[nombre],[apellido],[identificacion],[Estado])  VALUES('" + pUsers._Usuario + "','" + AccesoDB.GenerarMD5(pUsers._Clave) + "','" + pUsers._Email + "','" + pUsers._Nombre + "','" + pUsers._Apellido + "','" + pUsers._Identificacion + "'," + pUsers._Estado + "); select @@identity";
                Int64 pIdReg = AccesoDB.SetInsertId(pConexion, psql, ref pError);
                if (!(pError.Trim().Equals("")))
                {
                    Resultado = false;
                }
            }
            catch (Exception ex)
            {
                pError = ex.Message;
                Resultado = false;

            }
            return Resultado;

        }

        public int insertarid(String pConexion, cl_Usuarios pUsers, ref String pError)
        {
            pError = "";
            int Resultado = 0;
            string psql;

            ClassDB AccesoDB = new ClassDB();
            try
            {
                psql = "SET dateformat dmy INSERT INTO Ct_Usuarios ([usuario],[clave],[email],[nombre],[apellido],[identificacion],[Estado])  VALUES('" + pUsers._Usuario + "','" + AccesoDB.GenerarMD5(pUsers._Clave) + "','" + pUsers._Email + "','" + pUsers._Nombre + "','" + pUsers._Apellido + "','" + pUsers._Identificacion + "'," + pUsers._Estado + "); select @@identity";
                Resultado = (int)AccesoDB.SetInsertId(pConexion, psql, ref pError);
                if (!(pError.Trim().Equals("")))
                {
                    Resultado = 0;
                }

            }
            catch (Exception ex)
            {
                pError = ex.Message;
                Resultado = 0;

            }
            return Resultado;

        }

        public Boolean Modificar(String pConexion, cl_Usuarios pUsers, ref String pError)
        {
            pError = "";
            Boolean Resultado = true;
            ClassDB AccesoDB = new ClassDB();
            try
            {
                AccesoDB.SetOperacion(pConexion, " UPDATE Ct_Usuarios SET usuario = '" + pUsers._Usuario + "' " + ((pUsers._Clave.Trim().Equals("")) ? "" : " ,clave = '" + AccesoDB.GenerarMD5(pUsers._Clave.Trim()) + "' ") + " ,email = '" + pUsers._Email + "',nombre = '" + pUsers._Nombre + "',apellido = '" + pUsers._Apellido + "',identificacion = '" + pUsers._Identificacion + "', Estado = " + pUsers._Estado + "  WHERE Id = " + pUsers._Id + " ", ref pError);
                if (!(pError.Trim().Equals("")))
                {
                    Resultado = false;
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                pError = ex.Message;
            }
            return Resultado;
        }


        public Boolean Eliminar(String pConexion, cl_Usuarios pUsers, ref String pError)
        {
            pError = "";
            Boolean Resultado = true;
            ClassDB AccesoDB = new ClassDB();
            try
            {
                AccesoDB.SetOperacion(pConexion, " DELETE FROM Ct_Usuarios WHERE Id = " + pUsers._Id + " ", ref pError);
                if (!(pError.Trim().Equals("")))
                {
                    Resultado = false;
                }
            }
            catch (Exception ex)
            {
                Resultado = false;
                pError = ex.Message;
            }
            return Resultado;
        }
        #endregion
    }
}
