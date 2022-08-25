using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        public string? EducationName { get; set; }
        public string? Link { get; set; }
        public int EducationProgramId { get; set; }
        public EducationProgram? EducationProgram { get; set; }
    }
}
