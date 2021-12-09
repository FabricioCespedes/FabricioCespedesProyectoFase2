
namespace FabricioCespedesProyectoFase2
{
    partial class frmAsistencia
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbxSecciones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegistrarAsistencias = new System.Windows.Forms.Button();
            this.btnVerAsistencia = new System.Windows.Forms.Button();
            this.dgvEstudiantes = new System.Windows.Forms.DataGridView();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cbxMateria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxLecciones = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Ingrese el año de asistencia";
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
            this.cbxSecciones.Location = new System.Drawing.Point(223, 44);
            this.cbxSecciones.Name = "cbxSecciones";
            this.cbxSecciones.Size = new System.Drawing.Size(233, 21);
            this.cbxSecciones.TabIndex = 14;
            this.cbxSecciones.SelectedIndexChanged += new System.EventHandler(this.cbxSecciones_SelectedIndexChanged);
            this.cbxSecciones.ValueMemberChanged += new System.EventHandler(this.cbxSecciones_ValueMemberChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ingrese sección";
            // 
            // btnRegistrarAsistencias
            // 
            this.btnRegistrarAsistencias.Enabled = false;
            this.btnRegistrarAsistencias.Location = new System.Drawing.Point(867, 47);
            this.btnRegistrarAsistencias.Name = "btnRegistrarAsistencias";
            this.btnRegistrarAsistencias.Size = new System.Drawing.Size(115, 22);
            this.btnRegistrarAsistencias.TabIndex = 11;
            this.btnRegistrarAsistencias.Text = "Registrar asistencia";
            this.btnRegistrarAsistencias.UseVisualStyleBackColor = true;
            this.btnRegistrarAsistencias.Click += new System.EventHandler(this.btnRegistrarAsistencias_Click);
            // 
            // btnVerAsistencia
            // 
            this.btnVerAsistencia.Enabled = false;
            this.btnVerAsistencia.Location = new System.Drawing.Point(867, 18);
            this.btnVerAsistencia.Name = "btnVerAsistencia";
            this.btnVerAsistencia.Size = new System.Drawing.Size(115, 24);
            this.btnVerAsistencia.TabIndex = 18;
            this.btnVerAsistencia.Text = "Ver asistencia";
            this.btnVerAsistencia.UseVisualStyleBackColor = true;
            this.btnVerAsistencia.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvEstudiantes
            // 
            this.dgvEstudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstudiantes.Location = new System.Drawing.Point(44, 101);
            this.dgvEstudiantes.Name = "dgvEstudiantes";
            this.dgvEstudiantes.Size = new System.Drawing.Size(938, 209);
            this.dgvEstudiantes.TabIndex = 19;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(223, 18);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(233, 20);
            this.dtpFecha.TabIndex = 21;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // cbxMateria
            // 
            this.cbxMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMateria.Enabled = false;
            this.cbxMateria.FormattingEnabled = true;
            this.cbxMateria.Location = new System.Drawing.Point(602, 18);
            this.cbxMateria.Name = "cbxMateria";
            this.cbxMateria.Size = new System.Drawing.Size(232, 21);
            this.cbxMateria.TabIndex = 22;
            this.cbxMateria.SelectedIndexChanged += new System.EventHandler(this.cbxMateria_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(502, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Ingrese materia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Ingrese lección";
            // 
            // cbxLecciones
            // 
            this.cbxLecciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLecciones.Enabled = false;
            this.cbxLecciones.FormattingEnabled = true;
            this.cbxLecciones.Location = new System.Drawing.Point(602, 52);
            this.cbxLecciones.Name = "cbxLecciones";
            this.cbxLecciones.Size = new System.Drawing.Size(232, 21);
            this.cbxLecciones.TabIndex = 25;
            // 
            // frmAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 450);
            this.Controls.Add(this.cbxLecciones);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxMateria);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.dgvEstudiantes);
            this.Controls.Add(this.btnVerAsistencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxSecciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegistrarAsistencias);
            this.Name = "frmAsistencia";
            this.Text = "frmAsistencia";
            this.Load += new System.EventHandler(this.frmAsistencia_Load);
            this.TextChanged += new System.EventHandler(this.frmAsistencia_TextChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxSecciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistrarAsistencias;
        private System.Windows.Forms.Button btnVerAsistencia;
        private System.Windows.Forms.DataGridView dgvEstudiantes;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cbxMateria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxLecciones;
    }
}