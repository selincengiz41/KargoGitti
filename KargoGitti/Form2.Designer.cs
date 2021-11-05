
namespace KargoGitti
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.KonumTxt = new System.Windows.Forms.TextBox();
            this.LatTxt = new System.Windows.Forms.TextBox();
            this.LngTxt = new System.Windows.Forms.TextBox();
            this.BtnYukle = new System.Windows.Forms.Button();
            this.SilBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.noktaAdiTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(321, 368);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // gMapControl1
            // 
            this.gMapControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(0, 0);
            this.gMapControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(321, 366);
            this.gMapControl1.TabIndex = 1;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Konum";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 164);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Longitude";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Latitude";
            // 
            // KonumTxt
            // 
            this.KonumTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KonumTxt.Location = new System.Drawing.Point(359, 60);
            this.KonumTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.KonumTxt.Name = "KonumTxt";
            this.KonumTxt.Size = new System.Drawing.Size(76, 20);
            this.KonumTxt.TabIndex = 5;
            // 
            // LatTxt
            // 
            this.LatTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LatTxt.Location = new System.Drawing.Point(359, 124);
            this.LatTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LatTxt.Name = "LatTxt";
            this.LatTxt.Size = new System.Drawing.Size(76, 20);
            this.LatTxt.TabIndex = 6;
            // 
            // LngTxt
            // 
            this.LngTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LngTxt.Location = new System.Drawing.Point(359, 196);
            this.LngTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LngTxt.Name = "LngTxt";
            this.LngTxt.Size = new System.Drawing.Size(76, 20);
            this.LngTxt.TabIndex = 7;
            // 
            // BtnYukle
            // 
            this.BtnYukle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnYukle.Location = new System.Drawing.Point(360, 287);
            this.BtnYukle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnYukle.Name = "BtnYukle";
            this.BtnYukle.Size = new System.Drawing.Size(67, 29);
            this.BtnYukle.TabIndex = 8;
            this.BtnYukle.Text = "BtnLoad";
            this.BtnYukle.UseVisualStyleBackColor = true;
            this.BtnYukle.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // SilBtn
            // 
            this.SilBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SilBtn.Location = new System.Drawing.Point(483, 287);
            this.SilBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SilBtn.Name = "SilBtn";
            this.SilBtn.Size = new System.Drawing.Size(74, 29);
            this.SilBtn.TabIndex = 9;
            this.SilBtn.Text = "Teslim Et";
            this.SilBtn.UseVisualStyleBackColor = true;
            this.SilBtn.Click += new System.EventHandler(this.SilBtn_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(354, 240);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nokta Adi";
            // 
            // noktaAdiTxt
            // 
            this.noktaAdiTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.noktaAdiTxt.Location = new System.Drawing.Point(483, 240);
            this.noktaAdiTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.noktaAdiTxt.Name = "noktaAdiTxt";
            this.noktaAdiTxt.Size = new System.Drawing.Size(74, 20);
            this.noktaAdiTxt.TabIndex = 11;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(684, 368);
            this.Controls.Add(this.noktaAdiTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SilBtn);
            this.Controls.Add(this.BtnYukle);
            this.Controls.Add(this.LngTxt);
            this.Controls.Add(this.LatTxt);
            this.Controls.Add(this.KonumTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gMapControl1);
            this.Controls.Add(this.splitter1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox KonumTxt;
        private System.Windows.Forms.TextBox LatTxt;
        private System.Windows.Forms.TextBox LngTxt;
        private System.Windows.Forms.Button BtnYukle;
        private System.Windows.Forms.Button SilBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox noktaAdiTxt;
    }
}