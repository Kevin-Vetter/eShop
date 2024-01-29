using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Cart
    {
        public List<int> ProductsIds { get; set; }
        public List<int> Amounts { get; set; }
    }
}
