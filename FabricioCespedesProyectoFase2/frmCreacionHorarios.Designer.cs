
namespace FabricioCespedesProyectoFase2
{
    partial class frmCreacionHorarios
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
            this.btnCrearHorario = new System.Windows.Forms.Button();
            this.btnVerHorarios = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSecciones = new System.Windows.Forms.ComboBox();
            this.lvHorarios = new System.Windows.Forms.ListView();
            this.Leccion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Lunes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxEspecialidad = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCrearHorario
            // 
            this.btnCrearHorario.Location = new System.Drawing.Point(49, 37);
            this.btnCrearHorario.Name = "btnCrearHorario";
            this.btnCrearHorario.Size = new System.Drawing.Size(115, 39);
            this.btnCrearHorario.TabIndex = 0;
            this.btnCrearHorario.Text = "Crear horarios";
            this.btnCrearHorario.UseVisualStyleBackColor = true;
            this.btnCrearHorario.Click += new System.EventHandler(this.btnCrearHorario_Click);
            // 
            // btnVerHorarios
            // 
            this.btnVerHorarios.Location = new System.Drawing.Point(872, 34);
            this.btnVerHorarios.Name = "btnVerHorarios";
            this.btnVerHorarios.Size = new System.Drawing.Size(115, 39);
            this.btnVerHorarios.TabIndex = 1;
            this.btnVerHorarios.Text = "Ver horarios";
            this.btnVerHorarios.UseVisualStyleBackColor = true;
            this.btnVerHorarios.Click += new System.EventHandler(this.btnVerHorarios_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ingrese sección";
            // 
            // cbxSecciones
            // 
            this.cbxSecciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSecciones.FormattingEnabled = true;
            this.cbxSecciones.Items.AddRange(new object[] {
            "7-1",
            "7-2",
            "7-3",
            "7-4",
            "8-1",
            "8-2",
            "8-3",
            "9-1",
            "9-2",
            "10-1",
            "10-2",
            "11-1",
            "12-1"});
            this.cbxSecciones.Location = new System.Drawing.Point(308, 47);
            this.cbxSecciones.Name = "cbxSecciones";
            this.cbxSecciones.Size = new System.Drawing.Size(210, 21);
            this.cbxSecciones.TabIndex = 5;
            // 
            // lvHorarios
            // 
            this.lvHorarios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Leccion,
            this.Lunes,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvHorarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvHorarios.GridLines = true;
            this.lvHorarios.HideSelection = false;
            this.lvHorarios.Location = new System.Drawing.Point(30, 177);
            this.lvHorarios.Name = "lvHorarios";
            this.lvHorarios.Size = new System.Drawing.Size(1118, 541);
            this.lvHorarios.TabIndex = 6;
            this.lvHorarios.UseCompatibleStateImageBehavior = false;
            this.lvHorarios.View = System.Windows.Forms.View.Details;
            // 
            // Leccion
            // 
            this.Leccion.Text = "Leccion";
            this.Leccion.Width = 100;
            // 
            // Lunes
            // 
            this.Lunes.Text = "Lunes";
            this.Lunes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Lunes.Width = 200;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Martes";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Miercoles";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Jueves";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Viernes";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 200;
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(638, 44);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(201, 20);
            this.txtAnio.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(583, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Año";
            // 
            // cbxEspecialidad
            // 
            this.cbxEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEspecialidad.FormattingEnabled = true;
            this.cbxEspecialidad.Items.AddRange(new object[] {
            "A",
            "B"});
            this.cbxEspecialidad.Location = new System.Drawing.Point(308, 89);
            this.cbxEspecialidad.Name = "cbxEspecialidad";
            this.cbxEspecialidad.Size = new System.Drawing.Size(210, 21);
            this.cbxEspecialidad.TabIndex = 9;
            this.cbxEspecialidad.Visible = false;
            // 
            // frmCreacionHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 749);
            this.Controls.Add(this.cbxEspecialidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.lvHorarios);
            this.Controls.Add(this.cbxSecciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVerHorarios);
            this.Controls.Add(this.btnCrearHorario);
            this.Name = "frmCreacionHorarios";
            this.Text = "Creación de horarios";
            this.Load += new System.EventHandler(this.frmCreacionHorarios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearHorario;
        private System.Windows.Forms.Button btnVerHorarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSecciones;
        private System.Windows.Forms.ListView lvHorarios;
        private System.Windows.Forms.ColumnHeader Leccion;
        private System.Windows.Forms.ColumnHeader Lunes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxEspecialidad;
    }
}