namespace AgencijaZaNekretnine.Entiteti
{
    public class ProdajniUgovor:Ugovor
    {
        public virtual int Cena { get; set; }
        public virtual int NaknadaNotar { get; set; }
    }
}
