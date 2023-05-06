using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string SoldBy { get; set; }
        public int? Book_Id { get; set; }


        //public virtual User User { get; set; }
    }
}
