using ppedv.CubicleCarnival.Data.EfCore;
using ppedv.CubicleCarnival.Logic;
using ppedv.CubicleCarnival.Model;
using ppedv.CubicleCarnival.Model.Contracts;

namespace ppedv.CubicleCarnival.UI.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string conString = "Server=(localdb)\\mssqllocaldb;Database=CubicleCarnival_dev;Trusted_Connection=true;";
            repo = new EfRepository(conString);
            ps = new PersonenService(repo);
        }

        IRepository repo;
        PersonenService ps;

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repo.GetAll<Mitarbeiter>().ToList();
        }
    }
}
