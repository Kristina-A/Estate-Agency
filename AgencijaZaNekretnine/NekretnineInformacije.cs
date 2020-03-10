using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using AgencijaZaNekretnine.Entiteti;

namespace AgencijaZaNekretnine
{
    public partial class NekretnineInformacije : Form
    {
        public NekretnineInformacije()
        {
            InitializeComponent();
        }

        public NekretnineInformacije(int f)
        {
            InitializeComponent();
            if (f == 0 || f==2)
                btnProdato.Visible = false;

            if(f==0 || f==1)
            {
                btnAzuriraj.Visible = false;
                btnDodaj.Visible = false;
                btnObrisi.Visible = false;
                btnDodajFoto.Visible = false;
            }
        }

        private void btnProdato_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite nekretninu!");
                return;
            }

            string str = listView1.SelectedItems[0].SubItems[6].Text;

            if(str.Equals("iznajmljivanje"))
            {
                MessageBox.Show("Nekretnina nije na prodaju!");
                return;
            }

            int nekrId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            try
            {
                ISession s = DataLayer.GetSession();

                Nekretnina n = s.Load<Nekretnina>(nekrId);
                IList<Ugovor> u = s.QueryOver<Ugovor>()
                    .Where(ug => ug.PripadaNekretnini.Id == nekrId)
                    .List<Ugovor>();

                int vlId = n.Vlasnik.Id;

                if(u.Count==0)
                {
                    MessageBox.Show("Ne mozete prodati nekretninu bez ugovora!");
                    return;
                }

                s.Delete(n);
                s.Flush();

                Klijent k = s.Load<Klijent>(vlId);
                if (k.NekretnineVlasnik.Count == 0)
                {
                    k.Prodavac = "Ne";
                    s.Update(k);
                }

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

            this.PopulateInfos();
        }

        private void NekretnineInformacije_Load(object sender, EventArgs e)
        {
            PopulateInfos();
        }

        private void PopulateInfos()
        {
            listView1.Items.Clear();
            List<NekretninaPregled> nekrInfos = DTOManager.GetNekrInfos();
            foreach (NekretninaPregled n in nekrInfos)
            {
                ListViewItem item = new ListViewItem(new string[] {n.NekretninaId.ToString(),n.NekretninaLokacija,n.NekretninaUlica,n.NekretninaTip,n.NekretninaKvadratura.ToString(),n.NekretninaCena.ToString(),n.NekretninaPI,n.VlasnikIme,n.VlasnikPrezime });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite nekretninu!");
                return;
            }

            int nekrId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            try
            {
                ISession s = DataLayer.GetSession();

                Nekretnina n = s.Load<Nekretnina>(nekrId);
                int vlId = n.Vlasnik.Id;

                s.Delete(n);
                s.Flush();

                Klijent k = s.Load<Klijent>(vlId);
                if (k.NekretnineVlasnik.Count == 0)
                {
                    k.Prodavac = "Ne";
                    s.Update(k);
                }

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

            this.PopulateInfos();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            NekretninaDodajAzuriraj nda = new NekretninaDodajAzuriraj();
            if (nda.ShowDialog() == DialogResult.OK)
                PopulateInfos();
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite nekretninu!");
                return;
            }

            int nekId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            NekretninaBasic nb = DTOManager.GetNekretninaBasic(nekId);
            NekretninaDodajAzuriraj nda = new NekretninaDodajAzuriraj(nb);
            if (nda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                PopulateInfos();
        }

        private void btnFotografije_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite nekretninu!");
                return;
            }

            int nekId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            try
            {
                ISession s = DataLayer.GetSession();

                Nekretnina n = s.Load<Nekretnina>(nekId);
                if(n.Fotografije.Count==0)
                {
                    s.Close();
                    MessageBox.Show("Nema fotografija za prikaz!");
                    return;
                }

                NekretninaFotografije nf = new NekretninaFotografije(n);
                nf.Show();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnDodajFoto_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite nekretninu!");
                return;
            }

            int nekId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            try
            {
                if (ofdDodajSlike.ShowDialog() == DialogResult.OK)
                {
                    ISession s = DataLayer.GetSession();
                    Nekretnina n = s.Load<Nekretnina>(nekId);
                    string path = ofdDodajSlike.FileName;
                    byte[] slika = Encoding.ASCII.GetBytes(path);
                    Fotografija f = new Fotografija()
                    {
                        Sadrzaj = slika,
                        PripadaNekretnini = n
                    };
                    s.Save(f);
                    s.Flush();
                    s.Close();
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
