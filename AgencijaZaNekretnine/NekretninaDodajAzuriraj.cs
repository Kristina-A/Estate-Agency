using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgencijaZaNekretnine.Entiteti;
using NHibernate;

namespace AgencijaZaNekretnine
{
    public partial class NekretninaDodajAzuriraj : Form
    {
        NekretninaBasic n;
        public NekretninaDodajAzuriraj()
        {
            InitializeComponent();
            n = null;
            lblOd.Visible = false;
            lblDo.Visible = false;
            dtpDo.Visible = false;
            dtpOd.Visible = false;
            lblGodina.Visible = false;
            txtGodina.Visible = false;
            lblMaxMeseci.Visible = false;
            txtMaxMeseci.Visible = false;
            lblLicaFirme.Visible = false;
            cbxLicaFirme.Visible = false;
        }

        public NekretninaDodajAzuriraj(NekretninaBasic nb):this()
        {
            n = nb;
            lblAgent.Visible = false;
            txtAgent.Visible = false;
            lblVlasnik.Visible = false;
            txtVlasnik.Visible = false;
            lblUgovor.Visible = false;
            txtUgovor.Visible = false;
            lblDatum.Visible = false;
            dtpDatum.Visible = false;
            lblKvadratura.Visible = false;
            txtKvadratura.Visible = false;
            lblTip.Visible = false;
            cbxTip.Visible = false;
            lblOpstina.Visible = false;
            txtOpstina.Visible = false;
            lblParcela.Visible = false;
            txtParcela.Visible = false;
            lblBroj.Visible = false;
            txtBroj.Visible = false;
            lblGrad.Visible = false;
            txtLokacija.Visible = false;
            lblGodina.Visible = false;
            txtGodina.Visible = false;
            lblLicaFirme.Visible = false;
            cbxLicaFirme.Visible = false;

            if(nb.DatumOd==DateTime.MinValue && nb.Meseci==0)
            {
                chkDuze.Visible = false;
                chkKrace.Visible = false;
                chkProdaja.Checked = true;
                chkProdaja.Enabled = false;
            }
            else
            {
                if(nb.DatumOd==DateTime.MinValue && nb.Meseci!=0)
                {
                    chkProdaja.Visible = false;
                    chkKrace.Visible = false;
                    chkDuze.Checked = true;
                    chkDuze.Enabled = false;
                    lblLicaFirme.Visible = false;
                    cbxLicaFirme.Visible = false;
                    txtMaxMeseci.Text = n.Meseci.ToString();
                }
                else
                {
                    chkProdaja.Visible = false;
                    chkDuze.Visible = false;
                    chkKrace.Checked = true;
                    chkKrace.Enabled = false;
                    lblGodina.Visible = false;
                    txtGodina.Visible = false;
                    dtpOd.Value = n.DatumOd;
                    dtpDo.Value = n.DatumDo;
                }
            }
        }

        private void NekretninaDodajAzuriraj_Load(object sender, EventArgs e)
        {
            if (n!=null)
            {
                txtUlica.Text = n.Ulica;
                txtCena.Text = n.Cena.ToString();
                txtSpratovi.Text = n.SpratBrojSpratova;
                txtOpis.Text = n.Opis;
            }
        }

        private void chkProdaja_CheckedChanged(object sender, EventArgs e)
        {
            if(chkProdaja.Checked)
            {
                chkKrace.Checked = false;
                chkDuze.Checked = false;
            }
        }

        private void chkKrace_CheckedChanged(object sender, EventArgs e)
        {
            if(chkKrace.Checked)
            {
                chkProdaja.Checked = false;
                chkDuze.Checked = false;
                lblOd.Visible = true;
                lblDo.Visible = true;
                dtpDo.Visible = true;
                dtpOd.Visible = true;
                lblGodina.Visible = true;
                txtGodina.Visible = true;
            }
            else
            {
                lblOd.Visible = false;
                lblDo.Visible = false;
                dtpDo.Visible = false;
                dtpOd.Visible = false;
                lblGodina.Visible = false;
                txtGodina.Visible = false;
            }
        }

        private void chkDuze_CheckedChanged(object sender, EventArgs e)
        {
            if(chkDuze.Checked)
            {
                chkProdaja.Checked = false;
                chkKrace.Checked = false;
                lblMaxMeseci.Visible = true;
                txtMaxMeseci.Visible = true;
                lblLicaFirme.Visible = true;
                cbxLicaFirme.Visible = true;
            }
            else
            {
                lblMaxMeseci.Visible = false;
                txtMaxMeseci.Visible = false;
                lblLicaFirme.Visible = false;
                cbxLicaFirme.Visible = false;
            }
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            if(n!=null)
            {
                NekretninaBasic nb = new NekretninaBasic();
                nb.NekretninaId = n.NekretninaId;
                nb.Ulica = txtUlica.Text;
                nb.Cena = Int32.Parse(txtCena.Text);
                nb.SpratBrojSpratova = txtSpratovi.Text;
                nb.Opis = txtOpis.Text;
                if(n.Meseci!=0)
                {
                    nb.Meseci = Int32.Parse(txtMaxMeseci.Text);
                }
                if(n.DatumOd!=DateTime.MinValue)
                {
                    nb.DatumOd = dtpOd.Value;
                    nb.DatumDo = dtpDo.Value;
                }
                DTOManager.UpdateNekretninaBasic(nb);
            }
            else
            {
                if(chkProdaja.Checked)
                {
                    try
                    {
                        ISession s = DataLayer.GetSession();
                        NekretninaProdaja np = new NekretninaProdaja();
                        np.GradLokacija = txtLokacija.Text;
                        np.Ulica = txtUlica.Text;
                        np.Broj = Int32.Parse(txtBroj.Text);
                        np.BrojParcele = txtParcela.Text;
                        np.KatastarskaOpstina = txtOpstina.Text;
                        np.Tip = cbxTip.SelectedItem.ToString();
                        np.Kvadratura = Int32.Parse(txtKvadratura.Text);
                        np.DatumIzgradnje = dtpDatum.Value;
                        np.Cena = Int32.Parse(txtCena.Text);
                        np.SpratBrSpratova = txtSpratovi.Text;
                        np.Opis = txtOpis.Text;
                        np.IdUgovora = txtUgovor.Text;

                        Klijent vlasnik = s.Load<Klijent>(Int32.Parse(txtVlasnik.Text));
                        Agent agent = s.Load<Agent>(Int32.Parse(txtAgent.Text));
                        if(vlasnik.NekretnineVlasnik.Count==0 && !vlasnik.Prodavac.Equals("Da"))
                        {
                            vlasnik.Prodavac = "Da";
                            s.Update(vlasnik);
                        }
                        Random r = new Random();
                        PotpisaniUgovori pu = new PotpisaniUgovori()
                        {
                            PotpUgovori = txtUgovor.Text,
                            Kod = 20180605 + r.Next()
                        };
                        pu.Agent = agent;
                        np.Vlasnik = vlasnik;
                        np.ZaduzenAgent = agent;
                        s.Save(pu);
                        s.Flush();
                        s.Close();

                        DTOManager.SaveNekretnina(np);
                    }
                    catch (Exception ec)
                    {
                        MessageBox.Show(ec.Message);
                    }
                }
                else
                {
                    if(chkKrace.Checked)
                    {
                        try
                        {
                            ISession s = DataLayer.GetSession();
                            NekretninaIznajmljivanjeKrace nk = new NekretninaIznajmljivanjeKrace();
                            nk.GradLokacija = txtLokacija.Text;
                            nk.Ulica = txtUlica.Text;
                            nk.Broj = Int32.Parse(txtBroj.Text);
                            nk.BrojParcele = txtParcela.Text;
                            nk.KatastarskaOpstina = txtOpstina.Text;
                            nk.Tip = cbxTip.SelectedItem.ToString();
                            nk.Kvadratura = Int32.Parse(txtKvadratura.Text);
                            nk.DatumIzgradnje = dtpDatum.Value;
                            nk.Cena = Int32.Parse(txtCena.Text);
                            nk.SpratBrSpratova = txtSpratovi.Text;
                            nk.Opis = txtOpis.Text;
                            nk.IdUgovora = txtUgovor.Text;
                            nk.Godina = Int32.Parse(txtGodina.Text);
                            nk.DatumOd = dtpOd.Value;
                            nk.DatumDo = dtpDo.Value;

                            Klijent vlasnik = s.Load<Klijent>(Int32.Parse(txtVlasnik.Text));
                            Agent agent = s.Load<Agent>(Int32.Parse(txtAgent.Text));
                            if (vlasnik.NekretnineVlasnik.Count == 0 && !vlasnik.Prodavac.Equals("Da"))
                            {
                                vlasnik.Prodavac = "Da";
                                s.Update(vlasnik);
                            }
                            Random r = new Random();
                            PotpisaniUgovori pu = new PotpisaniUgovori()
                            {
                                PotpUgovori = txtUgovor.Text,
                                Kod = 20180605 + r.Next()
                            };
                            pu.Agent = agent;
                            nk.Vlasnik = vlasnik;
                            nk.ZaduzenAgent = agent;
                            s.Save(pu);
                            s.Flush();
                            s.Close();

                            DTOManager.SaveNekretnina(nk);

                            

                        }
                        catch (Exception ec)
                        {
                            MessageBox.Show(ec.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            ISession s = DataLayer.GetSession();
                            NekretninaIznajmljivanjeDuze nd = new NekretninaIznajmljivanjeDuze();
                            nd.GradLokacija = txtLokacija.Text;
                            nd.Ulica = txtUlica.Text;
                            nd.Broj = Int32.Parse(txtBroj.Text);
                            nd.BrojParcele = txtParcela.Text;
                            nd.KatastarskaOpstina = txtOpstina.Text;
                            nd.Tip = cbxTip.SelectedItem.ToString();
                            nd.Kvadratura = Int32.Parse(txtKvadratura.Text);
                            nd.DatumIzgradnje = dtpDatum.Value;
                            nd.Cena = Int32.Parse(txtCena.Text);
                            nd.SpratBrSpratova = txtSpratovi.Text;
                            nd.Opis = txtOpis.Text;
                            nd.IdUgovora = txtUgovor.Text;
                            nd.MaxMeseci = Int32.Parse(txtMaxMeseci.Text);
                            nd.FizickaLicaFirme = cbxLicaFirme.SelectedItem.ToString();

                            Klijent vlasnik = s.Load<Klijent>(Int32.Parse(txtVlasnik.Text));
                            Agent agent = s.Load<Agent>(Int32.Parse(txtAgent.Text));
                            if (vlasnik.NekretnineVlasnik.Count == 0 && !vlasnik.Prodavac.Equals("Da"))
                            {
                                vlasnik.Prodavac = "Da";
                                s.Update(vlasnik);
                            }
                            Random r = new Random();
                            PotpisaniUgovori pu = new PotpisaniUgovori()
                            {
                                PotpUgovori = txtUgovor.Text,
                                Kod = 20180605 + r.Next()
                            };
                            pu.Agent = agent;
                            nd.Vlasnik = vlasnik;
                            nd.ZaduzenAgent = agent;
                            s.Save(pu);
                            s.Flush();
                            s.Close();

                            DTOManager.SaveNekretnina(nd);
                        }
                        catch (Exception ec)
                        {
                            MessageBox.Show(ec.Message);
                        }
                    }
                }
            }
        }
    }
}
