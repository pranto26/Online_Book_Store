using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {
        public string TKey { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime? Expired_At { get; set; }
        public string UserId { get; set; }
    }
}
