﻿namespace AuditoriaFront
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.auditar_button = new System.Windows.Forms.Button();
			this.user_database_name_input = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.resultados_text_area = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.user_server_name_input = new System.Windows.Forms.TextBox();
			this.user_text_area_input = new System.Windows.Forms.RichTextBox();
			this.Guardar = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// auditar_button
			// 
			this.auditar_button.Location = new System.Drawing.Point(16, 141);
			this.auditar_button.Name = "auditar_button";
			this.auditar_button.Size = new System.Drawing.Size(75, 23);
			this.auditar_button.TabIndex = 0;
			this.auditar_button.Text = "Auditar";
			this.auditar_button.UseVisualStyleBackColor = true;
			this.auditar_button.Click += new System.EventHandler(this.Auditar_Button_Pressed);
			// 
			// user_database_name_input
			// 
			this.user_database_name_input.AccessibleName = "";
			this.user_database_name_input.Location = new System.Drawing.Point(119, 89);
			this.user_database_name_input.Name = "user_database_name_input";
			this.user_database_name_input.Size = new System.Drawing.Size(280, 22);
			this.user_database_name_input.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 92);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Base de Datos";
			// 
			// resultados_text_area
			// 
			this.resultados_text_area.Location = new System.Drawing.Point(15, 326);
			this.resultados_text_area.Name = "resultados_text_area";
			this.resultados_text_area.Size = new System.Drawing.Size(1012, 244);
			this.resultados_text_area.TabIndex = 3;
			this.resultados_text_area.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Servidor";
			// 
			// user_server_name_input
			// 
			this.user_server_name_input.AccessibleName = "";
			this.user_server_name_input.Location = new System.Drawing.Point(119, 46);
			this.user_server_name_input.Name = "user_server_name_input";
			this.user_server_name_input.Size = new System.Drawing.Size(280, 22);
			this.user_server_name_input.TabIndex = 5;
			// 
			// user_text_area_input
			// 
			this.user_text_area_input.Location = new System.Drawing.Point(15, 188);
			this.user_text_area_input.Name = "user_text_area_input";
			this.user_text_area_input.Size = new System.Drawing.Size(773, 112);
			this.user_text_area_input.TabIndex = 6;
			this.user_text_area_input.Text = "";
			// 
			// Guardar
			// 
			this.Guardar.Location = new System.Drawing.Point(396, 141);
			this.Guardar.Name = "Guardar";
			this.Guardar.Size = new System.Drawing.Size(75, 23);
			this.Guardar.TabIndex = 7;
			this.Guardar.Text = "Guardar";
			this.Guardar.UseVisualStyleBackColor = true;
			this.Guardar.Click += new System.EventHandler(this.guardar_resultados);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(148, 141);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "DBCC(3)";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.DBCC_Button_Pressed);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(272, 140);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "(1)";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(509, 140);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(111, 23);
			this.button3.TabIndex = 10;
			this.button3.Text = "PK existentes";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.pk_button_pressed);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(662, 141);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 11;
			this.button4.Text = "button4";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.relation_tables_button_pressed);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1039, 582);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Guardar);
			this.Controls.Add(this.user_text_area_input);
			this.Controls.Add(this.user_server_name_input);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.resultados_text_area);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.user_database_name_input);
			this.Controls.Add(this.auditar_button);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button auditar_button;
        private System.Windows.Forms.TextBox user_database_name_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox resultados_text_area;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox user_server_name_input;
        private System.Windows.Forms.RichTextBox user_text_area_input;
        private System.Windows.Forms.Button Guardar;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
	}
}

