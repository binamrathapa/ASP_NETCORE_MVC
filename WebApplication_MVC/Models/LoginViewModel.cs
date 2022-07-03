using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_MVC.Models
{
    public class LoginViewModel
    {
        public string UserName
        {
            get; set;
        }
        [DataType(DataType.Password)]
        public string Password
        {
            get; set;
        }
    }
}
