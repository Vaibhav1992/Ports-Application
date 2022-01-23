using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortsDAL;
using PortsDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortsController : ControllerBase
    {
        private readonly IPortsRepository _portRepository;
        public PortsController(IPortsRepository portRepository)
        {
            _portRepository = portRepository;
        }

        // GET: PortsController
        [HttpGet]
        public IEnumerable<DbPort> Get()
        {
            return _portRepository.GetAllPorts();
        }
    }
}
