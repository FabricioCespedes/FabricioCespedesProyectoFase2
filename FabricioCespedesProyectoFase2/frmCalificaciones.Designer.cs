
namespace FabricioCespedesProyectoFase2
{
    partial class frmCalificaciones
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbxProfesores = new System.Windows.Forms.ComboBox();
            this.dgvEstudiantes = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxSecciones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxMaterias = new System.Windows.Forms.ComboBox();
            this.numAnio = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Ingrese profesor";
            // 
            // cbxProfesores
            // 
            this.cbxProfesores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProfesores.FormattingEnabled = true;
            this.cbxProfesores.Location = new System.Drawing.Point(581, 61);
            this.cbxProfesores.Name = "cbxProfesores";
            this.cbxProfesores.Size = new System.Drawing.Size(232, 21);
            this.cbxProfesores.TabIndex = 33;
            this.cbxProfesores.SelectedIndexChanged += new System.EventHandler(this.cbxProfesores_SelectedIndexChanged);
            // 
            // dgvEstudiantes
            // 
            this.dgvEstudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstudiantes.Location = new System.Drawing.Point(48, 120);
            this.dgvEstudiantes.Name = "dgvEstudiantes";
            this.dgvEstudiantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstudiantes.Size = new System.Drawing.Size(901, 209);
            this.dgvEstudiantes.TabIndex = 31;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(834, 59);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(115, 24);
            this.btnEliminar.TabIndex = 30;
            this.btnEliminar.Text = "Ver calificaciones";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 29;
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
            this.cbxSecciones.Location = new System.Drawing.Point(190, 62);
            this.cbxSecciones.Name = "cbxSecciones";
            this.cbxSecciones.Size = new System.Drawing.Size(233, 21);
            this.cbxSecciones.TabIndex = 28;
            this.cbxSecciones.SelectedIndexChanged += new System.EventHandler(this.cbxSecciones_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Ingrese sección";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Enabled = false;
            this.btnRegistrar.Location = new System.Drawing.Point(834, 31);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(115, 22);
            this.btnRegistrar.TabIndex = 26;
            this.btnRegistrar.Text = "Registrar calificación";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Ingrese materia";
            // 
            // cbxMaterias
            // 
            this.cbxMaterias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMaterias.FormattingEnabled = true;
            this.cbxMaterias.Location = new System.Drawing.Point(581, 34);
            this.cbxMaterias.Name = "cbxMaterias";
            this.cbxMaterias.Size = new System.Drawing.Size(232, 21);
            this.cbxMaterias.TabIndex = 35;
            this.cbxMaterias.SelectedIndexChanged += new System.EventHandler(this.cbxMaterias_SelectedIndexChanged);
            // 
            // numAnio
            // 
            this.numAnio.Location = new System.Drawing.Point(190, 34);
            this.numAnio.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numAnio.Minimum = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.numAnio.Name = "numAnio";
            this.numAnio.Size = new System.Drawing.Size(233, 20);
            this.numAnio.TabIndex = 37;
            this.numAnio.Value = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            // 
            // frmCalificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 450);
            this.Controls.Add(this.numAnio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxMaterias);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxProfesores);
            this.Controls.Add(this.dgvEstudiantes);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxSecciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegistrar);
            this.Name = "frmCalificaciones";
            this.Text = "frmCalificaciones";
            this.Load += new System.EventHandler(this.frmCalificaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudiantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxProfesores;
        private System.Windows.Forms.DataGridView dgvEstudiantes;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxSecciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxMaterias;
        private System.Windows.Forms.NumericUpDown numAnio;
    }
}