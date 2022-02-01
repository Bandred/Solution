using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Filters
{
    public class PropertyFilter
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public string Year { get; set; }
        public Guid IdOwner { get; set; }
        public OrderFilter Order { get; set; }
    }

    public enum OrderFilter
    {
        AscName,
        AscAddress,
        AscPrice,
        AscCodeInternal,
        AscYear,
        AscIdOwner,
        DesName,
        DesAddress,
        DesPrice,
        DesCodeInternal,
        DesYear,
        DesIdOwner
    }
}
