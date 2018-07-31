using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuditoriaFront
{
    class ConectarSQL
    {

        private string getConnectionString(string bdd_name)
        {
            string data_source = "DESKTOP-RSO768Q"; // nombre del servidor 
          
            string atributos = "Integrated Security=True"; //atributos adicionales

            string output = "Data Source = " + data_source +";";
            output +="Initial Catalog = "+ bdd_name + ";";
            output += atributos + ";";

            return output;
        }

        public string conectarSQL(string base_de_datos, string raw_sql)
        {
            string connection = getConnectionString(base_de_datos);
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand comando;
            SqlDataReader sql_data_reader;
            try
            {
                conn.Open();
                comando = new SqlCommand(raw_sql, conn);
                sql_data_reader = comando.ExecuteReader();
                string aux = "";
                while (sql_data_reader.Read())
                {
                    for (int x = 0; x<sql_data_reader.FieldCount;x++)
                    {
                        aux+= sql_data_reader.GetValue(x)+ "\t";
                    }
                    aux += "\n";
                }
                
                sql_data_reader.Close();
                comando.Dispose();
                conn.Close();
                return aux;
            }
            catch (Exception err)
            {
                
                MessageBox.Show("No se pudo conectar\n"+err.ToString());
                return null;
            }
        }
    }
}
