using NSubstitute;
using ppedv.CubicleCarnival.Model;
using ppedv.CubicleCarnival.Model.Contracts;

namespace ppedv.CubicleCarnival.Logic.Tests
{
    public class PersonenServiceTests
    {
        [Theory]
        [InlineData("1955-10-28", "2023-12-05", 68)] // Bill Gates
        [InlineData("1975-10-11", "2023-12-05", 48)] // You
        [InlineData("1960-08-30", "2023-12-05", 63)] // Guy Kawasaki
        [InlineData("2030-12-06", "2023-12-05", -8)] // Futureman
        [InlineData("2023-12-05", "2023-12-05", 0)] // 
        public void CalcAge_ShouldReturnCorrectAge(string birthdateStr, string todayStr, int expectedAge)
        {
            // Arrange
            var ps = new PersonenService(null);
            var birthdate = DateTime.Parse(birthdateStr);
            var today = DateTime.Parse(todayStr);

            // Act
            var age = ps.CalcAge(birthdate, today);

            // Assert
            Assert.Equal(expectedAge, age);
        }

        [Fact]
        public void CalcAverageAgeOfAllEmployees_with_no_Employees()
        {
            var repo = Substitute.For<IRepository>();
            //repo.GetAll<Mitarbeiter>().Returns(new List<Mitarbeiter>());
            var ps = new PersonenService(repo);

            var result = ps.CalcAverageAgeOfAllEmployees();

            Assert.Equal(0, result);
        }

        [Fact]
        public void CalcAverageAgeOfAllEmployees_two_Employees_result_12()
        {
            var ps = new PersonenService(new TestRepo());

            var result = ps.CalcAverageAgeOfAllEmployees();

            Assert.Equal(12, result);
        }

        [Fact]
        public void CalcAverageAgeOfAllEmployees_one_Employees_result_25_NSub()
        {
            var em1 = new Mitarbeiter() { Name = "E1", GebDatum = DateTime.Now.AddYears(-25) };
            var emps = new[] { em1 };

            var repo = Substitute.For<IRepository>();
            repo.GetAll<Mitarbeiter>().Returns(emps);
            var ps = new PersonenService(repo);

            var result = ps.CalcAverageAgeOfAllEmployees();

            Assert.Equal(25, result);
        }

        [Fact]
        public void CalcAverageAgeOfAllEmployees_two_Employees_result_25_NSub()
        {
            var em1 = new Mitarbeiter() { Name = "E1", GebDatum = DateTime.Now.AddYears(-20) };
            var em2 = new Mitarbeiter() { Name = "E2", GebDatum = DateTime.Now.AddYears(-30) };
            var emps = new[] { em1, em2 };

            var repo = Substitute.For<IRepository>();
            repo.GetAll<Mitarbeiter>().Returns(emps);
            var ps = new PersonenService(repo);

            var result = ps.CalcAverageAgeOfAllEmployees();

            Assert.Equal(25, result);
        }
    }

    class TestRepo : IRepository
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