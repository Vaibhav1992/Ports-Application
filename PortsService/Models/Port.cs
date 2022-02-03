using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PortsService.Models
{
    public class Port
    {
        [Required]
        public long ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "PortCode must be 5 characters")]
        public string PortCode { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "UnctadPortCode must be 3 characters")]
        public string UnctadPortCode { get; set; }

        [Required]
        public string Country { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public Uri Url { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "MainPortCode must be 5 characters")]
        public string MainPortCode { get; set; }

        public string MainPortName { get; set; }
    }
}
