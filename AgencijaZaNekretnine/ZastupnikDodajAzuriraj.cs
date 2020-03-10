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
    public partial class ZastupnikDodajAzuriraj : Form
    {
        private ZastupnikBasic z;
        public ZastupnikDodajAzuriraj()
        {
            InitializeComponent();
            z = null;
        }

        public ZastupnikDodajAzuriraj(ZastupnikBasic zb)
        {
            InitializeComponent();
            z = zb;
            lblMbr.Visible = false;
            txtMbr.Visible = false;
            lblIme.Visible = false;
            txtIme.Visible = false;
            lblPrezime.Visible = false;
            txtPrezime.Visible = false;
        }

        private void ZastupnikDodajAzuriraj_Load(object sender, EventArgs e)
        {
            if(z!=null)
            {
                txtNaziv.Text = z.NazivKancelarije;
                txtAdresa.Text = z.AdresaKancelarije;
            }
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            if (z != null)
            {
                ZastupnikBasic zb = new ZastupnikBasic();
                zb.AdresaKancelarije = txtAdresa.Text;
                zb.NazivKancelarije = txtNaziv.Text;
                zb.ZastupnikId = z.ZastupnikId;
                DTOManager.UpdateZastupnikBasic(zb);
            }
            else
            {
                PravniZastupnik pz = new PravniZastupnik();
                pz.Ime = txtIme.Text;
                pz.Prezime = txtPrezime.Text;
                pz.MBR = txtMbr.Text;
                pz.NazivKancelarije = txtNaziv.Text;
                pz.AdresaKancelarije = txtAdresa.Text;
                DTOManager.SaveZastupnik(pz);
            }
        }
    }
}
