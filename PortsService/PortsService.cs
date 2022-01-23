using PortsDAL;
using PortsDAL.Models;
using PortsService.Models;
using System;
using System.Collections.Generic;

namespace PortsService
{
    public class PortsService
    {
        IPortsRepository _portsRepository;
        public PortsService(IPortsRepository portsRepository)
        {
            _portsRepository = portsRepository;
        }

        //public List<Port> GetPorts(string searchTerm)
        //{
        //    var ports = 
        //        _portsRepository.GetPorts(searchTerm);
        //}

        //public Location GetLocation(int portId)
        //{
           
        //}

        //public void AddPort(DbPort port)
        //{
           
        //}

        //public bool DeletePort(int portId)
        //{
           
        //}
    }
}
