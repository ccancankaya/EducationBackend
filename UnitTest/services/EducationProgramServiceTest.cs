using DataAccess.Abstract;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.services
{
    internal class EducationProgramServiceTest : IEducationProgramService
    {
        private readonly List<EducationProgram> _programs;

        public EducationProgramServiceTest()
        {
            _programs = new List<EducationProgram>()
            {
                new EducationProgram() { Id = 1, ProgramName ="Test Program 1",StartDateTime=new DateTime(),EndDateTime=new DateTime().AddDays(1),Status="Yayınlandı" },
                new EducationProgram() { Id =2, ProgramName ="Test Program 2",StartDateTime=new DateTime().AddHours(3),EndDateTime=new DateTime().AddHours(4),Status="Yayınlandı" },
                new EducationProgram() { Id = 3, ProgramName ="Test Program 3",StartDateTime=new DateTime().AddMonths(1).AddHours(3),EndDateTime=new DateTime().AddMonths(2).AddHours(3),Status="Yayınlanmadı" },
            };
        }
        public void Create(EducationProgram entity)
        {
            _programs.Add(entity);
        }

        public void Delete(EducationProgram entity)
        {
            _programs.Remove(entity);
        }

        public IList<EducationProgram> FindByCondition(Expression<Func<EducationProgram, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IList<EducationProgram> GetAll()
        {
            return _programs;
        }

        public EducationProgram GetById(int id)
        {
            return _programs.FirstOrDefault(p => p.Id == id);
        }

        public IList<EducationProgram> GetWithEducations()
        {
            return _programs;
        }

        public void Update(EducationProgram entity)
        {
            var obj = _programs.FirstOrDefault(p => p.Id == entity.Id);
            if (obj != null)
            {
                obj.ProgramName = entity.ProgramName;
                obj.StartDateTime = entity.StartDateTime;
                obj.EndDateTime = entity.EndDateTime;
                obj.Status = entity.Status;
            }
        }
    }
}
