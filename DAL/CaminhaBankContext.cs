using Model;
using System.Data.Entity;

namespace DAL
{
    public class CaminhaBankContext : DbContext
    {
        public CaminhaBankContext() { }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Applicant> Applicants { get; set; }

    }
}