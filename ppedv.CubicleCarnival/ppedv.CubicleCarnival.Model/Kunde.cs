namespace ppedv.CubicleCarnival.Model
{
    public class Kunde : Person
    {
        public string KdNummer { get; set; } = string.Empty;
        public virtual Mitarbeiter? Ansprechpartner { get; set; }
    }
}
