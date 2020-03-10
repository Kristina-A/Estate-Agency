namespace AgencijaZaNekretnine
{
    partial class Opcije
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Opcije));
            this.btnNekretnine = new System.Windows.Forms.Button();
            this.btnAgenti = new System.Windows.Forms.Button();
            this.btnKlijenti = new System.Windows.Forms.Button();
            this.btnZastupnici = new System.Windows.Forms.Button();
            this.btnUgovori = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNekretnine
            // 
            this.btnNekretnine.Location = new System.Drawing.Point(71, 43);
            this.btnNekretnine.Name = "btnNekretnine";
            this.btnNekretnine.Size = new System.Drawing.Size(149, 23);
            this.btnNekretnine.TabIndex = 0;
            this.btnNekretnine.Text = "Pregled nekretnina";
            this.btnNekretnine.UseVisualStyleBackColor = true;
            this.btnNekretnine.Click += new System.EventHandler(this.btnNekretnine_Click);
            // 
            // btnAgenti
            // 
            this.btnAgenti.Location = new System.Drawing.Point(71, 89);
            this.btnAgenti.Name = "btnAgenti";
            this.btnAgenti.Size = new System.Drawing.Size(149, 23);
            this.btnAgenti.TabIndex = 1;
            this.btnAgenti.Text = "Pregled agenata";
            this.btnAgenti.UseVisualStyleBackColor = true;
            this.btnAgenti.Click += new System.EventHandler(this.btnAgenti_Click);
            // 
            // btnKlijenti
            // 
            this.btnKlijenti.Location = new System.Drawing.Point(71, 133);
            this.btnKlijenti.Name = "btnKlijenti";
            this.btnKlijenti.Size = new System.Drawing.Size(149, 23);
            this.btnKlijenti.TabIndex = 2;
            this.btnKlijenti.Text = "Pregled klijenata";
            this.btnKlijenti.UseVisualStyleBackColor = true;
            this.btnKlijenti.Click += new System.EventHandler(this.btnKlijenti_Click);
            // 
            // btnZastupnici
            // 
            this.btnZastupnici.Location = new System.Drawing.Point(71, 225);
            this.btnZastupnici.Name = "btnZastupnici";
            this.btnZastupnici.Size = new System.Drawing.Size(149, 23);
            this.btnZastupnici.TabIndex = 4;
            this.btnZastupnici.Text = "Pregled pravnih zastupnika";
            this.btnZastupnici.UseVisualStyleBackColor = true;
            this.btnZastupnici.Click += new System.EventHandler(this.btnZastupnici_Click);
            // 
            // btnUgovori
            // 
            this.btnUgovori.Location = new System.Drawing.Point(71, 180);
            this.btnUgovori.Name = "btnUgovori";
            this.btnUgovori.Size = new System.Drawing.Size(149, 23);
            this.btnUgovori.TabIndex = 5;
            this.btnUgovori.Text = "Pregled ugovora";
            this.btnUgovori.UseVisualStyleBackColor = true;
            this.btnUgovori.Click += new System.EventHandler(this.btnUgovori_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pregled baze podataka:";
            // 
            // Opcije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 269);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUgovori);
            this.Controls.Add(this.btnZastupnici);
            this.Controls.Add(this.btnKlijenti);
            this.Controls.Add(this.btnAgenti);
            this.Controls.Add(this.btnNekretnine);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Opcije";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agencija za nekretnine ELFAK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNekretnine;
        private System.Windows.Forms.Button btnAgenti;
        private System.Windows.Forms.Button btnKlijenti;
        private System.Windows.Forms.Button btnZastupnici;
        private System.Windows.Forms.Button btnUgovori;
        private System.Windows.Forms.Label label1;
    }
}