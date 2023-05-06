using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public int Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public int Quantity { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Order> Orders { get; set;}
        public Book()
        {
            Orders = new List<Order>();
        }

    }
}
