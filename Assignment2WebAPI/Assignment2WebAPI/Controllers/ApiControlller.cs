using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Assignment2WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Models;
using Assignment2WebAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing.Template;

namespace Assignment2WebAPI.Controllers
{       
    [ApiController]
    //controller
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private IAdult adultService;

        public ApiController(IAdult AdultService)
        {
            this.adultService = AdultService;
        }

        [HttpGet]
        [Route("/Adults")]
        public async Task<ActionResult<IList<Adult>>>
            GetAdult([FromQuery] int? id, [FromQuery] bool? isCompleted)
        {
            try
            {
                IList<Adult> adults = adultService.getAdults();
                var testiboi = adults;
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id)
        {

            try
            {
                adultService.RemoveAdult(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);

            }
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> UpdateAdult([FromBody] Adult adult)
        {
            try
            {
                 adultService.Update(adult);
                return Ok(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }


        }
        [HttpPost]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            try
            {
                adultService.addData(adult);
                return Created($"/{adult.Id}", adult);

            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}