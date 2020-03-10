using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgencijaZaNekretnine
{
    public partial class Opcije : Form
    {
        public int flag;
        public Opcije()
        {
            InitializeComponent();
        }

        public Opcije(int f)
        {
            flag = f;
            InitializeComponent();
        }

        private void btnNekretnine_Click(object sender, EventArgs e)
        {
            this.Hide();
            NekretnineInformacije ninfo = new NekretnineInformacije(flag);
            ninfo.ShowDialog();
            this.Close();
        }

        private void btnAgenti_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgentiInformacije ainfo = new AgentiInformacije(flag);
            ainfo.ShowDialog();
            this.Close();
        }

        private void btnKlijenti_Click(object sender, EventArgs e)
        {
            this.Hide();
            KlijentiInformacije kinfo = new KlijentiInformacije(flag);
            kinfo.ShowDialog();
            this.Close();
        }

        private void btnUgovori_Click(object sender, EventArgs e)
        {
            this.Hide();
            UgovoriInformacije uinfo = new UgovoriInformacije(flag);
            uinfo.ShowDialog();
            this.Close();
        }

        private void btnZastupnici_Click(object sender, EventArgs e)
        {
            this.Hide();
            ZastupniciInformacije zinfo = new ZastupniciInformacije(flag);
            zinfo.ShowDialog();
            this.Close();
        }
    }
}
