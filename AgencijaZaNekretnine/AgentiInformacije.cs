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
    public partial class AgentiInformacije : Form
    {
        public AgentiInformacije()
        {
            InitializeComponent();
        }

        public AgentiInformacije(int f)
        {
            InitializeComponent();
            if(f==0 || f==1)
            {
                btnAzuriraj.Visible = false;
                btnDodaj.Visible = false;
                btnObrisi.Visible = false;
            }
        }

        private void PopulateInfos()
        {
            listView1.Items.Clear();
            List<AgentPregled> agInfos = DTOManager.GetAgentInfos();
            foreach (AgentPregled a in agInfos)
            {
                ListViewItem item = new ListViewItem(new string[] { a.AgentId.ToString(), a.AgentIme, a.AgentPrezime, a.AgentTelefon, a.AgentEmail });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void AgentiInformacije_Load(object sender, EventArgs e)
        {
            this.PopulateInfos();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite agenta!");
                return;
            }

            int agId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            try
            {
                ISession s = DataLayer.GetSession();

                Agent a = s.Load<Agent>(agId);

                s.Delete(a);

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
            AgentDodajAzuriraj ag = new AgentDodajAzuriraj();
            if (ag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                PopulateInfos();
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite agenta!");
                return;
            }

            int agId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            AgentBasic ab = DTOManager.GetAgentBasic(agId);
            AgentDodajAzuriraj ada = new AgentDodajAzuriraj(ab);
            if (ada.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                PopulateInfos();
        }
    }
}
