using PortsDAL.Models;
using System.Collections.Generic;

namespace PortsDAL
{
    public interface IPortsRepository
    {

        public List<DbPort> GetAllPorts();

        public List<DbPort> GetPorts(string searchTerm);

        public Location GetLocation(int portId);

        public void AddPort(DbPort port);

        public bool DeletePort(int portId);
      
    }
}