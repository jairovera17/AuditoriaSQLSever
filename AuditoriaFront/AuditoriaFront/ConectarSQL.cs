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
		private string auditSQL = @"
if not exists (select * from sysobjects where name='ARef_Integrity' and xtype='U')CREATE TABLE  ARef_Integrity (
    id int IDENTITY(1,1) PRIMARY KEY,
	TableName		varchar(50)	NOT NULL,
    ForeignKeyName	varchar(50)	NOT NULL,
	FK_Value	varchar(50)	NOT NULL,
    TableNameReference		varchar(50)	NOT NULL,
    Details		varchar(50)	NOT NULL
) 
--SCRIPTTTTTTTTTTTTTTTTTTTTTTTTT

Declare @ForeignKeyName nvarchar(128),
		@TableName nvarchar(128),
		@FKColumnName nvarchar(128),
		@ReferenceTableName nvarchar(128),
		@ReferenceColumnName nvarchar(128),
		@sql nvarchar(4000)

Declare ForeignKeys cursor GLOBAL
FOR SELECT fk.name,
       OBJECT_NAME(fk.parent_object_id),
       COL_NAME(fc.parent_object_id, fc.parent_column_id),
       OBJECT_NAME(fk.referenced_object_id),
       COL_NAME(fc.referenced_object_id, fc.referenced_column_id)
FROM sys.foreign_keys AS fk
INNER JOIN sys.foreign_key_columns AS fc ON fk.OBJECT_ID = fc.constraint_object_id


Open ForeignKeys
FETCH NEXT FROM ForeignKeys INTO @ForeignKeyName, @TableName, @FKColumnName, @ReferenceTableName, @ReferenceColumnName
while(@@fetch_status= 0)
begin
--

SET @SQL = N'
Declare @FK_Value varchar(128)
Declare orphanElements cursor local static
FOR SELECT['+@FKColumnName+'] FROM['+@TableName+'] WHERE['+@FKColumnName+'] NOT IN(SELECT['+@ReferenceColumnName+'] FROM ['+@ReferenceTableName+'])


Open orphanElements
--fetch ForeignKeys into @FK_Value
FETCH NEXT FROM orphanElements INTO @FK_Value
while(@@fetch_status=0)
begin
--

insert ARef_Integrity values('''+ @TableName + ''','''+@ForeignKeyName+''', @FK_Value,'''+@ReferenceTableName+''','' error'')


FETCH NEXT FROM orphanElements INTO @FK_Value
--
end
close orphanElements
'

EXEC sp_executesql @SQL
    
--
FETCH NEXT FROM ForeignKeys INTO @ForeignKeyName, @TableName, @FKColumnName, @ReferenceTableName, @ReferenceColumnName
--
end
close ForeignKeys
deallocate ForeignKeys

select* from ARef_Integrity ";



		private string getConnectionString(string bdd_name)
        {
            string data_source = "DESKTOP-F4SKCA1"; // nombre del servidor 
          
            string atributos = "Integrated Security=True"; //atributos adicionales

            string output = "Data Source = " + data_source +";";
            output +="Initial Catalog = "+ bdd_name + ";";
            output += atributos + ";";

            return output;
        }

		public string auditarbase (string base_de_datos,string raw_sql)
		{
			return ejecutarComando(base_de_datos, auditSQL);
		}

		public List<string> getIR(String base_de_datos, string raw_sql)
		{
			
			return setParsing(base_de_datos, raw_sql);
		}

		public int getFK(String base_de_datos,string raw_sql)
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
				int aux=0;
				while (sql_data_reader.Read())
				{
					for (int x = 0; x < sql_data_reader.FieldCount; x++)
					{
						aux += Int32.Parse( sql_data_reader.GetValue(x)+"");
					}
		
				}

				sql_data_reader.Close();
				comando.Dispose();
				conn.Close();
				return aux;
			}
			catch (Exception err)
			{

				MessageBox.Show("No se pudo conectar\n" + err.ToString());
				return 0;
			}

		}
		public List<string> getColName(String base_de_datos,string table_name)
		{
			string TN = @"select COLUMN_NAME
from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + table_name + "'";
			return setParsing(base_de_datos,TN);

		}

		public string chequeoBase (string base_de_datos, string raw_sql)
		{
			string dbcc_sql = "DBCC CHECKDB ([" + base_de_datos + "]) with tableresults";
			return ejecutarComando(base_de_datos, dbcc_sql);
		}

        public string ejecutarComando(string base_de_datos, string raw_sql)
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
                        aux+= sql_data_reader.GetValue(x)+ "  ,  ";
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
		public List<string> setParsing(string base_de_datos, string raw_sql)
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
				List<string> lista = new List<string>();
				
				while (sql_data_reader.Read())
				{
					for (int x = 0; x < sql_data_reader.FieldCount; x++)
					{
						lista.Add( sql_data_reader.GetValue(x)+"");
						

					}
					

				}

				sql_data_reader.Close();
				comando.Dispose();
				conn.Close();
				return lista;
			}
			catch (Exception err)
			{

				MessageBox.Show("No se pudo conectar\n" + err.ToString());
				return null;
			}
		}

		public int getMatch(String base_de_datos,string table_name,string col_name)
		{
			string query = @"select count(*)
							from INFORMATION_SCHEMA.COLUMNS
							WHERE TABLE_NAME = '"+table_name+"' and COLUMN_NAME = '"+col_name+"'";
			string connection = getConnectionString(base_de_datos);
			SqlConnection conn = new SqlConnection(connection);
			SqlCommand comando;
			SqlDataReader sql_data_reader;
			try
			{
				conn.Open();
				comando = new SqlCommand(query, conn);
				sql_data_reader = comando.ExecuteReader();
				int aux = 0;
				while (sql_data_reader.Read())
				{
					for (int x = 0; x < sql_data_reader.FieldCount; x++)
					{
						aux += Int32.Parse(sql_data_reader.GetValue(x) + "");
					}

				}

				sql_data_reader.Close();
				comando.Dispose();
				conn.Close();
				return aux;
			}
			catch (Exception err)
			{

				MessageBox.Show("No se pudo conectar\n" + err.ToString());
				return 0;
			}
		}
	}
}
