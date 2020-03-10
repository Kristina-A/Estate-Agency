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
    public partial class UgovorDodajAzuriraj : Form
    {
        private UgovorBasic u;
        public UgovorDodajAzuriraj()
        {
            InitializeComponent();
            u = null;
            lblCena.Visible = false;
            txtCena.Visible = false;
            lblNaknadaNotar.Visible = false;
            txtNotarNaknada.Visible = false;
            lblPeriod.Visible = false;
            txtPeriod.Visible = false;
            lblRenta.Visible = false;
            txtRenta.Visible = false;
        }

        public UgovorDodajAzuriraj(UgovorBasic ug):this()
        {
            u = ug;
            lblDatum.Visible = false;
            dtpDatum.Visible = false;
            lblNotar.Visible = false;
            txtNotar.Visible = false;
            lblNekretnina.Visible = false;
            txtNekretnina.Visible = false;
            lblVlasnik.Visible = false;
            txtVlasnik.Visible = false;
            lblKupac.Visible = false;
            txtKupac.Visible = false;
            lblZastupnikV.Visible = false;
            txtZastupnikV.Visible = false;
            lblZastupnikK.Visible = false;
            txtZastupnikK.Visible = false;

            if(ug.Period==0)
            {
                chkIznajmljivanje.Visible = false;
                chkProdaja.Checked = true;
                chkProdaja.Enabled = false;
                lblCena.Visible = false;
                txtCena.Visible = false;
                lblNaknadaNotar.Visible = false;
                txtNotarNaknada.Visible = false;
            }
            else
            {
                chkProdaja.Visible = false;
                chkIznajmljivanje.Checked = true;
                chkIznajmljivanje.Enabled = false;
                lblRenta.Visible = false;
                txtRenta.Visible = false;
                txtPeriod.Text = ug.Period.ToString();
            }
        }

        private void chkProdaja_CheckedChanged(object sender, EventArgs e)
        {
            if(chkProdaja.Checked)
            {
                chkIznajmljivanje.Checked = false;
                lblCena.Visible = true;
                txtCena.Visible = true;
                lblNaknadaNotar.Visible = true;
                txtNotarNaknada.Visible = true;
            }
            else
            {
                lblCena.Visible = false;
                txtCena.Visible = false;
                lblNaknadaNotar.Visible = false;
                txtNotarNaknada.Visible = false;
            }
        }

        private void chkIznajmljivanje_CheckedChanged(object sender, EventArgs e)
        {
            if(chkIznajmljivanje.Checked)
            {
                chkProdaja.Checked = false;
                lblPeriod.Visible = true;
                txtPeriod.Visible = true;
                lblRenta.Visible = true;
                txtRenta.Visible = true;
            }
            else
            {
                lblPeriod.Visible = false;
                txtPeriod.Visible = false;
                lblRenta.Visible = false;
                txtRenta.Visible = false;
            }
        }

        private void UgovorDodajAzuriraj_Load(object sender, EventArgs e)
        {
            if(u!=null)
            {
                txtAdresa.Text = u.AdresaNotara;
                txtNaknada.Text = u.Naknada.ToString();
                txtBonus.Text = u.Bonus.ToString();
            }
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            if(u!=null)
            {
                UgovorBasic ub = new UgovorBasic();
                ub.AdresaNotara = txtAdresa.Text;
                ub.Naknada = Int32.Parse(txtNaknada.Text);
                ub.Bonus = Int32.Parse(txtBonus.Text);
                ub.UgovorId = u.UgovorId;
                if (u.Period != 0)
                    ub.Period = Int32.Parse(txtPeriod.Text);
                DTOManager.UpdateUgovorBasic(ub);
            }
            else
            {
                if(chkProdaja.Checked)
                {
                    try
                    {
                        ISession s = DataLayer.GetSession();
                        ProdajniUgovor pu = new ProdajniUgovor();
                        pu.Datum = dtpDatum.Value;
                        pu.ImePrezimeNotara = txtNotar.Text;
                        pu.AdresaNotara = txtAdresa.Text;
                        pu.NaknadaAgencija = Int32.Parse(txtNaknada.Text);
                        pu.BonusAgent = Int32.Parse(txtBonus.Text);
                        pu.Cena = Int32.Parse(txtCena.Text);
                        pu.NaknadaNotar = Int32.Parse(txtNotarNaknada.Text);

                        int nekId = Int32.Parse(txtNekretnina.Text);
                        IList<Nekretnina> nekretnina = s.QueryOver<Nekretnina>()
                            .Where(nek => nek.Id == nekId)
                            .List<Nekretnina>();
                        if(nekretnina[0].GetType()!=typeof(NekretninaProdaja))
                        {
                            MessageBox.Show("Nekretnina mora biti na prodaju!");
                            return;
                        }
                        Klijent prodavac = s.Load<Klijent>(Int32.Parse(txtVlasnik.Text));
                        if(prodavac.Id!=nekretnina[0].Vlasnik.Id)
                        {
                            MessageBox.Show("Unet ID vlasnika ne odgovara vlasniku nekretnine!");
                            return;
                        }
                        Klijent kupac = s.Load<Klijent>(Int32.Parse(txtKupac.Text));
                        PravniZastupnik zastupnikProdavac = null;
                        PravniZastupnik zastupnikKupac = null;

                        string zastupnikV = txtZastupnikV.Text;
                        if(!zastupnikV.Equals(""))
                            zastupnikProdavac = s.Load<PravniZastupnik>(Int32.Parse(zastupnikV));
                        string zastupnikK = txtZastupnikK.Text;
                        if (!zastupnikK.Equals(""))
                            zastupnikKupac = s.Load<PravniZastupnik>(Int32.Parse(zastupnikK));

                        pu.PripadaNekretnini = nekretnina[0];
                        pu.Vlasnik = prodavac;
                        pu.ZastupnikVlasnik = zastupnikProdavac;
                        pu.ZastupnikKupacIznajmljivac = zastupnikKupac;
                        pu.KupacIznajmljivac = kupac;
                        if(kupac.Kupac.Equals("Ne"))
                        {
                            kupac.Kupac = "Da";
                            s.Update(kupac);
                        }
                        s.Flush();
                        s.Close();

                        DTOManager.SaveUgovor(pu);
                    }
                    catch (Exception ec)
                    {
                        MessageBox.Show(ec.Message);
                    }
                }
                else
                {
                    if(chkIznajmljivanje.Checked)
                    {
                        try
                        {
                            ISession s = DataLayer.GetSession();
                            IznajmljivanjeUgovor iu = new IznajmljivanjeUgovor();
                            iu.Datum = dtpDatum.Value;
                            iu.ImePrezimeNotara = txtNotar.Text;
                            iu.AdresaNotara = txtAdresa.Text;
                            iu.NaknadaAgencija = Int32.Parse(txtNaknada.Text);
                            iu.BonusAgent = Int32.Parse(txtBonus.Text);
                            iu.PeriodIznajmljivanja = Int32.Parse(txtPeriod.Text);
                            iu.Renta = Int32.Parse(txtRenta.Text);

                            int nekId = Int32.Parse(txtNekretnina.Text);
                            IList<Nekretnina> nekretnina = s.QueryOver<Nekretnina>()
                                .Where(nek => nek.Id == nekId)
                                .List<Nekretnina>();
                            if (nekretnina[0].GetType() != typeof(NekretninaIznajmljivanjeDuze) && nekretnina[0].GetType()!=typeof(NekretninaIznajmljivanjeKrace))
                            {
                                MessageBox.Show("Nekretnina mora biti za iznajmljivanje!");
                                return;
                            }
                            Klijent prodavac = s.Load<Klijent>(Int32.Parse(txtVlasnik.Text));
                            if (prodavac.Id != nekretnina[0].Vlasnik.Id)
                            {
                                MessageBox.Show("Unet ID vlasnika ne odgovara vlasniku nekretnine!");
                                return;
                            }
                            Klijent kupac = s.Load<Klijent>(Int32.Parse(txtKupac.Text));
                            PravniZastupnik zastupnikProdavac = null;
                            PravniZastupnik zastupnikKupac = null;

                            string zastupnikV = txtZastupnikV.Text;
                            if (!zastupnikV.Equals(""))
                                zastupnikProdavac = s.Load<PravniZastupnik>(Int32.Parse(zastupnikV));
                            string zastupnikK = txtZastupnikK.Text;
                            if (!zastupnikK.Equals(""))
                                zastupnikKupac = s.Load<PravniZastupnik>(Int32.Parse(zastupnikK));

                            iu.PripadaNekretnini = nekretnina[0];
                            iu.Vlasnik = prodavac;
                            iu.ZastupnikVlasnik = zastupnikProdavac;
                            iu.ZastupnikKupacIznajmljivac = zastupnikKupac;
                            iu.KupacIznajmljivac = kupac;
                            if (kupac.Kupac.Equals("Ne"))
                            {
                                kupac.Kupac = "Da";
                                s.Update(kupac);
                            }
                            s.Flush();
                            s.Close();

                            DTOManager.SaveUgovor(iu);
                        }
                        catch (Exception ec)
                        {
                            MessageBox.Show(ec.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Morate oznaciti tip ugovora!");
                    }
                }
            }
        }
    }
}
