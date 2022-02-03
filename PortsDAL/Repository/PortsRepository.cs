using PortsDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PortsDAL
{
    public class PortsRepository : IPortsRepository
    {
        internal IContextHandler _context;

        public PortsRepository(IContextHandler fileHandler)
        {
            _context = fileHandler;
        }

        public int GetPortsCount()
        {
            return _context.Ports.Count;
        }

        public IEnumerable<DbPort> GetAllPorts(int pageNum, int recordsPerPage)
        {
            return _context.Ports.Skip(pageNum * recordsPerPage).Take(recordsPerPage);
        }

        public IEnumerable<DbPort> GetPorts(PortQuery query)
        {
            var filteredData = _context.Ports;
            if (query.Id > 0)
            {
                filteredData = filteredData.FindAll(x => x.ID == query.Id);
            }
            if (!string.IsNullOrEmpty(query.Name))
            {
                filteredData = filteredData.FindAll(x => string.Equals(x.Name, query.Name, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(query.Code))
            {
                filteredData = filteredData.FindAll(x => string.Equals(x.PortCode, query.Code, StringComparison.OrdinalIgnoreCase));
            }

            return filteredData.Skip(query.PageNum * query.RecordsPerPage).Take(query.RecordsPerPage);
        }

        public void AddPort(DbPort port)
        {
            if (_context.Ports.Exists(x => x.ID == port.ID))
            {
                throw new ArgumentException("Port with given ID already exists.");
            }
            _context.Ports.Add(port);
            _context.Save();
        }

        public void DeletePort(long portId)
        {
            var status = false;
            var port = _context.Ports.Find(x => x.ID == portId);
            if (port == null) throw new ArgumentException("Port with given ID does not exists.");
            status = _context.Ports.Remove(port);
            _context.Save();

        }

        public string GetPortName(string portCode)
        {
            var port = _context.Ports.FirstOrDefault(x => x.PortCode == portCode);
            if (port != null) return port.Name;
            return string.Empty;
        }

    }
}
