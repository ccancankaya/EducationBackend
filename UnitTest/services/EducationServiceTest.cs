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
    public class EducationServiceTest : IEducationService
    {
        private readonly List<Education> _educations;

        public EducationServiceTest()
        {
            _educations = new List<Education>()
            {
                new Education() { Id = 1, EducationName ="Test Eğitim 1",Link="www.youtube.com",EducationProgramId=1 },
                new Education() { Id = 2, EducationName ="Test Eğitim 2",Link="www.youtube.com",EducationProgramId=1 },
                new Education() { Id = 3, EducationName ="Test Eğitim 3",Link="www.youtube.com",EducationProgramId=2 },
            };
        }
        public void Create(Education entity)
        {
            _educations.Add(entity);
        }

        public void Delete(Education entity)
        {
            _educations.Remove(entity);
        }

        public IList<Education> FindByCondition(Expression<Func<Education, bool>> expression)
        {
            return _educations;

        }

        public IList<Education> GetAll()
        {
            return _educations;
        }

        public Education GetById(int id)
        {
            return _educations.Where(e => e.Id == id).FirstOrDefault();
        }

        public void Update(Education entity)
        {
            var obj = _educations.FirstOrDefault(e => e.Id == entity.Id);
            if (obj != null)
            {
                obj.EducationName = entity.EducationName;
                obj.Link = entity.Link;
                obj.EducationProgramId = entity.EducationProgramId;
            }
        }
    }
}
