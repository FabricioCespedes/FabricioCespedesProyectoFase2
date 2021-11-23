
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
            System.Windows.Forms.ColumnHeader Leccion;
            this.btnCrearHorario = new System.Windows.Forms.Button();
            this.btnVerHorarios = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSecciones = new System.Windows.Forms.ComboBox();
            this.lvHorarios = new System.Windows.Forms.ListView();
            this.colLunes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMartes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMiercoles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJueves = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colViernes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxEspecialidad = new System.Windows.Forms.ComboBox();
            this.btnBorrarHorarios = new System.Windows.Forms.Button();
            Leccion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Leccion
            // 
            Leccion.Text = "Leccion";
            Leccion.Width = 100;
            // 
            // btnCrearHorario
            // 
            this.btnCrearHorario.Location = new System.Drawing.Point(516, 17);
            this.btnCrearHorario.Name = "btnCrearHorario";
            this.btnCrearHorario.Size = new System.Drawing.Size(115, 24);
            this.btnCrearHorario.TabIndex = 0;
            this.btnCrearHorario.Text = "Crear horarios";
            this.btnCrearHorario.UseVisualStyleBackColor = true;
            this.btnCrearHorario.Click += new System.EventHandler(this.btnCrearHorario_Click);
            // 
            // btnVerHorarios
            // 
            this.btnVerHorarios.Location = new System.Drawing.Point(516, 51);
            this.btnVerHorarios.Name = "btnVerHorarios";
            this.btnVerHorarios.Size = new System.Drawing.Size(115, 24);
            this.btnVerHorarios.TabIndex = 1;
            this.btnVerHorarios.Text = "Ver horarios";
            this.btnVerHorarios.UseVisualStyleBackColor = true;
            this.btnVerHorarios.Click += new System.EventHandler(this.btnVerHorarios_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 54);
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
            this.cbxSecciones.Location = new System.Drawing.Point(160, 51);
            this.cbxSecciones.Name = "cbxSecciones";
            this.cbxSecciones.Size = new System.Drawing.Size(188, 21);
            this.cbxSecciones.TabIndex = 5;
            // 
            // lvHorarios
            // 
            this.lvHorarios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            Leccion,
            this.colLunes,
            this.colMartes,
            this.colMiercoles,
            this.colJueves,
            this.colViernes});
            this.lvHorarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvHorarios.GridLines = true;
            this.lvHorarios.HideSelection = false;
            this.lvHorarios.Location = new System.Drawing.Point(12, 95);
            this.lvHorarios.Name = "lvHorarios";
            this.lvHorarios.Size = new System.Drawing.Size(1360, 642);
            this.lvHorarios.TabIndex = 6;
            this.lvHorarios.UseCompatibleStateImageBehavior = false;
            this.lvHorarios.View = System.Windows.Forms.View.Details;
            this.lvHorarios.VirtualListSize = 3;
            this.lvHorarios.SelectedIndexChanged += new System.EventHandler(this.lvHorarios_SelectedIndexChanged);
            // 
            // colLunes
            // 
            this.colLunes.Text = "Lunes";
            this.colLunes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLunes.Width = 250;
            // 
            // colMartes
            // 
            this.colMartes.Text = "Martes";
            this.colMartes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colMartes.Width = 250;
            // 
            // colMiercoles
            // 
            this.colMiercoles.Text = "Miercoles";
            this.colMiercoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colMiercoles.Width = 250;
            // 
            // colJueves
            // 
            this.colJueves.Text = "Jueves";
            this.colJueves.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colJueves.Width = 250;
            // 
            // colViernes
            // 
            this.colViernes.Text = "Viernes";
            this.colViernes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colViernes.Width = 250;
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(289, 17);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(201, 20);
            this.txtAnio.TabIndex = 7;
            this.txtAnio.Text = "2021";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(244, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ingrese año para crear horarios y para ver horarios";
            // 
            // cbxEspecialidad
            // 
            this.cbxEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEspecialidad.FormattingEnabled = true;
            this.cbxEspecialidad.Items.AddRange(new object[] {
            "A",
            "B"});
            this.cbxEspecialidad.Location = new System.Drawing.Point(354, 50);
            this.cbxEspecialidad.Name = "cbxEspecialidad";
            this.cbxEspecialidad.Size = new System.Drawing.Size(136, 21);
            this.cbxEspecialidad.TabIndex = 9;
            this.cbxEspecialidad.Visible = false;
            // 
            // btnBorrarHorarios
            // 
            this.btnBorrarHorarios.Location = new System.Drawing.Point(646, 17);
            this.btnBorrarHorarios.Name = "btnBorrarHorarios";
            this.btnBorrarHorarios.Size = new System.Drawing.Size(115, 24);
            this.btnBorrarHorarios.TabIndex = 10;
            this.btnBorrarHorarios.Text = "Borrar horarios";
            this.btnBorrarHorarios.UseVisualStyleBackColor = true;
            this.btnBorrarHorarios.Click += new System.EventHandler(this.btnBorrarHorarios_Click);
            // 
            // frmCreacionHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.btnBorrarHorarios);
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.ColumnHeader colLunes;
        private System.Windows.Forms.ColumnHeader colMartes;
        private System.Windows.Forms.ColumnHeader colMiercoles;
        private System.Windows.Forms.ColumnHeader colJueves;
        private System.Windows.Forms.ColumnHeader colViernes;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxEspecialidad;
        private System.Windows.Forms.Button btnBorrarHorarios;
    }
}