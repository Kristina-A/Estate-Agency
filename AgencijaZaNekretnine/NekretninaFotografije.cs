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
    public partial class NekretninaFotografije : Form
    {
        Nekretnina n;
        int index;
        public NekretninaFotografije()
        {
            InitializeComponent();
            index = 0;
        }

        public NekretninaFotografije(Nekretnina nekr):this()
        {
            n = nekr;
            btnPrethodna.Visible = false;
            if(n.Fotografije.Count==1)
            {
                btnSledeca.Visible = false;
            }
            byte[] blob = n.Fotografije[index].Sadrzaj;
            string path = Encoding.ASCII.GetString(blob);
            pictureBox1.Image= Image.FromFile(path);
        }

        private void btnSledeca_Click(object sender, EventArgs e)
        {
            index++;
            btnPrethodna.Visible = true;
            if(index<n.Fotografije.Count)
            {
                if(index==n.Fotografije.Count-1)
                {
                    btnSledeca.Visible = false;
                }
                byte[] blob = n.Fotografije[index].Sadrzaj;
                string path = Encoding.ASCII.GetString(blob);
                pictureBox1.Image = Image.FromFile(path);
            }
        }

        private void btnPrethodna_Click(object sender, EventArgs e)
        {
            index--;
            btnSledeca.Visible = true;
            if (index == 0)
                btnPrethodna.Visible = false;
            byte[] blob = n.Fotografije[index].Sadrzaj;
            string path = Encoding.ASCII.GetString(blob);
            pictureBox1.Image = Image.FromFile(path);
        }
    }
}
