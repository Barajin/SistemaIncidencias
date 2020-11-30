namespace Sistema_Incidencias
{
    partial class FormIncidenciaDetalle
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
            this.dgvIncidencias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidencias)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIncidencias
            // 
            this.dgvIncidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncidencias.Location = new System.Drawing.Point(16, 32);
            this.dgvIncidencias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvIncidencias.Name = "dgvIncidencias";
            this.dgvIncidencias.RowHeadersWidth = 51;
            this.dgvIncidencias.Size = new System.Drawing.Size(1035, 352);
            this.dgvIncidencias.TabIndex = 0;
            this.dgvIncidencias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncidencias_CellContentClick);
            // 
            // FormIncidenciaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dgvIncidencias);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormIncidenciaDetalle";
            this.Text = "FormIncidenciaDetalle";
            this.Load += new System.EventHandler(this.FormIncidenciaDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidencias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIncidencias;
    }
}