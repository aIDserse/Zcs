
namespace ZPE
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBoxImage = new System.Windows.Forms.GroupBox();
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.gropuBoxFiltri = new System.Windows.Forms.GroupBox();
            this.MinButton = new System.Windows.Forms.Button();
            this.MaxButton = new System.Windows.Forms.Button();
            this.EdgeDetectButton = new System.Windows.Forms.Button();
            this.TresholdButton = new System.Windows.Forms.Button();
            this.bottLaplacian = new System.Windows.Forms.Button();
            this.InvertColourButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.trackBarBlur = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.MedianButton = new System.Windows.Forms.Button();
            this.GreyScaleButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.Livello = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.trackBarMaxSharpness = new System.Windows.Forms.TrackBar();
            this.trackBarSharpness = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAttesa = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Y = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.X = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ColourButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.groupBoxImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.gropuBoxFiltri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMaxSharpness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSharpness)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxImage
            // 
            this.groupBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxImage.Controls.Add(this.ImagePictureBox);
            this.groupBoxImage.Location = new System.Drawing.Point(485, 12);
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.Size = new System.Drawing.Size(973, 831);
            this.groupBoxImage.TabIndex = 32;
            this.groupBoxImage.TabStop = false;
            this.groupBoxImage.Text = "FileName";
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagePictureBox.Location = new System.Drawing.Point(20, 21);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(947, 793);
            this.ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagePictureBox.TabIndex = 12;
            this.ImagePictureBox.TabStop = false;
            this.ImagePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImagePictureBox_MouseMove);
            // 
            // gropuBoxFiltri
            // 
            this.gropuBoxFiltri.Controls.Add(this.MinButton);
            this.gropuBoxFiltri.Controls.Add(this.MaxButton);
            this.gropuBoxFiltri.Controls.Add(this.EdgeDetectButton);
            this.gropuBoxFiltri.Controls.Add(this.TresholdButton);
            this.gropuBoxFiltri.Controls.Add(this.bottLaplacian);
            this.gropuBoxFiltri.Controls.Add(this.InvertColourButton);
            this.gropuBoxFiltri.Controls.Add(this.label9);
            this.gropuBoxFiltri.Controls.Add(this.trackBarBlur);
            this.gropuBoxFiltri.Controls.Add(this.label3);
            this.gropuBoxFiltri.Controls.Add(this.MedianButton);
            this.gropuBoxFiltri.Controls.Add(this.GreyScaleButton);
            this.gropuBoxFiltri.Controls.Add(this.label15);
            this.gropuBoxFiltri.Controls.Add(this.trackBarBrightness);
            this.gropuBoxFiltri.Controls.Add(this.label7);
            this.gropuBoxFiltri.Controls.Add(this.Livello);
            this.gropuBoxFiltri.Controls.Add(this.label11);
            this.gropuBoxFiltri.Controls.Add(this.label10);
            this.gropuBoxFiltri.Controls.Add(this.trackBarMaxSharpness);
            this.gropuBoxFiltri.Controls.Add(this.trackBarSharpness);
            this.gropuBoxFiltri.Controls.Add(this.label5);
            this.gropuBoxFiltri.Controls.Add(this.label4);
            this.gropuBoxFiltri.Location = new System.Drawing.Point(12, 12);
            this.gropuBoxFiltri.Name = "gropuBoxFiltri";
            this.gropuBoxFiltri.Size = new System.Drawing.Size(467, 436);
            this.gropuBoxFiltri.TabIndex = 30;
            this.gropuBoxFiltri.TabStop = false;
            this.gropuBoxFiltri.Text = "Filtri";
            // 
            // MinButton
            // 
            this.MinButton.Location = new System.Drawing.Point(146, 101);
            this.MinButton.Name = "MinButton";
            this.MinButton.Size = new System.Drawing.Size(123, 27);
            this.MinButton.TabIndex = 39;
            this.MinButton.Text = "Min FIlter";
            this.MinButton.UseVisualStyleBackColor = true;
            this.MinButton.Click += new System.EventHandler(this.MinButton_Click);
            // 
            // MaxButton
            // 
            this.MaxButton.Location = new System.Drawing.Point(14, 101);
            this.MaxButton.Name = "MaxButton";
            this.MaxButton.Size = new System.Drawing.Size(123, 27);
            this.MaxButton.TabIndex = 38;
            this.MaxButton.Text = "Max FIlter";
            this.MaxButton.UseVisualStyleBackColor = true;
            this.MaxButton.Click += new System.EventHandler(this.MaxButton_Click);
            // 
            // EdgeDetectButton
            // 
            this.EdgeDetectButton.Location = new System.Drawing.Point(275, 68);
            this.EdgeDetectButton.Name = "EdgeDetectButton";
            this.EdgeDetectButton.Size = new System.Drawing.Size(126, 27);
            this.EdgeDetectButton.TabIndex = 37;
            this.EdgeDetectButton.Text = "Edge Detection";
            this.EdgeDetectButton.UseVisualStyleBackColor = true;
            this.EdgeDetectButton.Click += new System.EventHandler(this.EdgeDetectButton_Click);
            // 
            // TresholdButton
            // 
            this.TresholdButton.Location = new System.Drawing.Point(275, 35);
            this.TresholdButton.Name = "TresholdButton";
            this.TresholdButton.Size = new System.Drawing.Size(126, 27);
            this.TresholdButton.TabIndex = 36;
            this.TresholdButton.Text = "Treshold";
            this.TresholdButton.UseVisualStyleBackColor = true;
            this.TresholdButton.Click += new System.EventHandler(this.TresholdButton_Click);
            // 
            // bottLaplacian
            // 
            this.bottLaplacian.Location = new System.Drawing.Point(143, 68);
            this.bottLaplacian.Name = "bottLaplacian";
            this.bottLaplacian.Size = new System.Drawing.Size(126, 27);
            this.bottLaplacian.TabIndex = 35;
            this.bottLaplacian.Text = "Laplacian";
            this.bottLaplacian.UseVisualStyleBackColor = true;
            this.bottLaplacian.Click += new System.EventHandler(this.bottLaplacian_Click);
            // 
            // InvertColourButton
            // 
            this.InvertColourButton.Location = new System.Drawing.Point(14, 68);
            this.InvertColourButton.Name = "InvertColourButton";
            this.InvertColourButton.Size = new System.Drawing.Size(123, 27);
            this.InvertColourButton.TabIndex = 34;
            this.InvertColourButton.Text = "Invert";
            this.InvertColourButton.UseVisualStyleBackColor = true;
            this.InvertColourButton.Click += new System.EventHandler(this.InvertColourButton_Click);
            // 
            // label9
            // 
            this.label9.AccessibleName = "label9";
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(415, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.TabIndex = 33;
            this.label9.Text = "label9";
            // 
            // trackBarBlur
            // 
            this.trackBarBlur.AccessibleName = "lblSfocatura";
            this.trackBarBlur.Location = new System.Drawing.Point(118, 169);
            this.trackBarBlur.Name = "trackBarBlur";
            this.trackBarBlur.Size = new System.Drawing.Size(278, 56);
            this.trackBarBlur.TabIndex = 31;
            this.trackBarBlur.Scroll += new System.EventHandler(this.trackBarBlur_Scroll);
            // 
            // label3
            // 
            this.label3.AccessibleName = "lblSfocatura";
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Blur";
            // 
            // MedianButton
            // 
            this.MedianButton.Location = new System.Drawing.Point(143, 35);
            this.MedianButton.Name = "MedianButton";
            this.MedianButton.Size = new System.Drawing.Size(126, 27);
            this.MedianButton.TabIndex = 30;
            this.MedianButton.Text = "Median";
            this.MedianButton.UseVisualStyleBackColor = true;
            this.MedianButton.Click += new System.EventHandler(this.MedianButton_Click);
            // 
            // GreyScaleButton
            // 
            this.GreyScaleButton.Location = new System.Drawing.Point(14, 35);
            this.GreyScaleButton.Name = "GreyScaleButton";
            this.GreyScaleButton.Size = new System.Drawing.Size(123, 27);
            this.GreyScaleButton.TabIndex = 29;
            this.GreyScaleButton.Text = "Grey Scale";
            this.GreyScaleButton.UseVisualStyleBackColor = true;
            this.GreyScaleButton.Click += new System.EventHandler(this.GreyScaleButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(407, 352);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 17);
            this.label15.TabIndex = 28;
            this.label15.Text = "label15";
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.Location = new System.Drawing.Point(118, 352);
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(278, 56);
            this.trackBarBrightness.TabIndex = 26;
            this.trackBarBrightness.Scroll += new System.EventHandler(this.trackBarBrightness_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "Brightness";
            // 
            // Livello
            // 
            this.Livello.AutoSize = true;
            this.Livello.Location = new System.Drawing.Point(415, 111);
            this.Livello.Name = "Livello";
            this.Livello.Size = new System.Drawing.Size(42, 17);
            this.Livello.TabIndex = 24;
            this.Livello.Text = "Level";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(407, 293);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "label11";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(407, 231);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "label10";
            // 
            // trackBarMaxSharpness
            // 
            this.trackBarMaxSharpness.Location = new System.Drawing.Point(118, 293);
            this.trackBarMaxSharpness.Name = "trackBarMaxSharpness";
            this.trackBarMaxSharpness.Size = new System.Drawing.Size(278, 56);
            this.trackBarMaxSharpness.TabIndex = 4;
            this.trackBarMaxSharpness.Scroll += new System.EventHandler(this.trackBarMaxSharpness_Scroll);
            // 
            // trackBarSharpness
            // 
            this.trackBarSharpness.Location = new System.Drawing.Point(118, 231);
            this.trackBarSharpness.Name = "trackBarSharpness";
            this.trackBarSharpness.Size = new System.Drawing.Size(278, 56);
            this.trackBarSharpness.TabIndex = 3;
            this.trackBarSharpness.Scroll += new System.EventHandler(this.trackBarSharpness_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Sharpness++";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sharpness";
            // 
            // labelAttesa
            // 
            this.labelAttesa.AutoSize = true;
            this.labelAttesa.Location = new System.Drawing.Point(23, 509);
            this.labelAttesa.Name = "labelAttesa";
            this.labelAttesa.Size = new System.Drawing.Size(0, 17);
            this.labelAttesa.TabIndex = 38;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(127, 548);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 17);
            this.label14.TabIndex = 37;
            this.label14.Text = "label14";
            // 
            // Y
            // 
            this.Y.AutoSize = true;
            this.Y.Location = new System.Drawing.Point(100, 548);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(21, 17);
            this.Y.TabIndex = 36;
            this.Y.Text = "Y:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(40, 548);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 17);
            this.label13.TabIndex = 35;
            this.label13.Text = "label13";
            // 
            // X
            // 
            this.X.AutoSize = true;
            this.X.Location = new System.Drawing.Point(18, 548);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(21, 17);
            this.X.TabIndex = 34;
            this.X.Text = "X:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ColourButton);
            this.groupBox1.Controls.Add(this.SaveButton);
            this.groupBox1.Controls.Add(this.LoadButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 454);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 91);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File";
            // 
            // ColourButton
            // 
            this.ColourButton.BackgroundImage = global::ZPE.Properties.Resources._17142;
            this.ColourButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ColourButton.Location = new System.Drawing.Point(146, 21);
            this.ColourButton.Name = "ColourButton";
            this.ColourButton.Size = new System.Drawing.Size(62, 54);
            this.ColourButton.TabIndex = 16;
            this.ColourButton.UseVisualStyleBackColor = true;
            this.ColourButton.Click += new System.EventHandler(this.ColourButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveButton.BackgroundImage")));
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SaveButton.Location = new System.Drawing.Point(11, 21);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(62, 54);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = " ";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoadButton.BackgroundImage")));
            this.LoadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoadButton.Location = new System.Drawing.Point(75, 21);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(62, 54);
            this.LoadButton.TabIndex = 14;
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1470, 855);
            this.Controls.Add(this.labelAttesa);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Y);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.X);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxImage);
            this.Controls.Add(this.gropuBoxFiltri);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.gropuBoxFiltri.ResumeLayout(false);
            this.gropuBoxFiltri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMaxSharpness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSharpness)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxImage;
        private System.Windows.Forms.PictureBox ImagePictureBox;
        private System.Windows.Forms.GroupBox gropuBoxFiltri;
        private System.Windows.Forms.Button MinButton;
        private System.Windows.Forms.Button MaxButton;
        private System.Windows.Forms.Button EdgeDetectButton;
        private System.Windows.Forms.Button TresholdButton;
        private System.Windows.Forms.Button bottLaplacian;
        private System.Windows.Forms.Button InvertColourButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar trackBarBlur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button MedianButton;
        private System.Windows.Forms.Button GreyScaleButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Livello;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trackBarMaxSharpness;
        private System.Windows.Forms.TrackBar trackBarSharpness;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAttesa;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label Y;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label X;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ColourButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
    }
}

