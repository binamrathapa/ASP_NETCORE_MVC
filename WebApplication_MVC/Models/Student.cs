using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication_MVC.Models
{
    public class Student
    {
        public int Id
        {
            get;set;
        }
        [Required(ErrorMessage ="Name is required")]
        [StringLength(50,ErrorMessage ="Max length should not be greater than 50")]
        public string Name
        {
            get;set;
        }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email
        {
            get;set;
        }
        public string Address
        {
            get;set;
        }
        public int DepartmentId
        {
            get;set;
        }
        
        public virtual Department Department
        {
            get;set;
        }
     
    }
}
