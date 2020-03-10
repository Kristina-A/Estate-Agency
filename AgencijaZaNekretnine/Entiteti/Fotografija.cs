namespace AgencijaZaNekretnine.Entiteti
{
    public class Fotografija
    {
        public virtual int Id { get; protected set; }
        public virtual byte[] Sadrzaj { get; set; }
        public virtual Nekretnina PripadaNekretnini { get; set; }
    }
}
