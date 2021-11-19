
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.btnVerHorarios.Location = new System.Drawing.Point(585, 37);
            this.btnVerHorarios.Name = "btnVerHorarios";
            this.btnVerHorarios.Size = new System.Drawing.Size(115, 39);
            this.btnVerHorarios.TabIndex = 1;
            this.btnVerHorarios.Text = "Ver horarios";
            this.btnVerHorarios.UseVisualStyleBackColor = true;
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
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(169, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(428, 150);
            this.dataGridView1.TabIndex = 6;
            // 
            // frmCreacionHorarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbxSecciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVerHorarios);
            this.Controls.Add(this.btnCrearHorario);
            this.Name = "frmCreacionHorarios";
            this.Text = "Creación de horarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearHorario;
        private System.Windows.Forms.Button btnVerHorarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSecciones;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}