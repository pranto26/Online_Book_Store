using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CategoryDTO
    {
     
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        [Required]
        [StringLength(25)]
        public string Description { get; set; }

      
    }
}
