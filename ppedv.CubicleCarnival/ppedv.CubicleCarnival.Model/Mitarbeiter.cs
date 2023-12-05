namespace ppedv.CubicleCarnival.Model
{
    public class Mitarbeiter : Person
    {
        public string Job { get; set; } = string.Empty;
        public virtual HashSet<Kunde> Kunden { get; set; } = new HashSet<Kunde>();
    }
}
