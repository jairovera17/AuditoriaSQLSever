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
    }
}
