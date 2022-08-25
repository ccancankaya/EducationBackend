using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EduDbContext : DbContext
    {
        public EduDbContext(DbContextOptions<EduDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); //PostgreSQL .net date time formatini kabul etmesi icin
        }
        public DbSet<EducationProgram> EducationPrograms { get; set; }
        public DbSet<Education> Educations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Education>()
                .HasOne<EducationProgram>(s => s.EducationProgram)
                .WithMany(g => g.Educations)
                .HasForeignKey(s => s.EducationProgramId);
        }



    }
}
