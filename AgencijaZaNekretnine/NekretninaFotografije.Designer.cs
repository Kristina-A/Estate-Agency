namespace AgencijaZaNekretnine
{
    partial class NekretninaFotografije
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NekretninaFotografije));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSledeca = new System.Windows.Forms.Button();
            this.btnPrethodna = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(569, 353);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnSledeca
            // 
            this.btnSledeca.Location = new System.Drawing.Point(506, 418);
            this.btnSledeca.Name = "btnSledeca";
            this.btnSledeca.Size = new System.Drawing.Size(75, 23);
            this.btnSledeca.TabIndex = 1;
            this.btnSledeca.Text = "Sledeća";
            this.btnSledeca.UseVisualStyleBackColor = true;
            this.btnSledeca.Click += new System.EventHandler(this.btnSledeca_Click);
            // 
            // btnPrethodna
            // 
            this.btnPrethodna.Location = new System.Drawing.Point(12, 418);
            this.btnPrethodna.Name = "btnPrethodna";
            this.btnPrethodna.Size = new System.Drawing.Size(75, 23);
            this.btnPrethodna.TabIndex = 2;
            this.btnPrethodna.Text = "Prethodna";
            this.btnPrethodna.UseVisualStyleBackColor = true;
            this.btnPrethodna.Click += new System.EventHandler(this.btnPrethodna_Click);
            // 
            // NekretninaFotografije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(593, 466);
            this.Controls.Add(this.btnPrethodna);
            this.Controls.Add(this.btnSledeca);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NekretninaFotografije";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agencija za nekretnine ELFAK";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSledeca;
        private System.Windows.Forms.Button btnPrethodna;
    }
}