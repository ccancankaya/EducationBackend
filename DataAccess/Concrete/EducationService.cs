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
    public class EducationService : Repository<Education>, IEducationService
    {
        public EducationService(EduDbContext context) : base(context)
        {
        }
    }
}
