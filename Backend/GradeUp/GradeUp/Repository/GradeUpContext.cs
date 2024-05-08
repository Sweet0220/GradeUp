using GradeUp.Entities;
using Microsoft.EntityFrameworkCore;

namespace GradeUp.Repository
{
    public class GradeUpContext : DbContext
    {
        public GradeUpContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Connection String Denisa
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-JFD73P0;Initial Catalog=gradeup_db;Integrated Security=True;Trust Server Certificate=True");
                //Connection String Riana
                //optionsBuilder.UseSqlServer("Data Source=IDEAPAD5-RI\\MSSQLSERVER_RIA;Initial Catalog=gradeup_db;Integrated Security=True;Trust Server Certificate=True");
                //Connection String Mrc
                //optionsBuilder.UseSqlServer("");
                //Connection String Octa
                //optionsBuilder.UseSqlServer("");
            }
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teaching> Teaching { get; set; }

    }
}
