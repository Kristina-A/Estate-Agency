using System;
using System.Windows.Forms;
using AgencijaZaNekretnine.Entiteti;
using NHibernate;

namespace AgencijaZaNekretnine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKlijentPrikaz_Click(object sender, EventArgs e)
        {
            try
            {
                var s = DataLayer.GetSession();

                var klijent = s.Load<Klijent>(1);

                MessageBox.Show("Naziv klijenta: " + klijent.Ime + " " + klijent.Prezime
                    + "\nTelefon: " + klijent.Telefon + "\nAdresa: " + klijent.Adresa + "\nE-mail: " + klijent.Email);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnAdminPrikaz_Click(object sender, EventArgs e)
        {
            try
            {
                var s = DataLayer.GetSession();

                var admin = s.Load<Administrator>(1);

                MessageBox.Show("ID administratora: " + admin.Id + "\nSifra: " + admin.Sifra);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnAgentPrikaz_Click(object sender, EventArgs e)
        {
            try
            {
                var s = DataLayer.GetSession();

                var agent = s.Load<Agent>(3);

                MessageBox.Show("Naziv agenta: " + agent.Ime + " " + agent.Prezime
                    + "\nTelefon: " + agent.Telefon + "\nE-mail: " + agent.Email + "\nRadni staz: " + agent.RadniStaz + " godina");

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnUcitajNekretninu_Click(object sender, EventArgs e)
        {
            try
            {
                var s = DataLayer.GetSession();
                
                var nekretnina = s.Load<Nekretnina>(1);

                MessageBox.Show("Ulica: " + nekretnina.Ulica + " " + nekretnina.Broj + 
                    "\nGrad: " + nekretnina.GradLokacija + "\nTip: " + nekretnina.Tip + "\nKvadratura: " + nekretnina.Kvadratura + " m2"
                    + "\nSprat: " + nekretnina.SpratBrSpratova + "\nCena: " + nekretnina.Cena +"\nVlasnik: " + nekretnina.Vlasnik.Ime + " " +
                    nekretnina.Vlasnik.Prezime + "\nAgent: " + nekretnina.ZaduzenAgent.Ime + " " + nekretnina.ZaduzenAgent.Prezime);
                

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnUcitajUgovor_Click(object sender, EventArgs e)
        {
            try
            {
                var s = DataLayer.GetSession();

                var ugovor = s.Load<Ugovor>(1);

                MessageBox.Show("Notar:" + ugovor.ImePrezimeNotara + "\nAdresa notara: " + ugovor.AdresaNotara
                    + "\nDatum: " + ugovor.Datum + "\nNekretnina: " + ugovor.PripadaNekretnini.Ulica + " " + ugovor.PripadaNekretnini.Broj
                    + "\nVlasnik: " + ugovor.Vlasnik.Ime + " " + ugovor.Vlasnik.Prezime + "\nZastupnik: " + ugovor.ZastupnikVlasnik.Ime + " " + ugovor.ZastupnikVlasnik.Prezime
                    + "\nKupac/Iznajmljivac: " + ugovor.KupacIznajmljivac.Ime + " " + ugovor.KupacIznajmljivac.Prezime
                    + "\nZastupnik: " + ugovor.ZastupnikKupacIznajmljivac.Ime + " " + ugovor.ZastupnikKupacIznajmljivac.Prezime);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnUcitajPravnogZastupnika_Click(object sender, EventArgs e)
        {
            try
            {
                var s = DataLayer.GetSession();

                var pravniZastupnik = s.Load<PravniZastupnik>(1);

                MessageBox.Show("\nIme i prezime: " + pravniZastupnik.Ime + " " + pravniZastupnik.Prezime +
                    "\nNaziv kancelarije: " + pravniZastupnik.NazivKancelarije + "\nAdresa: " + pravniZastupnik.AdresaKancelarije + 
                    "\nMBR: " + pravniZastupnik.MBR);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnUcitajPotpisaniUgovor_Click(object sender, EventArgs e)
        {
            try
            {
                var s = DataLayer.GetSession();

                var potpisaniUgovor = s.Load<PotpisaniUgovori>(20181203);

                MessageBox.Show("Potpisan ugovor: " + potpisaniUgovor.PotpUgovori + "\nAgent: " + potpisaniUgovor.Agent.Ime + " " + potpisaniUgovor.Agent.Prezime);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnNoviKlijent_Click(object sender, EventArgs e)
        {
            try
            {
                var s = DataLayer.GetSession();

                Entiteti.Klijent noviKlijent = new Entiteti.Klijent()
                {
                    Email = "milosTeodosic@gmail.com",
                    Sifra = "teo09",
                    Ime = "Milos",
                    Prezime = "Teodosic",
                    Adresa = "Downtown LA",
                    Telefon = "064-4851254",
                    Kupac = "Da",
                    Prodavac = "Ne"
                };

                s.Save(noviKlijent);
                s.Flush();
                MessageBox.Show("Uspesno dodat novi klijent!");

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnNoviAgent_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Agent noviAgent = new Entiteti.Agent()
                {
                    Ime = "Slavisa",
                    Prezime = "Jokanovic",
                    RadniStaz = 1,
                    Telefon = "061-4565471",
                    Email = "slavisaJokan@gmail.com",
                    Sifra = "jokanMajstor"
                };

                s.Save(noviAgent);
                s.Flush();
                MessageBox.Show("Uspesno dodat novi agent!");

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnNovaNekretnina_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                NekretninaProdaja novaNekretnina = new NekretninaProdaja()
                {
                    GradLokacija = "Nis Medijana",
                    Ulica = "Milojka Lesjanina",
                    Broj = 14,
                    BrojParcele = "213/14",
                    KatastarskaOpstina = "Brzi Brod",
                    Tip = "STAN",
                    Kvadratura = 34,
                    DatumIzgradnje = DateTime.Now,
                    Cena = 30000,
                    SpratBrSpratova = "5/5",
                    Opis = "Jednosoban stan u centru grada blizu Ekonomskog i Pravnog fakulteta. Pogodan za dva studenta.",
                    IdUgovora = "25/2017"
                };

                Klijent klijent = s.Load<Klijent>(3);
                Agent agent = s.Load<Agent>(6);

                novaNekretnina.Vlasnik = klijent;
                novaNekretnina.ZaduzenAgent = agent;

                klijent.NekretnineVlasnik.Add(novaNekretnina);
                agent.Nekretnine.Add(novaNekretnina);

                s.Save(novaNekretnina);
                s.Flush();
                MessageBox.Show("Uspesno dodata nova nekretnina!");

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnNoviUgovor_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ProdajniUgovor ugovor = new ProdajniUgovor()
                {
                    ImePrezimeNotara = "Slavica Djukic",
                    AdresaNotara = "Bulevar Nemanjica BB",
                    Datum = DateTime.Now,
                    NaknadaAgencija = 500,
                    BonusAgent = 40,
                    Cena = 30000,
                    NaknadaNotar = 150  
                };

                Nekretnina nekretnina = s.Load<Nekretnina>(6);
                Klijent prodavac = s.Load<Klijent>(3);
                PravniZastupnik zastupnikProdavac = s.Load<PravniZastupnik>(4);
                Klijent kupac = s.Load<Klijent>(7);
                PravniZastupnik zastupnikKupac = s.Load<PravniZastupnik>(6);

                ugovor.PripadaNekretnini = nekretnina;
                ugovor.Vlasnik = prodavac;
                ugovor.ZastupnikVlasnik = zastupnikProdavac;
                ugovor.ZastupnikKupacIznajmljivac = zastupnikKupac;
                ugovor.KupacIznajmljivac = kupac;

                nekretnina.Ugovor = ugovor;
                prodavac.PotpisaniProdavac.Add(ugovor);
                kupac.PotpisaniKupac.Add(ugovor);
                zastupnikProdavac.AngazovaoProdavac.Add(ugovor);
                zastupnikKupac.AngazovaoKupac.Add(ugovor);

                s.Save(ugovor);
                s.Flush();
                MessageBox.Show("Uspesno dodat novi ugovor!");

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnNoviZastupnik_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PravniZastupnik pravniZastupnik = new PravniZastupnik()
                {
                    MBR = "0507965123563",
                    Ime = "Simo",
                    Prezime = "Matavulj",
                    NazivKancelarije = "Simo d.o.o",
                    AdresaKancelarije = "Vuka Karadzica BB"
                };

                s.Save(pravniZastupnik);
                s.Flush();
                MessageBox.Show("Uspesno dodat novi pravni zastupnik!");

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnNoviPotpisaniUgovor_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PotpisaniUgovori potpisaniUgovor = new PotpisaniUgovori()
                {
                    PotpUgovori = "25/2017",
                    Kod = 20123415
                    
                };

                Agent agent = s.Load<Agent>(6);
                potpisaniUgovor.Agent = agent;
                agent.Ugovori.Add(potpisaniUgovor);

                s.Save(potpisaniUgovor);
                MessageBox.Show("Uspesno dodat novi potpisani ugovor!");
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnVisevr_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                var agent = s.Load<Agent>(3);
                string str="Ugovori:\n";
                foreach(var u in agent.Ugovori)
                {
                    str +=u.PotpUgovori+"\n";
                }
                MessageBox.Show(str);
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnAgentNekr_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                var agent = s.Load<Agent>(3);
                string str = "Nekretnine:\n";
                foreach (var n in agent.Nekretnine)
                {
                    str += n.GradLokacija + " " + n.Ulica + n.Broj + " " + n.Tip + "\n";
                }
                MessageBox.Show(str);
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnKlijentNekr_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                var klijent = s.Load<Klijent>(6);
                string str = "Nekretnine:\n";
                foreach (var n in klijent.NekretnineVlasnik)
                {
                    str += n.GradLokacija + " " + n.Ulica + n.Broj + " " + n.Tip + "\n";
                }
                MessageBox.Show(str);
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnKlijentUgovor_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                var klijent = s.Load<Klijent>(1);
                string str = "Ugovori:\n";
                foreach (var u in klijent.PotpisaniKupac)
                {
                    str += "Datum:"+u.Datum + " Notar:" + u.ImePrezimeNotara +" " + u.AdresaNotara + "\n";
                }
                MessageBox.Show(str);
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnZastupnikUgovor_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                var zastupnik = s.Load<PravniZastupnik>(1);
                string str = "Ugovori:\n";
                foreach (var u in zastupnik.AngazovaoProdavac)
                {
                    str += "Datum:" + u.Datum + " Notar:" + u.ImePrezimeNotara + " " + u.AdresaNotara +" Klijent:"+u.Vlasnik.Ime+" "+u.Vlasnik.Prezime+ "\n";
                }
                MessageBox.Show(str);
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.ShowDialog();
            this.Close();
        }
    }       
}
