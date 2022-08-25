using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EduDbContext>
    {
        public EduDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EduDbContext>();

            builder.UseNpgsql("User ID=postgres;Password=1;Server=localhost;Port=5432;Database=TurkcellEdu;Integrated Security=true;Pooling=true", x => x.MigrationsAssembly("DataAccess"));

            return new EduDbContext(builder.Options);
        }
    }
}
