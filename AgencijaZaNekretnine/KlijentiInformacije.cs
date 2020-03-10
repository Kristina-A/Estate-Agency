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
    public partial class KlijentiInformacije : Form
    {
        public KlijentiInformacije()
        {
            InitializeComponent();
        }

        public KlijentiInformacije(int f)
        {
            InitializeComponent();
            if(f==0 || f==1)
            {
                btnAzuriraj.Visible = false;
                btnDodaj.Visible = false;
                btnObrisi.Visible = false;
            }
        }

        private void KlijentiInformacije_Load(object sender, EventArgs e)
        {
            this.PopulateInfos();
        }

        private void PopulateInfos()
        {
            listView1.Items.Clear();
            List<KlijentPregled> klInfos = DTOManager.GetKlijentInfos();
            foreach (KlijentPregled k in klInfos)
            {
                ListViewItem item = new ListViewItem(new string[] { k.KlijentId.ToString(), k.KlijentIme, k.KlijentPrezime, k.KlijentTelefon, k.KlijentEmail });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite klijenta!");
                return;
            }

            int klId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            try
            {
                ISession s = DataLayer.GetSession();

                Klijent k = s.Load<Klijent>(klId);

                s.Delete(k);

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
            KlijentDodajAzuriraj kda = new KlijentDodajAzuriraj();
            if (kda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                PopulateInfos();
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite klijenta!");
                return;
            }

            int klId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            KlijentBasic kb = DTOManager.GetKlijentBasic(klId);
            KlijentDodajAzuriraj kda = new KlijentDodajAzuriraj(kb);
            if (kda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                PopulateInfos();
        }
    }
}
