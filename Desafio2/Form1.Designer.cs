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
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Sentido", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Recta", System.Windows.Forms.HorizontalAlignment.Left);
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFuncion
            // 
            this.txtFuncion.AllowDrop = true;
            this.txtFuncion.Location = new System.Drawing.Point(290, 72);
            this.txtFuncion.Name = "txtFuncion";
            this.txtFuncion.Size = new System.Drawing.Size(275, 26);
            this.txtFuncion.TabIndex = 0;
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(615, 62);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(168, 50);
            this.btnAnalizar.TabIndex = 1;
            this.btnAnalizar.Text = "Calcular asíntotas";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.Click += new System.EventHandler(this.btnAnalizar_Click_1);
            // 
            // lstVert
            // 
            this.lstVert.FormattingEnabled = true;
            this.lstVert.ItemHeight = 20;
            this.lstVert.Location = new System.Drawing.Point(40, 173);
            this.lstVert.Name = "lstVert";
            this.lstVert.Size = new System.Drawing.Size(355, 164);
            this.lstVert.TabIndex = 3;
            // 
            // lstHor
            // 
            this.lstHor.FormattingEnabled = true;
            this.lstHor.ItemHeight = 20;
            this.lstHor.Location = new System.Drawing.Point(422, 173);
            this.lstHor.Name = "lstHor";
            this.lstHor.Size = new System.Drawing.Size(347, 164);
            this.lstHor.TabIndex = 4;
            // 
            // lvObl
            // 
            listViewGroup5.Header = "Sentido";
            listViewGroup5.Name = "Sentido";
            listViewGroup6.Header = "Recta";
            listViewGroup6.Name = "Recta";
            this.lvObl.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup5,
            listViewGroup6});
            this.lvObl.HideSelection = false;
            this.lvObl.Location = new System.Drawing.Point(803, 173);
            this.lvObl.Name = "lvObl";
            this.lvObl.Size = new System.Drawing.Size(457, 164);
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
            this.label1.Location = new System.Drawing.Point(51, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ingrese la Funcion racional ƒ(x) =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Asíntotas verticales";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Asíntotas horizontales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(799, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Asíntotas oblicuas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Explicación del procedimiento";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1294, 650);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.rtxDetalle);
            this.Controls.Add(this.lvObl);
            this.Controls.Add(this.lstHor);
            this.Controls.Add(this.lstVert);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.txtFuncion);
            this.Name = "Form1";
            this.Text = "Desafio 2 - Analizador de Asíntotas (Funciones Racionales)";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

