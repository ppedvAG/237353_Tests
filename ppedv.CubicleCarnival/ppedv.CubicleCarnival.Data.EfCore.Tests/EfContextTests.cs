using ppedv.CubicleCarnival.Model;

namespace ppedv.CubicleCarnival.Data.EfCore.Tests
{
    public class EfContextTests
    {
        string conString = "Server=(localdb)\\mssqllocaldb;Database=CubicleCarnival_dev;Trusted_Connection=true;";

        [Fact]
        public void Can_create_db()
        {
            var con = new EfContext(conString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        public void Can_create_Mitarbeiter()
        {
            var m = new Mitarbeiter() { Name = "Fred", Job = "Macht dinge", GebDatum = DateTime.Now.AddYears(-50) };
            var con = new EfContext(conString);

            con.Mitarbeiter.Add(m);
            var rows = con.SaveChanges();

            Assert.Equal(2, rows);
        }

        [Fact]
        public void Can_read_Mitarbeiter()
        {
            var m = new Mitarbeiter() { Name = $"Wilma_{Guid.NewGuid()}", Job = "Macht dinge", GebDatum = DateTime.Now.AddYears(-50) };
            using (var con = new EfContext(conString))
            {
                con.Mitarbeiter.Add(m);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Mitarbeiter.Find(m.Id);
                Assert.Equal(m.Name, loaded.Name);
            }
        }

        [Fact]
        public void Can_update_Mitarbeiter()
        {
            var m = new Mitarbeiter() { Name = $"Barney_{Guid.NewGuid()}", Job = "Macht dinge", GebDatum = DateTime.Now.AddYears(-50) };
            var newName = $"Betty_{Guid.NewGuid()}";
            using (var con = new EfContext(conString))
            {
                con.Mitarbeiter.Add(m);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Mitarbeiter.Find(m.Id);
                loaded.Name = newName;
                var rows = con.SaveChanges();
                Assert.Equal(1, rows);
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Mitarbeiter.Find(m.Id);
                Assert.Equal(newName, loaded.Name);
            }
        }

        [Fact]
        public void Can_delete_Mitarbeiter()
        {
            var m = new Mitarbeiter() { Name = $"Barney_{Guid.NewGuid()}", Job = "Macht dinge", GebDatum = DateTime.Now.AddYears(-50) };
            using (var con = new EfContext(conString))
            {
                con.Mitarbeiter.Add(m);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Mitarbeiter.Find(m.Id);
                con.Mitarbeiter.Remove(loaded);
                var rows = con.SaveChanges();
                Assert.Equal(2, rows);
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Mitarbeiter.Find(m.Id);
                Assert.Null(loaded);
            }
        }
    }
}