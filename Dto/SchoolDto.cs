using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity2.Dto
{
    public class SchoolDto
    {

        public Guid id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Address { get; set; }

        //public List<Class> Classes { get; set; } = new List<Class>();
        public string City { get; set; }


    }
}
