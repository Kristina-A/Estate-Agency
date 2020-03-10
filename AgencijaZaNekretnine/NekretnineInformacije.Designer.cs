namespace AgencijaZaNekretnine
{
    partial class NekretnineInformacije
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NekretnineInformacije));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnProdato = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnAzuriraj = new System.Windows.Forms.Button();
            this.btnFotografije = new System.Windows.Forms.Button();
            this.btnDodajFoto = new System.Windows.Forms.Button();
            this.ofdDodajSlike = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(730, 246);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Lokacija";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ulica";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tip";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Kavdratura";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Cena";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Prodaja/Iznajmljivanje";
            this.columnHeader7.Width = 122;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Ime vlasnika";
            this.columnHeader8.Width = 75;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Prezime vlasnika";
            this.columnHeader9.Width = 98;
            // 
            // btnProdato
            // 
            this.btnProdato.Location = new System.Drawing.Point(761, 57);
            this.btnProdato.Name = "btnProdato";
            this.btnProdato.Size = new System.Drawing.Size(117, 23);
            this.btnProdato.TabIndex = 1;
            this.btnProdato.Text = "Prodato";
            this.btnProdato.UseVisualStyleBackColor = true;
            this.btnProdato.Click += new System.EventHandler(this.btnProdato_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(761, 102);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(117, 23);
            this.btnDodaj.TabIndex = 2;
            this.btnDodaj.Text = "Dodaj nekretninu";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(761, 147);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(117, 23);
            this.btnObrisi.TabIndex = 3;
            this.btnObrisi.Text = "Obriši nekretninu";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnAzuriraj
            // 
            this.btnAzuriraj.Location = new System.Drawing.Point(761, 192);
            this.btnAzuriraj.Name = "btnAzuriraj";
            this.btnAzuriraj.Size = new System.Drawing.Size(117, 23);
            this.btnAzuriraj.TabIndex = 4;
            this.btnAzuriraj.Text = "Ažuriraj nekretninu";
            this.btnAzuriraj.UseVisualStyleBackColor = true;
            this.btnAzuriraj.Click += new System.EventHandler(this.btnAzuriraj_Click);
            // 
            // btnFotografije
            // 
            this.btnFotografije.Location = new System.Drawing.Point(761, 12);
            this.btnFotografije.Name = "btnFotografije";
            this.btnFotografije.Size = new System.Drawing.Size(117, 23);
            this.btnFotografije.TabIndex = 5;
            this.btnFotografije.Text = "Fotografije";
            this.btnFotografije.UseVisualStyleBackColor = true;
            this.btnFotografije.Click += new System.EventHandler(this.btnFotografije_Click);
            // 
            // btnDodajFoto
            // 
            this.btnDodajFoto.Location = new System.Drawing.Point(761, 235);
            this.btnDodajFoto.Name = "btnDodajFoto";
            this.btnDodajFoto.Size = new System.Drawing.Size(117, 23);
            this.btnDodajFoto.TabIndex = 6;
            this.btnDodajFoto.Text = "Dodaj fotografije";
            this.btnDodajFoto.UseVisualStyleBackColor = true;
            this.btnDodajFoto.Click += new System.EventHandler(this.btnDodajFoto_Click);
            // 
            // ofdDodajSlike
            // 
            this.ofdDodajSlike.FileName = "openFileDialog1";
            this.ofdDodajSlike.Filter = "Image files|*.jpg";
            // 
            // NekretnineInformacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(898, 279);
            this.Controls.Add(this.btnDodajFoto);
            this.Controls.Add(this.btnFotografije);
            this.Controls.Add(this.btnAzuriraj);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.btnProdato);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NekretnineInformacije";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agencija za nekretnine ELFAK";
            this.Load += new System.EventHandler(this.NekretnineInformacije_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btnProdato;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnAzuriraj;
        private System.Windows.Forms.Button btnFotografije;
        private System.Windows.Forms.Button btnDodajFoto;
        private System.Windows.Forms.OpenFileDialog ofdDodajSlike;
    }
}