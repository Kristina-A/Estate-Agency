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
    public partial class KlijentDodajAzuriraj : Form
    {
        private KlijentBasic k;
        public KlijentDodajAzuriraj()
        {
            InitializeComponent();
            k = null;
        }

        public KlijentDodajAzuriraj (KlijentBasic kb)
        {
            InitializeComponent();
            k = kb;
            lblIme.Visible = false;
            lblPrezime.Visible = false;
            txtIme.Visible = false;
            txtPrezime.Visible = false;
        }

        private void KlijentDodajAzuriraj_Load(object sender, EventArgs e)
        {
            if(k!=null)
            {
                txtAdresa.Text = k.KlijentAdresa;
                txtTelefon.Text = k.KlijentTelefon;
                txtEmail.Text = k.KlijentEmail;
                txtSifra.Text = k.KlijentSifra;
                cbxKupac.SelectedItem = k.Kupac;
                cbxProdavac.SelectedItem = k.Prodavac;
            }
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            if (k != null)
            {
                KlijentBasic kb = new KlijentBasic();
                kb.KlijentEmail = txtEmail.Text;
                kb.KlijentTelefon = txtTelefon.Text;
                kb.KlijentSifra = txtSifra.Text;
                kb.KlijentAdresa = txtAdresa.Text;
                kb.Kupac = cbxKupac.SelectedItem.ToString();
                kb.Prodavac = cbxProdavac.SelectedItem.ToString();
                kb.KlijentId = k.KlijentId;
                DTOManager.UpdateKlijentBasic(kb);
            }
            else
            {
                Klijent kl = new Klijent();
                kl.Ime = txtIme.Text;
                kl.Prezime = txtPrezime.Text;
                kl.Telefon = txtTelefon.Text;
                kl.Email = txtEmail.Text;
                kl.Sifra = txtSifra.Text;
                kl.Adresa = txtAdresa.Text;
                kl.Kupac = cbxKupac.SelectedItem.ToString();
                kl.Prodavac = cbxProdavac.SelectedItem.ToString();
                DTOManager.SaveKlijent(kl);
            }
        }
    }
}
