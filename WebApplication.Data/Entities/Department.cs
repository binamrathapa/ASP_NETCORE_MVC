using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data.Entities
{
    public class Department
    {
        public int Id
        {
            get;set;
        }
        [Display(Name="Department Name")]
        public string Name
        {
            get;set;
        }

        public virtual ICollection<Student> Students
        {
            get;set;
        }
        public Department()
        {
            Students = new List<Student>();
        }
    }
}
