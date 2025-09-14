namespace Desafio2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Sentido", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Recta", System.Windows.Forms.HorizontalAlignment.Left);
            this.txtFuncion = new System.Windows.Forms.TextBox();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.lstVert = new System.Windows.Forms.ListBox();
            this.lstHor = new System.Windows.Forms.ListBox();
            this.lvObl = new System.Windows.Forms.ListView();
            this.rtxDetalle = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFuncion
            // 
            this.txtFuncion.AllowDrop = true;
            this.txtFuncion.Location = new System.Drawing.Point(217, 83);
            this.txtFuncion.Name = "txtFuncion";
            this.txtFuncion.Size = new System.Drawing.Size(275, 26);
            this.txtFuncion.TabIndex = 0;
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(570, 73);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(140, 47);
            this.btnAnalizar.TabIndex = 1;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            // 
            // lstVert
            // 
            this.lstVert.FormattingEnabled = true;
            this.lstVert.ItemHeight = 20;
            this.lstVert.Location = new System.Drawing.Point(40, 156);
            this.lstVert.Name = "lstVert";
            this.lstVert.Size = new System.Drawing.Size(355, 164);
            this.lstVert.TabIndex = 3;
            // 
            // lstHor
            // 
            this.lstHor.FormattingEnabled = true;
            this.lstHor.ItemHeight = 20;
            this.lstHor.Location = new System.Drawing.Point(420, 156);
            this.lstHor.Name = "lstHor";
            this.lstHor.Size = new System.Drawing.Size(347, 164);
            this.lstHor.TabIndex = 4;
            // 
            // lvObl
            // 
            listViewGroup1.Header = "Sentido";
            listViewGroup1.Name = "Sentido";
            listViewGroup2.Header = "Recta";
            listViewGroup2.Name = "Recta";
            this.lvObl.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.lvObl.HideSelection = false;
            this.lvObl.Location = new System.Drawing.Point(803, 156);
            this.lvObl.Name = "lvObl";
            this.lvObl.Size = new System.Drawing.Size(457, 157);
            this.lvObl.TabIndex = 5;
            this.lvObl.UseCompatibleStateImageBehavior = false;
            this.lvObl.SelectedIndexChanged += new System.EventHandler(this.lvObl_SelectedIndexChanged);
            // 
            // rtxDetalle
            // 
            this.rtxDetalle.Location = new System.Drawing.Point(40, 402);
            this.rtxDetalle.Name = "rtxDetalle";
            this.rtxDetalle.Size = new System.Drawing.Size(1220, 188);
            this.rtxDetalle.TabIndex = 6;
            this.rtxDetalle.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 618);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1294, 32);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AccessibleName = "lblStatus";
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1279, 25);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Listo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "F(x)=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 650);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.rtxDetalle);
            this.Controls.Add(this.lvObl);
            this.Controls.Add(this.lstHor);
            this.Controls.Add(this.lstVert);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.txtFuncion);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFuncion;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.ListBox lstVert;
        private System.Windows.Forms.ListBox lstHor;
        private System.Windows.Forms.ListView lvObl;
        private System.Windows.Forms.RichTextBox rtxDetalle;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
    }
}

