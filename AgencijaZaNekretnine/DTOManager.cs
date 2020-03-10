using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgencijaZaNekretnine.Entiteti;
using NHibernate;

namespace AgencijaZaNekretnine
{
    public class DTOManager
    {

        //Funkcije za pregled entiteta
        public static List<NekretninaPregled> GetNekrInfos()
        {
            List<NekretninaPregled> nekrInfos = new List<NekretninaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Nekretnina");

                IList<Nekretnina> nekretnine = q.List<Nekretnina>();
                string pi;

                foreach (Nekretnina n in nekretnine)
                {
                    if (n.GetType() == typeof(NekretninaProdaja))
                        pi = "prodaja";
                    else
                        pi = "iznajmljivanje";
                    nekrInfos.Add(new NekretninaPregled(n.Id, n.GradLokacija, n.Ulica, n.Tip, n.Kvadratura, n.Cena, pi, n.Vlasnik.Ime, n.Vlasnik.Prezime));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return nekrInfos;
        }

        public static List<AgentPregled> GetAgentInfos()
        {
            List<AgentPregled> agInfos = new List<AgentPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Agent");

                IList<Agent> agenti = q.List<Agent>();

                foreach (Agent a in agenti)
                {
                    agInfos.Add(new AgentPregled(a.Id, a.Ime, a.Prezime, a.Telefon,a.Email));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return agInfos;
        }

        public static List<KlijentPregled> GetKlijentInfos()
        {
            List<KlijentPregled> klInfos = new List<KlijentPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Klijent");

                IList<Klijent> klijenti = q.List<Klijent>();

                foreach (Klijent k in klijenti)
                {
                    klInfos.Add(new KlijentPregled(k.Id, k.Ime, k.Prezime, k.Telefon, k.Email));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return klInfos;
        }

        public static List<ZastupnikPregled> GetZastupnikInfos()
        {
            List<ZastupnikPregled> zaInfos = new List<ZastupnikPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from PravniZastupnik");

                IList<PravniZastupnik> zastupnici = q.List<PravniZastupnik>();

                foreach (PravniZastupnik p in zastupnici)
                {
                    zaInfos.Add(new ZastupnikPregled(p.Id, p.Ime, p.Prezime, p.AdresaKancelarije));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return zaInfos;
        }

        public static List<UgovorPregled> GetUgovorInfos()
        {
            List<UgovorPregled> uInfos = new List<UgovorPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Ugovor");

                IList<Ugovor> ugovori = q.List<Ugovor>();

                foreach (Ugovor u in ugovori)
                {
                    uInfos.Add(new UgovorPregled(u.Broj, u.Datum, u.PripadaNekretnini.Id, u.Vlasnik.Ime,u.Vlasnik.Prezime,u.KupacIznajmljivac.Ime,u.KupacIznajmljivac.Prezime));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return uInfos;
        }


        //Funkcije za update i save entiteta
        public static AgentBasic GetAgentBasic(int id)
        {
            AgentBasic ab = new AgentBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Agent a = s.Load<Agent>(id);
                ab = new AgentBasic(a.Id, a.Telefon, a.Email, a.Sifra, a.RadniStaz);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return ab;
        }

        public static void UpdateAgentBasic(AgentBasic ab)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Agent a = s.Load<Agent>(ab.AgentId);

                a.Telefon = ab.AgentTelefon;
                a.Email = ab.AgentEmail;
                a.Sifra = ab.AgentSifra;
                a.RadniStaz = ab.AgentStaz;

                s.Update(a);
                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static void SaveAgent(Agent a)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Save(a);
                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static ZastupnikBasic GetZastupnikBasic(int id)
        {
            ZastupnikBasic zb = new ZastupnikBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                PravniZastupnik z = s.Load<PravniZastupnik>(id);
                zb = new ZastupnikBasic(z.Id, z.NazivKancelarije, z.AdresaKancelarije);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return zb;
        }

        public static void UpdateZastupnikBasic(ZastupnikBasic zb)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                PravniZastupnik z = s.Load<PravniZastupnik>(zb.ZastupnikId);

                z.AdresaKancelarije = zb.AdresaKancelarije;
                z.NazivKancelarije = zb.NazivKancelarije;

                s.Update(z);
                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static void SaveZastupnik(PravniZastupnik z)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Save(z);
                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static KlijentBasic GetKlijentBasic(int id)
        {
            KlijentBasic kb = new KlijentBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                Klijent k = s.Load<Klijent>(id);
                kb = new KlijentBasic(k.Id, k.Email, k.Sifra, k.Adresa,k.Telefon, k.Kupac, k.Prodavac);

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return kb;
        }

        public static void UpdateKlijentBasic(KlijentBasic kb)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Klijent k = s.Load<Klijent>(kb.KlijentId);

                k.Email = kb.KlijentEmail;
                k.Sifra = kb.KlijentSifra;
                k.Adresa = kb.KlijentAdresa;
                k.Telefon = kb.KlijentTelefon;
                k.Kupac = kb.Kupac;
                k.Prodavac = kb.Prodavac;

                s.Update(k);
                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static void SaveKlijent(Klijent k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Save(k);
                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static UgovorBasic GetUgovorBasic(int id)
        {
            UgovorBasic ub = new UgovorBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Ugovor> u = s.QueryOver<Ugovor>()
                   .Where(ug => ug.Broj == id)
                   .List<Ugovor>();
                if(u[0].GetType()==typeof(ProdajniUgovor))
                    ub = new UgovorBasic(u[0].Broj, u[0].AdresaNotara, u[0].NaknadaAgencija, u[0].BonusAgent);
                else
                {
                    IznajmljivanjeUgovor iu = (IznajmljivanjeUgovor)u[0];
                    ub = new UgovorBasic(iu.Broj, iu.AdresaNotara, iu.NaknadaAgencija, iu.BonusAgent, iu.PeriodIznajmljivanja);
                }


                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return ub;
        }

        public static void UpdateUgovorBasic(UgovorBasic ub)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Ugovor> u = s.QueryOver<Ugovor>()
                   .Where(ug => ug.Broj == ub.UgovorId)
                   .List<Ugovor>();
                ProdajniUgovor pu = null;
                IznajmljivanjeUgovor iu = null;

                if(u[0].GetType()==typeof(ProdajniUgovor))
                {
                    pu = (ProdajniUgovor)u[0];
                    pu.AdresaNotara = ub.AdresaNotara;
                    pu.NaknadaAgencija = ub.Naknada;
                    pu.BonusAgent = ub.Bonus;
                }
                else
                {
                    iu = (IznajmljivanjeUgovor)u[0];
                    iu.AdresaNotara = ub.AdresaNotara;
                    iu.NaknadaAgencija = ub.Naknada;
                    iu.BonusAgent = ub.Bonus;
                    iu.PeriodIznajmljivanja = ub.Period;
                }

                if (pu != null)
                    s.Update(pu);
                else
                    s.Update(iu);
                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static void SaveUgovor(Ugovor u)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Save(u);
                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static NekretninaBasic GetNekretninaBasic(int id)
        {
            NekretninaBasic nb = new NekretninaBasic();
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Nekretnina> n = s.QueryOver<Nekretnina>()
                    .Where(nek => nek.Id == id)
                    .List<Nekretnina>();

                if(n[0].GetType()==typeof(NekretninaProdaja))
                    nb = new NekretninaBasic(n[0].Id, n[0].Ulica, n[0].Cena, n[0].SpratBrSpratova, n[0].Opis);
                else
                {
                    if (n[0].GetType() == typeof(NekretninaIznajmljivanjeKrace))
                    {
                        NekretninaIznajmljivanjeKrace nk = (NekretninaIznajmljivanjeKrace)n[0];
                        nb = new NekretninaBasic(nk.Id, nk.Ulica, nk.Cena, nk.SpratBrSpratova, nk.Opis, nk.DatumOd, nk.DatumDo);
                    }
                    else
                    {
                        NekretninaIznajmljivanjeDuze nd = (NekretninaIznajmljivanjeDuze)n[0];
                        nb = new NekretninaBasic(nd.Id, nd.Ulica, nd.Cena, nd.SpratBrSpratova, nd.Opis, nd.MaxMeseci);
                    }
                }

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            return nb;
        }

        public static void UpdateNekretninaBasic(NekretninaBasic nb)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                IList<Nekretnina> n = s.QueryOver<Nekretnina>()
                    .Where(nek => nek.Id == nb.NekretninaId)
                    .List<Nekretnina>();
                NekretninaProdaja np = null;
                NekretninaIznajmljivanjeKrace nk = null;
                NekretninaIznajmljivanjeDuze nd = null;

                if(n[0].GetType()==typeof(NekretninaProdaja))
                {
                    np = (NekretninaProdaja)n[0];
                    np.Ulica = nb.Ulica;
                    np.Cena = nb.Cena;
                    np.Opis = nb.Opis;
                    np.SpratBrSpratova = nb.SpratBrojSpratova;
                }
                else
                {
                    if(n[0].GetType()==typeof(NekretninaIznajmljivanjeKrace))
                    {
                        nk = (NekretninaIznajmljivanjeKrace)n[0];
                        nk.Ulica = nb.Ulica;
                        nk.Cena = nb.Cena;
                        nk.Opis = nb.Opis;
                        nk.SpratBrSpratova = nb.SpratBrojSpratova;
                        nk.DatumOd = nb.DatumOd;
                        nk.DatumDo = nb.DatumDo;
                    }
                    else
                    {
                        nd = (NekretninaIznajmljivanjeDuze)n[0];
                        nd.Ulica = nb.Ulica;
                        nd.Cena = nb.Cena;
                        nd.Opis = nb.Opis;
                        nd.SpratBrSpratova = nb.SpratBrojSpratova;
                        nd.MaxMeseci = nb.Meseci;
                    }
                }

                if (np != null)
                    s.Update(np);
                else
                {
                    if (nk != null)
                        s.Update(nk);
                    else
                        s.Update(nd);
                }

                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        public static void SaveNekretnina(Nekretnina n)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Save(n);
                s.Flush();

                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        //4 faza, koriste se i funkcije iz prethodne faze
        #region Administrator
        public static IEnumerable<Administrator> GetAdmini()
        {
            ISession s = DataLayer.GetSession();

            IEnumerable<Administrator> admini = s.Query<Administrator>().Select(a => a);

            return admini;
        }

        public static Administrator GetAdmin(int id)
        {
            ISession s = DataLayer.GetSession();

            return s.Query<Administrator>()
                .Where(a => a.Id == id).Select(a => a).FirstOrDefault();
        }

        public static void removeAdmin(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Administrator a = s.Load<Administrator>(id);

                s.Delete(a);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }

        public static void addAdmin(Administrator a)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Save(a);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
            }
        }

        public static void updateAdmin(int id, Administrator a)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Administrator ad = s.Load<Administrator>(id);
                ad.Sifra = a.Sifra;
                s.Update(ad);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }
        #endregion

        #region Pravni zastupnik
        public static void removeZastupnik(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PravniZastupnik pz = s.Load<PravniZastupnik>(id);

                s.Delete(pz);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }

        public static ZastupnikView getZastupnikView(int id)
        {
            ISession s = DataLayer.GetSession();

            PravniZastupnik pz = s.Query<PravniZastupnik>()
                .Where(prav => prav.Id == id).Select(p => p).FirstOrDefault();

            if (pz == null) return new ZastupnikView();

            return new ZastupnikView(pz);
        }

        public static void addZastupnik(PravniZastupnik pz)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Save(pz);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
            }
        }

        public static void updateZastupnik(int id, PravniZastupnik pz)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                PravniZastupnik p = s.Load<PravniZastupnik>(id);
                p.Ime = pz.Ime;
                p.Prezime = pz.Prezime;
                p.NazivKancelarije = pz.NazivKancelarije;
                p.AdresaKancelarije = pz.AdresaKancelarije;
                s.Update(p);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }
        #endregion

        #region Agent
        public static void removeAgent(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Agent a = s.Load<Agent>(id);

                s.Delete(a);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }

        public static AgentView getAgentView(int id)
        {
            ISession s = DataLayer.GetSession();

            Agent a = s.Query<Agent>()
                .Where(ag => ag.Id == id).Select(p => p).FirstOrDefault();

            if (a == null) return new AgentView();

            return new AgentView(a);
        }

        public static void addAgent(Agent a)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Save(a);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
            }
        }

        public static void updateAgent(int id, Agent a)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Agent ag = s.Load<Agent>(id);
                ag.Ime = a.Ime;
                ag.Prezime = a.Prezime;
                ag.RadniStaz = a.RadniStaz;
                ag.Telefon = a.Telefon;
                ag.Email = a.Email;
                ag.Sifra = a.Sifra;
                s.Update(ag);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }
        #endregion

        #region Klijent
        public static void removeKlijent(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Klijent k = s.Load<Klijent>(id);

                s.Delete(k);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }

        public static KlijentView getKlijentView(int id)
        {
            ISession s = DataLayer.GetSession();

            Klijent k = s.Query<Klijent>()
                .Where(kl => kl.Id == id).Select(p => p).FirstOrDefault();

            if (k == null) return new KlijentView();

            return new KlijentView(k);
        }

        public static void addKlijent(Klijent k)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                s.Save(k);

                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
            }
        }

        public static void updateKlijent(int id, Klijent kl)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Klijent k = s.Load<Klijent>(id);
                k.Ime = kl.Ime;
                k.Prezime = kl.Prezime;
                k.Email = kl.Email;
                k.Sifra = kl.Sifra;
                k.Adresa = kl.Adresa;
                k.Telefon = kl.Telefon;
                k.Kupac = kl.Kupac;
                k.Prodavac = kl.Prodavac;
                s.Update(k);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }
        #endregion

        #region Nekretnine
        public static IEnumerable<NekretninaProdajaPregled> getNekretnineProdajaView()
        {
            ISession s = DataLayer.GetSession();
            IList<NekretninaProdaja> nekr = s.QueryOver<Nekretnina>().Where(a=>a.GetType()==typeof(NekretninaProdaja)).List<NekretninaProdaja>();
            List<NekretninaProdajaPregled> n = new List<NekretninaProdajaPregled>();
            foreach (var v in nekr)
                n.Add(new NekretninaProdajaPregled(v));
            return (n.AsEnumerable<NekretninaProdajaPregled>());
        }

        public static IEnumerable<NekrIznDuzePregled> getNekretnineDuzeView()
        {
            ISession s = DataLayer.GetSession();
            IList<NekretninaIznajmljivanjeDuze> nekr = s.QueryOver<Nekretnina>().Where(a=>a.GetType()==typeof(NekretninaIznajmljivanjeDuze)).List<NekretninaIznajmljivanjeDuze>();
            List<NekrIznDuzePregled> n = new List<NekrIznDuzePregled>();
            foreach (var v in nekr)
                n.Add(new NekrIznDuzePregled((NekretninaIznajmljivanjeDuze)v));
            return (n.AsEnumerable<NekrIznDuzePregled>());
        }

        public static IEnumerable<NekrIznKracePregled> getNekretnineKraceView()
        {
            ISession s = DataLayer.GetSession();
            IList<NekretninaIznajmljivanjeKrace> nekr = s.QueryOver<Nekretnina>().Where(a=>a.GetType()==typeof(NekretninaIznajmljivanjeKrace)).List<NekretninaIznajmljivanjeKrace>();
            List<NekrIznKracePregled> n = new List<NekrIznKracePregled>();
            foreach (var v in nekr)
                    n.Add(new NekrIznKracePregled((NekretninaIznajmljivanjeKrace)v));
            return (n.AsEnumerable<NekrIznKracePregled>());
        }

        public static void removeNekretnina(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Nekretnina n = s.Load<Nekretnina>(id);

                s.Delete(n);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }

        public static NekretninaProdajaPregled GetNekretninaProdaja(int id)
        {
            ISession s = DataLayer.GetSession();

            NekretninaProdaja np = (NekretninaProdaja)s.Query<Nekretnina>().Where(a => a.Id == id).Select(a => a).FirstOrDefault();
            return (new NekretninaProdajaPregled(np));
        }

        public static NekrIznDuzePregled GetNekretninaIznDuze(int id)
        {
            ISession s = DataLayer.GetSession();

            NekretninaIznajmljivanjeDuze nid = (NekretninaIznajmljivanjeDuze)s.Query<Nekretnina>().Where(a => a.Id == id).Select(a => a).FirstOrDefault();
            return (new NekrIznDuzePregled(nid));
        }

        public static NekrIznKracePregled GetNekretninaIznKrace(int id)
        {
            ISession s = DataLayer.GetSession();

            NekretninaIznajmljivanjeKrace nik = (NekretninaIznajmljivanjeKrace)s.Query<Nekretnina>().Where(a => a.Id == id).Select(a => a).FirstOrDefault();
            return (new NekrIznKracePregled(nik));
        }

        public static void addNekretninaProdaja(NekretninaProdajaAddUpdate n)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                NekretninaProdaja np = new NekretninaProdaja()
                {
                    GradLokacija = n.GradLokacija,
                    Ulica = n.Ulica,
                    Broj = n.Broj,
                    BrojParcele = n.BrojParcele,
                    KatastarskaOpstina = n.KatastarskaOpstina,
                    Tip = n.Tip,
                    Kvadratura = n.Kvadratura,
                    DatumIzgradnje = n.DatumIzgradnje,
                    Cena = n.Cena,
                    SpratBrSpratova = n.SpratBrSpratova,
                    Opis = n.Opis,
                    IdUgovora = n.IdUgovora
                };

                np.Vlasnik = s.Load<Klijent>(n.Vlasnik);
                np.ZaduzenAgent = s.Load<Agent>(n.ZaduzenAgent);

                s.Save(np);

                s.Flush();
                s.Close();
            }
            catch(Exception exc)
            {

            }
        }

        public static void updateNekretninaProdaja(int id, NekretninaProdajaAddUpdate n)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Nekretnina nek = s.Query<Nekretnina>().Where(a => a.Id == id).FirstOrDefault();
                NekretninaProdaja np = (NekretninaProdaja)nek;
                np.GradLokacija = n.GradLokacija;
                np.Ulica = n.Ulica;
                np.Broj = n.Broj;
                np.BrojParcele = n.BrojParcele;
                np.KatastarskaOpstina = n.KatastarskaOpstina;
                np.Tip = n.Tip;
                np.Kvadratura = n.Kvadratura;
                np.DatumIzgradnje = n.DatumIzgradnje;
                np.Cena = n.Cena;
                np.SpratBrSpratova = n.SpratBrSpratova;
                np.Opis = n.Opis;
                np.IdUgovora = n.IdUgovora;
                np.Vlasnik = s.Load<Klijent>(n.Vlasnik);
                np.ZaduzenAgent = s.Load<Agent>(n.ZaduzenAgent);

                s.Update(np);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }

        public static void addNekretninaDuze(NekrIznDuzeAddUpdate n)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                NekretninaIznajmljivanjeDuze nd = new NekretninaIznajmljivanjeDuze()
                {
                    GradLokacija = n.GradLokacija,
                    Ulica = n.Ulica,
                    Broj = n.Broj,
                    BrojParcele = n.BrojParcele,
                    KatastarskaOpstina = n.KatastarskaOpstina,
                    Tip = n.Tip,
                    Kvadratura = n.Kvadratura,
                    DatumIzgradnje = n.DatumIzgradnje,
                    Cena = n.Cena,
                    SpratBrSpratova = n.SpratBrSpratova,
                    Opis = n.Opis,
                    IdUgovora = n.IdUgovora,
                    MaxMeseci=n.MaxMeseci,
                    FizickaLicaFirme=n.FizickaLicaFirme
                };

                nd.Vlasnik = s.Load<Klijent>(n.Vlasnik);
                nd.ZaduzenAgent = s.Load<Agent>(n.ZaduzenAgent);

                s.Save(nd);

                s.Flush();
                s.Close();
            }
            catch (Exception exc)
            {

            }
        }

        public static void updateNekretninaDuze(int id, NekrIznDuzeAddUpdate n)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Nekretnina nek = s.Query<Nekretnina>().Where(a => a.Id == id).FirstOrDefault();
                NekretninaIznajmljivanjeDuze nd = (NekretninaIznajmljivanjeDuze)nek;
                nd.GradLokacija = n.GradLokacija;
                nd.Ulica = n.Ulica;
                nd.Broj = n.Broj;
                nd.BrojParcele = n.BrojParcele;
                nd.KatastarskaOpstina = n.KatastarskaOpstina;
                nd.Tip = n.Tip;
                nd.Kvadratura = n.Kvadratura;
                nd.DatumIzgradnje = n.DatumIzgradnje;
                nd.Cena = n.Cena;
                nd.SpratBrSpratova = n.SpratBrSpratova;
                nd.Opis = n.Opis;
                nd.IdUgovora = n.IdUgovora;
                nd.MaxMeseci = n.MaxMeseci;
                nd.FizickaLicaFirme = n.FizickaLicaFirme;
                nd.Vlasnik = s.Load<Klijent>(n.Vlasnik);
                nd.ZaduzenAgent = s.Load<Agent>(n.ZaduzenAgent);

                s.Update(nd);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }

        public static void addNekretninaKrace(NekrIznKraceAddUpdate n)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                NekretninaIznajmljivanjeKrace nk = new NekretninaIznajmljivanjeKrace()
                {
                    GradLokacija = n.GradLokacija,
                    Ulica = n.Ulica,
                    Broj = n.Broj,
                    BrojParcele = n.BrojParcele,
                    KatastarskaOpstina = n.KatastarskaOpstina,
                    Tip = n.Tip,
                    Kvadratura = n.Kvadratura,
                    DatumIzgradnje = n.DatumIzgradnje,
                    Cena = n.Cena,
                    SpratBrSpratova = n.SpratBrSpratova,
                    Opis = n.Opis,
                    IdUgovora = n.IdUgovora,
                    DatumOd = n.DatumOd,
                    DatumDo = n.DatumDo,
                    Godina=n.Godina
                };

                nk.Vlasnik = s.Load<Klijent>(n.Vlasnik);
                nk.ZaduzenAgent = s.Load<Agent>(n.ZaduzenAgent);

                s.Save(nk);

                s.Flush();
                s.Close();
            }
            catch (Exception exc)
            {

            }
        }

        public static void updateNekretninaKrace(int id, NekrIznKraceAddUpdate n)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Nekretnina nek = s.Query<Nekretnina>().Where(a => a.Id == id).FirstOrDefault();
                NekretninaIznajmljivanjeKrace nk = (NekretninaIznajmljivanjeKrace)nek;
                nk.GradLokacija = n.GradLokacija;
                nk.Ulica = n.Ulica;
                nk.Broj = n.Broj;
                nk.BrojParcele = n.BrojParcele;
                nk.KatastarskaOpstina = n.KatastarskaOpstina;
                nk.Tip = n.Tip;
                nk.Kvadratura = n.Kvadratura;
                nk.DatumIzgradnje = n.DatumIzgradnje;
                nk.Cena = n.Cena;
                nk.SpratBrSpratova = n.SpratBrSpratova;
                nk.Opis = n.Opis;
                nk.IdUgovora = n.IdUgovora;
                nk.DatumOd = n.DatumOd;
                nk.DatumDo = n.DatumDo;
                nk.Godina = n.Godina;
                nk.Vlasnik = s.Load<Klijent>(n.Vlasnik);
                nk.ZaduzenAgent = s.Load<Agent>(n.ZaduzenAgent);

                s.Update(nk);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }
        #endregion

        #region Ugovori
        public static void removeUgovor(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Ugovor u = s.Load<Ugovor>(id);

                s.Delete(u);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }

        public static IEnumerable<ProdajniUgovorPregled> getProdajniUgovoriView()
        {
            ISession s = DataLayer.GetSession();
            IList<ProdajniUgovor> ug = s.QueryOver<ProdajniUgovor>().List<ProdajniUgovor>();
            List<ProdajniUgovorPregled> ugovori = new List<ProdajniUgovorPregled>();
            foreach (var u in ug)
                ugovori.Add(new ProdajniUgovorPregled(u));
            return (ugovori.AsEnumerable<ProdajniUgovorPregled>());
        }

        public static IEnumerable<IznajmljivanjeUgovorPregled> getIznajmljivanjeUgovoriView()
        {
            ISession s = DataLayer.GetSession();
            IList<IznajmljivanjeUgovor> ug = s.QueryOver<IznajmljivanjeUgovor>().List<IznajmljivanjeUgovor>();
            List<IznajmljivanjeUgovorPregled> ugovori = new List<IznajmljivanjeUgovorPregled>();
            foreach (var u in ug)
                ugovori.Add(new IznajmljivanjeUgovorPregled(u));
            return (ugovori.AsEnumerable<IznajmljivanjeUgovorPregled>());
        }

        public static ProdajniUgovorPregled GetUgovorProdaja(int id)
        {
            ISession s = DataLayer.GetSession();

            ProdajniUgovor pu =s.Query<ProdajniUgovor>().Where(a => a.Broj == id).Select(a => a).FirstOrDefault();
            return (new ProdajniUgovorPregled(pu));
        }

        public static IznajmljivanjeUgovorPregled GetUgovorIznajmljivanje(int id)
        {
            ISession s = DataLayer.GetSession();

            IznajmljivanjeUgovor iu = s.Query<IznajmljivanjeUgovor>().Where(a => a.Broj == id).Select(a => a).FirstOrDefault();
            return (new IznajmljivanjeUgovorPregled(iu));
        }

        public static void addUgovorProdaja(ProdajniUgovorAddUpdate pu)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ProdajniUgovor ug = new ProdajniUgovor()
                {
                    ImePrezimeNotara = pu.ImePrezimeNotara,
                    AdresaNotara = pu.AdresaNotara,
                    Datum = pu.Datum,
                    NaknadaAgencija = pu.NaknadaAgencija,
                    BonusAgent = pu.BonusAgent,
                    Cena = pu.Cena,
                    NaknadaNotar = pu.NaknadaNotar
                };

                ug.PripadaNekretnini = s.Load<Nekretnina>(pu.PripadaNekretnini);
                ug.Vlasnik = s.Load<Klijent>(pu.Vlasnik);
                ug.KupacIznajmljivac = s.Load<Klijent>(pu.KupacIznajmljivac);

                s.Save(ug);

                s.Flush();
                s.Close();
            }
            catch (Exception exc)
            {

            }
        }

        public static void updateUgovorProdaja(int id, ProdajniUgovorAddUpdate u)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                ProdajniUgovor pu = s.Query<ProdajniUgovor>().Where(a => a.Broj == id).FirstOrDefault();
                pu.ImePrezimeNotara = u.ImePrezimeNotara;
                pu.AdresaNotara = u.AdresaNotara;
                pu.Datum = u.Datum;
                pu.NaknadaAgencija = u.NaknadaAgencija;
                pu.BonusAgent = u.BonusAgent;
                pu.Cena = u.Cena;
                pu.NaknadaNotar = u.NaknadaNotar;
                pu.PripadaNekretnini = s.Load<Nekretnina>(u.PripadaNekretnini);
                pu.Vlasnik = s.Load<Klijent>(u.Vlasnik);
                pu.KupacIznajmljivac = s.Load<Klijent>(u.KupacIznajmljivac);

                s.Update(pu);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }

        public static void addUgovorIznajmljivanje(IznajmljivanjeUgovorAddUpdate iu)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IznajmljivanjeUgovor ug = new IznajmljivanjeUgovor()
                {
                    ImePrezimeNotara = iu.ImePrezimeNotara,
                    AdresaNotara = iu.AdresaNotara,
                    Datum = iu.Datum,
                    NaknadaAgencija = iu.NaknadaAgencija,
                    BonusAgent = iu.BonusAgent,
                    Renta = iu.Renta,
                    PeriodIznajmljivanja = iu.PeriodIznajmljivanja
                };

                ug.PripadaNekretnini = s.Load<Nekretnina>(iu.PripadaNekretnini);
                ug.Vlasnik = s.Load<Klijent>(iu.Vlasnik);
                ug.KupacIznajmljivac = s.Load<Klijent>(iu.KupacIznajmljivac);

                s.Save(ug);

                s.Flush();
                s.Close();
            }
            catch (Exception exc)
            {

            }
        }

        public static void updateUgovorIznajmljivanje(int id, IznajmljivanjeUgovorAddUpdate u)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                IznajmljivanjeUgovor iu = s.Query<IznajmljivanjeUgovor>().Where(a => a.Broj == id).FirstOrDefault();
                iu.ImePrezimeNotara = u.ImePrezimeNotara;
                iu.AdresaNotara = u.AdresaNotara;
                iu.Datum = u.Datum;
                iu.NaknadaAgencija = u.NaknadaAgencija;
                iu.BonusAgent = u.BonusAgent;
                iu.Renta = u.Renta;
                iu.PeriodIznajmljivanja = u.PeriodIznajmljivanja;
                iu.PripadaNekretnini = s.Load<Nekretnina>(u.PripadaNekretnini);
                iu.Vlasnik = s.Load<Klijent>(u.Vlasnik);
                iu.KupacIznajmljivac = s.Load<Klijent>(u.KupacIznajmljivac);

                s.Update(iu);

                s.Flush();
                s.Close();

            }
            catch (Exception exc)
            {
            }
        }
        #endregion
    }
}
