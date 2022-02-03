using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortsDAL.Models
{
    public class PortQuery
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int PageNum { get; set; }

        public int RecordsPerPage { get; set; }
    }
}
