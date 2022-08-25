using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class EducationProgram
    {
        [Key]
        public int Id { get; set; }
        public string? ProgramName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string? Status { get; set; }
        public ICollection<Education>? Educations { get; set; }
    }
}
