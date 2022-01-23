using PortsDAL.Models;
using System;
using System.Collections.Generic;

namespace PortsDAL
{
    public class PortsRepository : IPortsRepository
    {
        internal IContextHandler _context;

        public PortsRepository(IContextHandler fileHandler)
        {
            _context = fileHandler;
        }

        public List<DbPort> GetAllPorts()
        {
            return _context.Ports;
        }

        public List<DbPort> GetPorts(string searchTerm)
        {
            return _context.Ports.FindAll(
                x => string.Equals(x.ID.ToString(), searchTerm, StringComparison.OrdinalIgnoreCase) ||
                 string.Equals(x.Name, searchTerm, StringComparison.OrdinalIgnoreCase) ||
                 string.Equals(x.PortCode, searchTerm, StringComparison.OrdinalIgnoreCase)
                 );
        }

        public Location GetLocation(int portId)
        {
            var port = _context.Ports.Find(
              x => x.ID == portId
              );
            return new Location()
            {
                Latitude = port.Latitude,
                Longitude = port.Longitude
            };
        }

        public void AddPort(DbPort port)
        {
            _context.Ports.Add(port);
            _context.Save();
        }

        public bool DeletePort(int portId)
        {
            var status = false;
            var port = _context.Ports.Find(x=>x.ID == portId);
            status = _context.Ports.Remove(port);
            _context.Save();
            return status;
        }

    }
}
