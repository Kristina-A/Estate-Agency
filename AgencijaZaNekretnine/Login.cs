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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void chkKlijent_CheckedChanged(object sender, EventArgs e)
        {
            if(chkKlijent.Checked)
            {
                chkAdmin.Checked = false;
                chkAgent.Checked = false;
            }
        }

        private void chkAgent_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAgent.Checked)
            {
                chkKlijent.Checked = false;
                chkAdmin.Checked = false;
            }
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAdmin.Checked)
            {
                chkAgent.Checked = false;
                chkKlijent.Checked = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IQuery q;

                String password = txtPass.Text;

                if (chkKlijent.Checked)
                {
                    String usern = txtUser.Text;
                    q = s.CreateQuery("select k from Klijent k where k.Email= :email and k.Sifra= :pass");
                    q.SetString("email", usern);
                    q.SetString("pass", password);
                    Klijent k = q.UniqueResult<Klijent>();
                    if (k != null)
                    {
                        this.Hide();
                        Opcije p = new Opcije(0);
                        p.ShowDialog();
                        this.Close();
                    }
                    else
                        MessageBox.Show("proverite username i password");
                }
                else
                {
                    if(chkAgent.Checked)
                    {
                        int id = Int32.Parse(txtUser.Text);
                        q = s.CreateQuery("select a from Agent a where a.Id= :id and a.Sifra= :pass");
                        q.SetInt32("id", id);
                        q.SetString("pass", password);
                        Agent a = q.UniqueResult<Agent>();
                        if (a != null)
                        {
                            this.Hide();
                            Opcije p = new Opcije(1);
                            p.ShowDialog();
                            this.Close();
                        }
                        else
                            MessageBox.Show("proverite username i password");
                    }
                    else
                    {
                        if (chkAdmin.Checked)
                        {
                            int id = int.Parse(txtUser.Text);
                            q = s.CreateQuery("select a from Administrator a where a.Id= :id and a.Sifra= :pass");
                            q.SetInt32("id", id);
                            q.SetString("pass", password);
                            Administrator a = q.UniqueResult<Administrator>();
                            if (a != null)
                            {
                                this.Hide();
                                Opcije p = new Opcije(2);
                                p.ShowDialog();
                                this.Close();
                            }
                            else
                                MessageBox.Show("proverite username i password");
                        }
                        else
                            MessageBox.Show("izaberite status");
                    }
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
    }
}
