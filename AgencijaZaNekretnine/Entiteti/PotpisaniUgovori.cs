namespace AgencijaZaNekretnine.Entiteti
{
    public class PotpisaniUgovori
    {
        public virtual int Kod { get; set; }
        public virtual Agent Agent { get; set; }
        public virtual string PotpUgovori { get; set; }
    }
}
