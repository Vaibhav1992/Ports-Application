using PortsDAL.Models;
using System.Collections.Generic;

namespace PortsDAL
{
    public interface IPortsRepository
    {

        public IEnumerable<DbPort> GetAllPorts(int pageNum, int recordsPerPage);

        public IEnumerable<DbPort> GetPorts(PortQuery searchTerm);

        public void AddPort(DbPort port);

        public void DeletePort(long portId);
        public int GetPortsCount();
        public string GetPortName(string portCode);
    }
}