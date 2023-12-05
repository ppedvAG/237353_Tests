using ppedv.CubicleCarnival.Model;
using ppedv.CubicleCarnival.Model.Contracts;

namespace ppedv.CubicleCarnival.Logic
{
    public class PersonenService
    {
        private IRepository repo;

        public PersonenService(IRepository repo)
        {
            this.repo = repo;

        }

        public double CalcAverageAgeOfAllEmployees()
        {
            if (repo.GetAll<Mitarbeiter>().Count() == 0)
                return 0;

            return repo.GetAll<Mitarbeiter>().Average(x => CalcAge(x.GebDatum, DateTime.Now));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="birthdate"></param>
        /// <param name="today"></param>
        /// <returns></returns>
        /// <remarks>https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-based-on-a-datetime-type-birthday</remarks>
        public double CalcAge(DateTime birthdate, DateTime today)
        {
            // Calculate the age.
            var age = today.Year - birthdate.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (birthdate.Date > today.AddYears(-age)) age--;

            return age;
        }

    }
}
