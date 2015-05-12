using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace Control
{
    public class Conexion
    {
        #region Variables

        public SqlConnection cnx;
        public SqlDataAdapter adapter;
        public SqlCommand command;
        public string strConection = "";

        #endregion

        #region Metodos

        //Abre la conexion con la base de datos
        public void Abrir_Conexion(string path,string usuario)
        {
            try
            {
                cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["BDconnectionString"].ConnectionString);
                cnx.Open();
            }
            catch (SqlException sqlError) 
            {
            }
        }

        //Cierra la conexion con la base de datos
        public void Cerrar_Conexion()
        {
            this.cnx.Close();
        }

        //Insert - Update - Delete
        public bool Crud(string sql,string path,string usuario)
        {
            try
            {
                command = new SqlCommand(sql, this.cnx);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException sqlError) 
            {
                return false; 
            }
        }

        //Select sobre la base datos
        public DataTable Select(string sql, string path, string usuario)
        {
            try
            {
                DataSet dataSet = new DataSet();
                adapter = new SqlDataAdapter(sql, this.cnx);
                adapter.Fill(dataSet);
                return dataSet.Tables[0];
            }
            catch (SqlException sqlError) 
            {
                return null; 
            }
        }

        #endregion
    }
}
