namespace AgencijaZaNekretnine.Entiteti
{
    public class IznajmljivanjeUgovor:Ugovor
    {
        public virtual int Renta { get; set; }
        public virtual int PeriodIznajmljivanja { get; set; }
    }
}
