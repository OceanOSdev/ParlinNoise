namespace Graph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartParlin = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOctaves = new System.Windows.Forms.TextBox();
            this.txtPersistence = new System.Windows.Forms.TextBox();
            this.comboInterpType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnApplyAndGraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartParlin)).BeginInit();
            this.SuspendLayout();
            // 
            // chartParlin
            // 
            this.chartParlin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.chartParlin.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartParlin.Legends.Add(legend4);
            this.chartParlin.Location = new System.Drawing.Point(12, 96);
            this.chartParlin.Name = "chartParlin";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartParlin.Series.Add(series4);
            this.chartParlin.Size = new System.Drawing.Size(758, 458);
            this.chartParlin.TabIndex = 0;
            this.chartParlin.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Octaves:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Persistence:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Interpolation Type:";
            // 
            // txtOctaves
            // 
            this.txtOctaves.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOctaves.Location = new System.Drawing.Point(649, 6);
            this.txtOctaves.Name = "txtOctaves";
            this.txtOctaves.Size = new System.Drawing.Size(121, 20);
            this.txtOctaves.TabIndex = 4;
            this.txtOctaves.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOctaves_KeyPress);
            // 
            // txtPersistence
            // 
            this.txtPersistence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPersistence.Location = new System.Drawing.Point(649, 36);
            this.txtPersistence.Name = "txtPersistence";
            this.txtPersistence.Size = new System.Drawing.Size(121, 20);
            this.txtPersistence.TabIndex = 5;
            this.txtPersistence.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersistence_KeyPress);
            // 
            // comboInterpType
            // 
            this.comboInterpType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboInterpType.AutoCompleteCustomSource.AddRange(new string[] {
            "Linear Interpolation",
            "Cosine Interpolation",
            "Cubic Interpolation"});
            this.comboInterpType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboInterpType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboInterpType.FormattingEnabled = true;
            this.comboInterpType.Items.AddRange(new object[] {
            "Linear Interpolation",
            "Cosine Interpolation",
            "Cubic Interpolation"});
            this.comboInterpType.Location = new System.Drawing.Point(649, 69);
            this.comboInterpType.Name = "comboInterpType";
            this.comboInterpType.Size = new System.Drawing.Size(121, 21);
            this.comboInterpType.TabIndex = 6;
            this.comboInterpType.SelectionChangeCommitted += new System.EventHandler(this.comboInterpType_SelectionChangeCommitted);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(695, 560);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnApplyAndGraph
            // 
            this.btnApplyAndGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyAndGraph.Location = new System.Drawing.Point(614, 560);
            this.btnApplyAndGraph.Name = "btnApplyAndGraph";
            this.btnApplyAndGraph.Size = new System.Drawing.Size(75, 23);
            this.btnApplyAndGraph.TabIndex = 8;
            this.btnApplyAndGraph.Text = "Graph";
            this.btnApplyAndGraph.UseVisualStyleBackColor = true;
            this.btnApplyAndGraph.Click += new System.EventHandler(this.btnApplyAndGraph_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 595);
            this.Controls.Add(this.btnApplyAndGraph);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboInterpType);
            this.Controls.Add(this.txtPersistence);
            this.Controls.Add(this.txtOctaves);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartParlin);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chartParlin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartParlin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOctaves;
        private System.Windows.Forms.TextBox txtPersistence;
        private System.Windows.Forms.ComboBox comboInterpType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnApplyAndGraph;
    }
}

