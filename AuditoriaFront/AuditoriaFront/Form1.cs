using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuditoriaFront
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

   
        private void Auditar_Button_Pressed(object sender, EventArgs e) //conecta a sql server y ejecuta el comando del text area - deja cerrada la conexion
        {
            ConectarSQL conectar = new ConectarSQL();


			//DialogResult dialogResult = MessageBox.Show("query",sql);
			//user_text_area_input.Text
			string headers = "";

			resultados_text_area.Text = conectar.auditarbase(user_database_name_input.Text, user_text_area_input.Text);
			
			//Console.WriteLine(sql);
       
        }

        private void guardar_resultados(object sender, EventArgs e) // confirmar el guardado de resultados
        {
            DialogResult dialogResult = MessageBox.Show("Guardar Resultados?", "Guardar Resultados", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                crear_archivos_resultados();
            }
        }
        private void crear_archivos_resultados() //imprime el texto del resultados text area en un txt 
        {
            string file_name = "\\RESULTADOS_AUDITORIA.csv";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dialogResult = fbd.ShowDialog();
            if(dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string final_path = fbd.SelectedPath + file_name;
                if (File.Exists(final_path))
                {
                    File.Delete(final_path);
                }
                FileStream fs = File.Create(final_path);
                StreamWriter fw = new StreamWriter(fs);
 
                String[] cadena = resultados_text_area.Text.Split('\n');
                foreach (string frase in cadena)
                {
                        fw.WriteLine(frase);
                
                }
                fw.Close();
                fs.Close();
                MessageBox.Show("Archivo guardado");
               
            }
        }

		private void DBCC_Button_Pressed(object sender, EventArgs e)
		{

			ConectarSQL conectar = new ConectarSQL();
			string headers = "Error,Level,State,MessageText,ReapirLevel,Status,DBLD,DBFragID,ObjectID,IndexID,PartitionID,AllocUnitId,RidDBLD,RidPruld,File,Page,Slot,RefDbld,RefPruld,RedFile,RefPage,RefSlot,Allocation\n";
			string result = conectar.chequeoBase(user_database_name_input.Text, user_text_area_input.Text);
			resultados_text_area.Text = headers + result;


		}
	}
}
