using DataAccess.Abstract;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EducationProgramService : Repository<EducationProgram>, IEducationProgramService
    {
        public EducationProgramService(EduDbContext context) : base(context)
        {
        }

        public IList<EducationProgram> GetWithEducations()
        {
            return _context.Set<EducationProgram>().Include("Educations").ToList();
        }
    }
}
