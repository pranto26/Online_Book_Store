using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookOrderDTO: BookDTO
    {
        public List<OrderDTO> Orders { get; set; }
        public BookOrderDTO() { 
            Orders = new List<OrderDTO>();
        }
    }
}
