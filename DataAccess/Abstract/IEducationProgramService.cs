using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEducationProgramService : IRepository<EducationProgram>
    {
        public IList<EducationProgram> GetWithEducations();
    }
}
