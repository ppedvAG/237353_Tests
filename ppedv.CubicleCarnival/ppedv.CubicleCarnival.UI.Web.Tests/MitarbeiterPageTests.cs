using Bunit;
using Microsoft.Extensions.DependencyInjection;
using ppedv.CubicleCarnival.Logic;
using ppedv.CubicleCarnival.Model;
using ppedv.CubicleCarnival.Model.Contracts;

namespace ppedv.CubicleCarnival.UI.Web.Tests
{
    public class MitarbeiterPageTests : TestContext
    {
        [Fact]
        public void Can_show_Mitarbeiter_from_db_as_Table()
        {
            Services.AddSingleton<IRepository, TestRepo>();
            Services.AddSingleton<PersonenService>();

            var page = RenderComponent<Pages.MitarbeiterPage>();

            var rows = page.FindAll("tr");

            Assert.Equal(3, rows.Count);
        }
    }

    public class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            if (typeof(T).IsAssignableFrom(typeof(Mitarbeiter)))
            {
                var em1 = new Mitarbeiter() { Name = "E1", GebDatum = DateTime.Now.AddYears(-10) };
                var em2 = new Mitarbeiter() { Name = "E2", GebDatum = DateTime.Now.AddYears(-14) };

                return new[] { em1, em2 }.Cast<T>();
            }

            throw new NotImplementedException();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public int SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}