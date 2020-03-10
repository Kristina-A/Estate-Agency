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
    public partial class ZastupniciInformacije : Form
    {
        public ZastupniciInformacije()
        {
            InitializeComponent();
        }

        public ZastupniciInformacije(int f)
        {
            InitializeComponent();
            if (f == 0 || f == 1)
            {
                btnAzuriraj.Visible = false;
                btnDodaj.Visible = false;
                btnObrisi.Visible = false;
            }
        }

        private void ZastupniciInformacije_Load(object sender, EventArgs e)
        {
            this.PopulateInfos();
        }

        private void PopulateInfos()
        {
            listView1.Items.Clear();
            List<ZastupnikPregled> zaInfos = DTOManager.GetZastupnikInfos();
            foreach (ZastupnikPregled z in zaInfos)
            {
                ListViewItem item = new ListViewItem(new string[] { z.ZastupnikId.ToString(), z.ZastupnikIme, z.ZastupnikPrezime, z.ZastupnikAdresa });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite pravnog zastupnika!");
                return;
            }

            int zId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            try
            {
                ISession s = DataLayer.GetSession();

                PravniZastupnik pz = s.Load<PravniZastupnik>(zId);

                s.Delete(pz);

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
            ZastupnikDodajAzuriraj zda = new ZastupnikDodajAzuriraj();
            if (zda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.PopulateInfos();
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite pravnog zastupnika!");
                return;
            }

            int zId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            ZastupnikBasic zb = DTOManager.GetZastupnikBasic(zId);
            ZastupnikDodajAzuriraj zda = new ZastupnikDodajAzuriraj(zb);
            if (zda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                PopulateInfos();
        }
    }
}
