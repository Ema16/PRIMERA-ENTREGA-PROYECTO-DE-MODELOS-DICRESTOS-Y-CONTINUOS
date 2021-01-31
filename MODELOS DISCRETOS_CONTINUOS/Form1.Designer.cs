namespace MODELOS_DISCRETOS_CONTINUOS
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtP = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.errorN = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorP = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorX = new System.Windows.Forms.ErrorProvider(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.txtX2 = new System.Windows.Forms.TextBox();
            this.txtX5 = new System.Windows.Forms.TextBox();
            this.txtX6 = new System.Windows.Forms.TextBox();
            this.txtX3 = new System.Windows.Forms.TextBox();
            this.txtX4 = new System.Windows.Forms.TextBox();
            this.radioX = new System.Windows.Forms.RadioButton();
            this.radioX1 = new System.Windows.Forms.RadioButton();
            this.radioX2 = new System.Windows.Forms.RadioButton();
            this.radioX3 = new System.Windows.Forms.RadioButton();
            this.radioX4 = new System.Windows.Forms.RadioButton();
            this.radioX5 = new System.Windows.Forms.RadioButton();
            this.labelRes = new System.Windows.Forms.Label();
            this.listRespuestas = new System.Windows.Forms.ListBox();
            this.radioX7 = new System.Windows.Forms.RadioButton();
            this.txtX7 = new System.Windows.Forms.TextBox();
            this.txtX8 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPoblacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "N (numero de eventos)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "P (probabilidad de exito)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "X (numero de exito)";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(204, 21);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(100, 20);
            this.txtN.TabIndex = 3;
            this.txtN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtN_KeyPress);
            this.txtN.Validated += new System.EventHandler(this.textN_Validated);
            // 
            // txtP
            // 
            this.txtP.Location = new System.Drawing.Point(204, 54);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(100, 20);
            this.txtP.TabIndex = 4;
            this.txtP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtP.Validated += new System.EventHandler(this.textP_Validated);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(407, 30);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(30, 20);
            this.txtX.TabIndex = 5;
            this.txtX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtX_KeyPress);
            this.txtX.Validated += new System.EventHandler(this.textX_Validated);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorN
            // 
            this.errorN.ContainerControl = this;
            // 
            // errorP
            // 
            this.errorP.ContainerControl = this;
            // 
            // errorX
            // 
            this.errorX.ContainerControl = this;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 162);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(998, 396);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(408, 54);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(27, 20);
            this.txtX1.TabIndex = 11;
            // 
            // txtX2
            // 
            this.txtX2.Location = new System.Drawing.Point(408, 83);
            this.txtX2.Name = "txtX2";
            this.txtX2.Size = new System.Drawing.Size(27, 20);
            this.txtX2.TabIndex = 12;
            // 
            // txtX5
            // 
            this.txtX5.Location = new System.Drawing.Point(536, 47);
            this.txtX5.Name = "txtX5";
            this.txtX5.Size = new System.Drawing.Size(27, 20);
            this.txtX5.TabIndex = 16;
            // 
            // txtX6
            // 
            this.txtX6.Location = new System.Drawing.Point(536, 79);
            this.txtX6.Name = "txtX6";
            this.txtX6.Size = new System.Drawing.Size(27, 20);
            this.txtX6.TabIndex = 17;
            // 
            // txtX3
            // 
            this.txtX3.Location = new System.Drawing.Point(353, 122);
            this.txtX3.Name = "txtX3";
            this.txtX3.Size = new System.Drawing.Size(19, 20);
            this.txtX3.TabIndex = 18;
            // 
            // txtX4
            // 
            this.txtX4.Location = new System.Drawing.Point(378, 123);
            this.txtX4.Name = "txtX4";
            this.txtX4.Size = new System.Drawing.Size(23, 20);
            this.txtX4.TabIndex = 19;
            // 
            // radioX
            // 
            this.radioX.AutoSize = true;
            this.radioX.Location = new System.Drawing.Point(353, 33);
            this.radioX.Name = "radioX";
            this.radioX.Size = new System.Drawing.Size(48, 17);
            this.radioX.TabIndex = 20;
            this.radioX.TabStop = true;
            this.radioX.Text = "P(X=";
            this.radioX.UseVisualStyleBackColor = true;
            this.radioX.CheckedChanged += new System.EventHandler(this.radioX_CheckedChanged);
            // 
            // radioX1
            // 
            this.radioX1.AutoSize = true;
            this.radioX1.Location = new System.Drawing.Point(350, 57);
            this.radioX1.Name = "radioX1";
            this.radioX1.Size = new System.Drawing.Size(48, 17);
            this.radioX1.TabIndex = 21;
            this.radioX1.TabStop = true;
            this.radioX1.Text = "P(X>";
            this.radioX1.UseVisualStyleBackColor = true;
            this.radioX1.CheckedChanged += new System.EventHandler(this.radioX1_CheckedChanged);
            // 
            // radioX2
            // 
            this.radioX2.AutoSize = true;
            this.radioX2.Location = new System.Drawing.Point(350, 80);
            this.radioX2.Name = "radioX2";
            this.radioX2.Size = new System.Drawing.Size(48, 17);
            this.radioX2.TabIndex = 22;
            this.radioX2.TabStop = true;
            this.radioX2.Text = "P(X<";
            this.radioX2.UseVisualStyleBackColor = true;
            this.radioX2.CheckedChanged += new System.EventHandler(this.radioX2_CheckedChanged);
            // 
            // radioX3
            // 
            this.radioX3.AutoSize = true;
            this.radioX3.Location = new System.Drawing.Point(279, 123);
            this.radioX3.Name = "radioX3";
            this.radioX3.Size = new System.Drawing.Size(62, 17);
            this.radioX3.TabIndex = 23;
            this.radioX3.TabStop = true;
            this.radioX3.Text = "P(   ≤   )";
            this.radioX3.UseVisualStyleBackColor = true;
            this.radioX3.CheckedChanged += new System.EventHandler(this.radioX3_CheckedChanged);
            // 
            // radioX4
            // 
            this.radioX4.AutoSize = true;
            this.radioX4.Location = new System.Drawing.Point(484, 48);
            this.radioX4.Name = "radioX4";
            this.radioX4.Size = new System.Drawing.Size(46, 17);
            this.radioX4.TabIndex = 24;
            this.radioX4.TabStop = true;
            this.radioX4.Text = "P(x≥";
            this.radioX4.UseVisualStyleBackColor = true;
            this.radioX4.CheckedChanged += new System.EventHandler(this.radioX4_CheckedChanged);
            // 
            // radioX5
            // 
            this.radioX5.AutoSize = true;
            this.radioX5.Location = new System.Drawing.Point(479, 82);
            this.radioX5.Name = "radioX5";
            this.radioX5.Size = new System.Drawing.Size(51, 17);
            this.radioX5.TabIndex = 25;
            this.radioX5.TabStop = true;
            this.radioX5.Text = "P(X ≤";
            this.radioX5.UseVisualStyleBackColor = true;
            this.radioX5.CheckedChanged += new System.EventHandler(this.radioX5_CheckedChanged);
            // 
            // labelRes
            // 
            this.labelRes.AutoSize = true;
            this.labelRes.Location = new System.Drawing.Point(671, 69);
            this.labelRes.Name = "labelRes";
            this.labelRes.Size = new System.Drawing.Size(0, 13);
            this.labelRes.TabIndex = 26;
            // 
            // listRespuestas
            // 
            this.listRespuestas.FormattingEnabled = true;
            this.listRespuestas.Location = new System.Drawing.Point(584, 21);
            this.listRespuestas.Name = "listRespuestas";
            this.listRespuestas.Size = new System.Drawing.Size(426, 134);
            this.listRespuestas.TabIndex = 27;
            // 
            // radioX7
            // 
            this.radioX7.AutoSize = true;
            this.radioX7.Location = new System.Drawing.Point(444, 125);
            this.radioX7.Name = "radioX7";
            this.radioX7.Size = new System.Drawing.Size(62, 17);
            this.radioX7.TabIndex = 28;
            this.radioX7.TabStop = true;
            this.radioX7.Text = "P(   <   )";
            this.radioX7.UseVisualStyleBackColor = true;
            this.radioX7.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtX7
            // 
            this.txtX7.Location = new System.Drawing.Point(503, 122);
            this.txtX7.Name = "txtX7";
            this.txtX7.Size = new System.Drawing.Size(26, 20);
            this.txtX7.TabIndex = 29;
            // 
            // txtX8
            // 
            this.txtX8.Location = new System.Drawing.Point(535, 122);
            this.txtX8.Name = "txtX8";
            this.txtX8.Size = new System.Drawing.Size(27, 20);
            this.txtX8.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Poblacion:";
            // 
            // txtPoblacion
            // 
            this.txtPoblacion.Location = new System.Drawing.Point(204, 86);
            this.txtPoblacion.Name = "txtPoblacion";
            this.txtPoblacion.Size = new System.Drawing.Size(100, 20);
            this.txtPoblacion.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(781, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Respuestas";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 570);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPoblacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtX8);
            this.Controls.Add(this.txtX7);
            this.Controls.Add(this.radioX7);
            this.Controls.Add(this.listRespuestas);
            this.Controls.Add(this.labelRes);
            this.Controls.Add(this.radioX5);
            this.Controls.Add(this.radioX4);
            this.Controls.Add(this.radioX3);
            this.Controls.Add(this.radioX2);
            this.Controls.Add(this.radioX1);
            this.Controls.Add(this.radioX);
            this.Controls.Add(this.txtX4);
            this.Controls.Add(this.txtX3);
            this.Controls.Add(this.txtX6);
            this.Controls.Add(this.txtX5);
            this.Controls.Add(this.txtX2);
            this.Controls.Add(this.txtX1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.txtP);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorN;
        private System.Windows.Forms.ErrorProvider errorP;
        private System.Windows.Forms.ErrorProvider errorX;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox txtX6;
        private System.Windows.Forms.TextBox txtX5;
        private System.Windows.Forms.TextBox txtX2;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.TextBox txtX4;
        private System.Windows.Forms.TextBox txtX3;
        private System.Windows.Forms.RadioButton radioX5;
        private System.Windows.Forms.RadioButton radioX4;
        private System.Windows.Forms.RadioButton radioX3;
        private System.Windows.Forms.RadioButton radioX2;
        private System.Windows.Forms.RadioButton radioX1;
        private System.Windows.Forms.RadioButton radioX;
        private System.Windows.Forms.Label labelRes;
        private System.Windows.Forms.ListBox listRespuestas;
        private System.Windows.Forms.RadioButton radioX7;
        private System.Windows.Forms.TextBox txtX8;
        private System.Windows.Forms.TextBox txtX7;
        private System.Windows.Forms.TextBox txtPoblacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

