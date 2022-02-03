using PortsDAL.Models;
using PortsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortsAPI.Controllers.Models
{
    public class GetPortResponse
    {
        public int NextPage { get; set; }

        public IEnumerable<Port> Ports { get; set; }

        public int Count { get; set; }
    }
}
