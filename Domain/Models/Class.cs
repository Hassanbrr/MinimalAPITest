using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Class
    {
        [Key]

        public int Id { get; set; }

        public string? ClassName { get; set; }
        public virtual ICollection<Student> Students { get; set; }


    }
}
