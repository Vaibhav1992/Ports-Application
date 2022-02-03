using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortsAPI.Controllers.Models;
using PortsDAL;
using PortsDAL.Models;
using PortsService;
using PortsService.Models;
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
        private readonly IPortsService _portService;
        public PortsController(IPortsRepository portRepository, IPortsService portsService)
        {
            _portService = portsService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] PortQuery portQuery)
        {
            var res = new GetPortResponse();
            if (string.IsNullOrEmpty(portQuery.Name) && portQuery.Id <= 0 && string.IsNullOrEmpty(portQuery.Code))
            {
                res.Ports = _portService.GetAllPorts(portQuery.PageNum, portQuery.RecordsPerPage);
                res.Count = _portService.GetPortsCount();
                res.NextPage = res.Ports.Count() == portQuery.RecordsPerPage ? portQuery.PageNum + 1 : -1;
            }
            else
            {
                res.Ports = _portService.GetPorts(portQuery);
                res.Count = res.Ports.Count();
                res.NextPage = res.Ports.Count() == portQuery.RecordsPerPage ? portQuery.PageNum + 1 : -1;
            }
            return Ok(res);
        }   


        [HttpDelete]
        public IActionResult Delete(long portId)
        {
            try
            {
                _portService.DeletePort(portId);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Add(Port port)
        {
            try
            {
                _portService.AddPort(port);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
