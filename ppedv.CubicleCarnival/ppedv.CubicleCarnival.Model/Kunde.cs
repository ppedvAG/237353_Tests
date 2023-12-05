namespace ppedv.CubicleCarnival.Model
{
    public class Kunde : Entity
    {
        public string KdNummer { get; set; } = string.Empty;
        public virtual Mitarbeiter? Ansprechpartner { get; set; }
    }
}
