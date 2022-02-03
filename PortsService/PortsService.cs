using PortsDAL;
using PortsDAL.Models;
using PortsService.Models;
using System;
using System.Collections.Generic;

namespace PortsService
{
    public class PortsService : IPortsService
    {
        IPortsRepository _portsRepository;
        public PortsService(IPortsRepository portsRepository)
        {
            _portsRepository = portsRepository;
        }

        public IEnumerable<Port> GetAllPorts(int pageNum, int recordsPerPage)
        {
            var ports = new List<Port>();
            var dbPorts = _portsRepository.GetAllPorts(pageNum, recordsPerPage);
            foreach (var dbPort in dbPorts)
            {
                var port = portMapper(dbPort);
                port.MainPortName = port.MainPortCode == port.PortCode ? port.Name : GetPortName(port.MainPortCode);
                ports.Add(port);
            }
            return ports;
        }

        public IEnumerable<Port> GetPorts(PortQuery portQuery)
        {
            var ports = new List<Port>();
            var dbPorts = _portsRepository.GetPorts(portQuery);
            foreach (var dbPort in dbPorts)
            {
                var port = portMapper(dbPort);
                port.MainPortName = port.MainPortCode == port.PortCode ? port.Name : GetPortName(port.MainPortCode);
                ports.Add(port);
            }
            return ports;
        }

        public void AddPort(Port port)
        {
            _portsRepository.AddPort(portMapper(port));
        }

        public bool DeletePort(string portId)
        {
            return _portsRepository.DeletePort(portId);
        }
        public int GetPortsCount()
        {
            return _portsRepository.GetPortsCount();
        }
        public string GetPortName(string portCode)
        {
            return _portsRepository.GetPortName(portCode);
        }

        private Port portMapper(DbPort dbPort)
        {
            return new Port()
            {
                ID = dbPort.ID,
                Country = dbPort.Country,
                Latitude = dbPort.Latitude,
                Longitude = dbPort.Longitude,
                MainPortCode = dbPort.MainPortCode,
                Name = dbPort.Name,
                PortCode = dbPort.PortCode,
                UnctadPortCode = dbPort.UnctadPortCode,
                Url = dbPort.Url
            };
        }

        private DbPort portMapper(Port port)
        {
            return new DbPort()
            {
                ID = port.ID,
                Country = port.Country,
                Latitude = port.Latitude,
                Longitude = port.Longitude,
                MainPortCode = port.MainPortCode,
                Name = port.Name,
                PortCode = port.PortCode,
                UnctadPortCode = port.UnctadPortCode,
                Url = port.Url
            };
        }
    }
}
