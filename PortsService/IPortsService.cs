using PortsDAL.Models;
using PortsService.Models;
using System.Collections.Generic;

namespace PortsService
{
    public interface IPortsService
    {
        IEnumerable<Port> GetAllPorts(int pageNum, int recordsPerPage);
        IEnumerable<Port> GetPorts(PortQuery portQuery);
        public void AddPort(Port port);
        public bool DeletePort(string portId);
        public int GetPortsCount();
        public string GetPortName(string portCode);
    }
}