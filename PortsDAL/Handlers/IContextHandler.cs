using PortsDAL.Models;
using System.Collections.Generic;

namespace PortsDAL
{
    public interface IContextHandler
    {
        public List<DbPort> Ports { get; }
        public void Save();

    }
}