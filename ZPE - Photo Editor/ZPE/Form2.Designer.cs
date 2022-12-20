
namespace ZPE
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartRed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBlue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGreen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGreen)).BeginInit();
            this.SuspendLayout();
            // 
            // chartRed
            // 
            this.chartRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            chartArea1.Name = "ChartArea1";
            this.chartRed.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRed.Legends.Add(legend1);
            this.chartRed.Location = new System.Drawing.Point(12, 12);
            this.chartRed.Name = "chartRed";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartRed.Series.Add(series1);
            this.chartRed.Size = new System.Drawing.Size(490, 426);
            this.chartRed.TabIndex = 0;
            // 
            // chartBlue
            // 
            this.chartBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartBlue.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartBlue.Legends.Add(legend2);
            this.chartBlue.Location = new System.Drawing.Point(1084, 12);
            this.chartBlue.Name = "chartBlue";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartBlue.Series.Add(series2);
            this.chartBlue.Size = new System.Drawing.Size(570, 426);
            this.chartBlue.TabIndex = 1;
            // 
            // chartGreen
            // 
            this.chartGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            chartArea3.Name = "ChartArea1";
            this.chartGreen.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartGreen.Legends.Add(legend3);
            this.chartGreen.Location = new System.Drawing.Point(508, 12);
            this.chartGreen.Name = "chartGreen";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartGreen.Series.Add(series3);
            this.chartGreen.Size = new System.Drawing.Size(570, 426);
            this.chartGreen.TabIndex = 2;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 450);
            this.Controls.Add(this.chartGreen);
            this.Controls.Add(this.chartBlue);
            this.Controls.Add(this.chartRed);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartRed;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBlue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGreen;
    }
}