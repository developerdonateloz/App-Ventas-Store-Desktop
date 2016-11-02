using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace App_Ventas
{

    public class Persona
    {
        string ventasConexion = ConfigurationManager.ConnectionStrings["ventasConexion"].ConnectionString;

        public int CrearPersona(string codigo, string nombre, string appaterno, string apmaterno, string usuario, string contrasenia)
        {
            int id = 0;
            using (SqlConnection oConexion = new SqlConnection(ventasConexion))
            {
                SqlCommand myCommand = new SqlCommand();
                myCommand.CommandText = "[crearpersona]";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Connection = oConexion;


                myCommand.Parameters.Add(new SqlParameter("@codigo", SqlDbType.NVarChar, 10));
                myCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar, 50));
                myCommand.Parameters.Add(new SqlParameter("@appaterno", SqlDbType.NVarChar, 50));
                myCommand.Parameters.Add(new SqlParameter("@apmaterno", SqlDbType.NVarChar, 50));
                myCommand.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 50));
                myCommand.Parameters.Add(new SqlParameter("@contrasenia", SqlDbType.VarChar, 32));

                myCommand.Parameters["@codigo"].Value = codigo;
                myCommand.Parameters["@nombre"].Value = nombre;
                myCommand.Parameters["@appaterno"].Value = appaterno;
                myCommand.Parameters["@apmaterno"].Value = apmaterno;

                if (usuario == string.Empty)
                    myCommand.Parameters["@usuario"].Value = DBNull.Value;
                else
                    myCommand.Parameters["@usuario"].Value = usuario;

                if (contrasenia == string.Empty)
                    myCommand.Parameters["@contrasenia"].Value = DBNull.Value;
                else
                    myCommand.Parameters["@contrasenia"].Value = Util.EncriptarMD5(contrasenia);

                oConexion.Open();
                id = Convert.ToInt32(myCommand.ExecuteScalar());
                oConexion.Close();
            }

            return id;
        }
        public DataTable BuscarPersonas(string dato)
        {
            DataTable oData = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(ventasConexion))
            {
                SqlCommand oComando = new SqlCommand();
                SqlDataAdapter myadaptador = new SqlDataAdapter();

                oComando.CommandText = "[BuscarPersonas]";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Connection = oConexion;

                oComando.Parameters.Add(new SqlParameter("@dato", SqlDbType.NVarChar, 50));

                oComando.Parameters["@dato"].Value = dato;

                oConexion.Open();
                myadaptador.SelectCommand = oComando;
                myadaptador.Fill(oData);
                oConexion.Close();
            }

            return oData;
        }
    }
}
