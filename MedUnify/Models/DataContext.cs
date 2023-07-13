using Microsoft.EntityFrameworkCore;


namespace MedUnify.Models
{
    public class DataContext : System.Data.Entity.DbContext
    {
        //public DataContext(DbContextOptions<DataContext> options) : base(options)
        //{
        //}

        public System.Data.Entity.DbSet<Patient> Patients { get; set; }
        public System.Data.Entity.DbSet<Visit> Visits { get; set; }
        public System.Data.Entity.DbSet<ProgressNote> ProgressNotes { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configure any additional model mappings or relationships here
        //}
    }
}
