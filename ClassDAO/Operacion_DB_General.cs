using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ClassDAO
{
   public class Operacion_DB_General
    {
        

        public DataTable Consultar_todo(String pConexion, ref String pError,String tabla,String Condicion="")
        {
            pError = "";
            DataTable dtResultado = new DataTable();
            ClassDB AccesoDB = new ClassDB();
            try
            {
                if(Condicion=="")
                dtResultado = AccesoDB.GetConsulta(pConexion, "SELECT * FROM " + tabla, ref pError);
                else
                dtResultado = AccesoDB.GetConsulta(pConexion, "SELECT * FROM " + tabla + " WHERE " + Condicion, ref pError);
            }
            catch (Exception ex)
            {
                pError = ex.Message;
            }
            return dtResultado;
        }
        public DataTable Consultar(String pConexion, ref String pError, String tabla,String Campos, String Condicion = "")
        {
            pError = "";
            DataTable dtResultado = new DataTable();
            ClassDB AccesoDB = new ClassDB();
            try
            {
                if (Condicion == "")
                    dtResultado = AccesoDB.GetConsulta(pConexion, "SELECT "+ Campos + " FROM " + tabla, ref pError);
                else
                    dtResultado = AccesoDB.GetConsulta(pConexion, "SELECT " + Campos + " FROM " + tabla + " WHERE " + Condicion, ref pError);
            }
            catch (Exception ex)
            {
                pError = ex.Message;
            }
            return dtResultado;
        }

        public Boolean insertar(String pConexion,String tabla, String campos,String valores, ref String pError)
        {
            pError = "";
            Boolean Resultado = true;
            string psql;

            ClassDB AccesoDB = new ClassDB();
            try
            {
                psql = "SET dateformat dmy INSERT INTO " + tabla + " ("+ campos + ") VALUES(" + valores + "); select @@identity";
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


        public Boolean Modificar(String pConexion, String tabla, String campo_valor, String condicion, ref String pError)
        {
            pError = "";
            Boolean Resultado = true;
            ClassDB AccesoDB = new ClassDB();
            try
            {
                AccesoDB.SetOperacion(pConexion, " UPDATE "+ tabla + " SET "+ campo_valor + "  WHERE " + condicion + " ", ref pError);
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


        public Boolean Eliminar(String pConexion, String tabla, String condicion, ref String pError)
        {
            pError = "";
            Boolean Resultado = true;
            ClassDB AccesoDB = new ClassDB();
            try
            {
                AccesoDB.SetOperacion(pConexion, " DELETE FROM "+ tabla + " WHERE  " + condicion + " ", ref pError);
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



    }
}
