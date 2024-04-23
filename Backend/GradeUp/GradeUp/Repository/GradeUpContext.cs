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
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-JFD73P0;Initial Catalog=gradeup_db;Integrated Security=True;Trust Server Certificate=True");
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
