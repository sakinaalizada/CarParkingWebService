using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpacesController : ControllerBase
    {
        private IParkingSpaceService _parkingSpaceService;
        public ParkingSpacesController(IParkingSpaceService parkingSpaceService)
        {
            _parkingSpaceService = parkingSpaceService;
        }
        [HttpPost("add")]
        public IActionResult Add(ParkingSpace parkingSpace)
        {
            var result = this._parkingSpaceService.Add(parkingSpace);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
        [HttpPost("update")]
        public IActionResult Update(ParkingSpace parkingSpace)
        {
            var result = this._parkingSpaceService.Update(parkingSpace);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
        [HttpPost("delete")]
        public IActionResult Delete(ParkingSpace parkingSpace)
        {
            var result = this._parkingSpaceService.Delete(parkingSpace);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = this._parkingSpaceService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getchargeforhourbyid")]
        public IActionResult GetChargeForHourById(int id)
        {
            var result = this._parkingSpaceService.GetChargeForHourById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = this._parkingSpaceService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);

        }
    }
}
