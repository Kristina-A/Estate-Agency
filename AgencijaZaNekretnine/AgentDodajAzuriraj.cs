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
    public partial class AgentDodajAzuriraj : Form
    {
        private AgentBasic a;
        public AgentDodajAzuriraj()
        {
            InitializeComponent();
            a = null;
        }

        public AgentDodajAzuriraj(AgentBasic ag)
        {
            InitializeComponent();
            a = ag;
            label1.Visible = false;
            txtIme.Visible = false;
            label2.Visible = false;
            txtPrezime.Visible = false;
        }

        private void btnSnimi_Click(object sender, EventArgs e)
        {
            if(a!=null)
            {
                AgentBasic ab = new AgentBasic();
                ab.AgentEmail = txtEmail.Text;
                ab.AgentTelefon = txtTelefon.Text;
                ab.AgentSifra = txtSifra.Text;
                ab.AgentStaz = (int)numStaz.Value;
                ab.AgentId = a.AgentId;
                DTOManager.UpdateAgentBasic(ab);
            }
            else
            {
                Agent ag = new Agent();
                ag.Ime = txtIme.Text;
                ag.Prezime = txtPrezime.Text;
                ag.Telefon = txtTelefon.Text;
                ag.Email = txtEmail.Text;
                ag.Sifra = txtSifra.Text;
                ag.RadniStaz = (int)numStaz.Value;
                DTOManager.SaveAgent(ag);
            }
        }

        private void AgentDodajAzuriraj_Load(object sender, EventArgs e)
        {
            if(a!=null)
            {
                txtTelefon.Text = a.AgentTelefon;
                txtEmail.Text = a.AgentEmail;
                txtSifra.Text = a.AgentSifra;
                numStaz.Value = a.AgentStaz;
            }
        }
    }
}
