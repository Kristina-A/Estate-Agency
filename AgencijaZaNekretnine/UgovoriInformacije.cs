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
    public partial class UgovoriInformacije : Form
    {
        public UgovoriInformacije()
        {
            InitializeComponent();
        }

        public UgovoriInformacije(int f)
        {
            InitializeComponent();
            if (f == 0 || f == 1)
            {
                btnAzuriraj.Visible = false;
                btnDodaj.Visible = false;
                btnObrisi.Visible = false;
            }
        }

        private void UgovoriInformacije_Load(object sender, EventArgs e)
        {
            this.PopulateInfos();
        }

        private void PopulateInfos()
        {
            listView1.Items.Clear();
            List<UgovorPregled> uInfos = DTOManager.GetUgovorInfos();
            foreach (UgovorPregled u in uInfos)
            {
                ListViewItem item = new ListViewItem(new string[] { u.UgovorId.ToString(),u.UgovorDatum.ToString(),u.NekretninaId.ToString(),u.VlasnikIme,u.VlasnikPrezime,u.KlijentIme,u.KlijentPrezime });
                listView1.Items.Add(item);
            }
            listView1.Refresh();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite ugovor!");
                return;
            }

            int ugId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            try
            {
                ISession s = DataLayer.GetSession();

                Ugovor u = s.Load<Ugovor>(ugId);

                s.Delete(u);

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
            UgovorDodajAzuriraj uda = new UgovorDodajAzuriraj();
            if (uda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                PopulateInfos();
        }

        private void btnAzuriraj_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Odaberite ugovor!");
                return;
            }

            int ugId = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            UgovorBasic ub = DTOManager.GetUgovorBasic(ugId);
            UgovorDodajAzuriraj uda = new UgovorDodajAzuriraj(ub);
            if (uda.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                PopulateInfos();
        }
    }
}
