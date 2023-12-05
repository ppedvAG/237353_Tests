namespace ppedv.CubicleCarnival.Model
{
    public class Mitarbeiter : Entity
    {
        public string Job { get; set; } = string.Empty;
        public virtual HashSet<Kunde> Kunden { get; set; } = new HashSet<Kunde>();
    }
}
