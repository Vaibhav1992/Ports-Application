using System;
using System.Collections.Generic;
using System.Text;

namespace PortsDAL.Models
{
    public class DbPort
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PortCode { get; set; }
        public string UnctadPortCode { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Uri Url { get; set; }
        public string MainPortCode { get; set; }
    }
}
