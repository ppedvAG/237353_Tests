using ppedv.CubicleCarnival.Data.EfCore;
using ppedv.CubicleCarnival.Logic;
using ppedv.CubicleCarnival.Model;
using ppedv.CubicleCarnival.Model.Contracts;

Console.WriteLine("Hello CubicleCarnival!");

string conString = "Server=(localdb)\\mssqllocaldb;Database=CubicleCarnival_dev;Trusted_Connection=true;";
IRepository repo = new EfRepository(conString);
var ps = new PersonenService(repo);

var avgAge = ps.CalcAverageAgeOfAllEmployees();
Console.WriteLine($"Average age: {avgAge}");

foreach (var m in repo.GetAll<Mitarbeiter>())
{
    Console.WriteLine($"{m.Name} {m.GebDatum:d} {m.Job}");
    foreach (var k in m.Kunden)
    {
        Console.WriteLine($"\t{k.Name} {k.GebDatum:d} {k.KdNummer}");
    }
}
