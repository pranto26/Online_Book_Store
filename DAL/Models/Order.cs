using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        [ForeignKey("User")]
        public string SoldBy { get; set; }
        [ForeignKey("Book")]
        public int? Book_Id { get; set; }
        public virtual Book Book { get; set; }

        public virtual User User { get; set; }
        
    }
}
