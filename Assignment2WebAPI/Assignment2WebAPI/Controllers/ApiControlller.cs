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
    [Route("[controller]")]
    public class ApiControlller : ControllerBase
    {
        private IAdult adultService;

        public ApiControlller(IAdult adultService)
        {
            this.adultService = adultService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>>
            GetAdult([FromQuery] int? id, [FromQuery] bool? isCompleted)
        {
            try
            {
                IList<Adult> adults = await adultService.getAdults();
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
                await adultService.RemoveAdult(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);

            }
        }

        [HttpPatch]
        [Route("{id:int")]
        public async Task<ActionResult<Adult>> UpdateAdult([FromBody] Adult adult)
        {
            try
            {
                Adult updatedTodo = await adultService.Update(adult);
                return Ok(updatedTodo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }


        }
        [HttpPost]
        [Route("{id:int")]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult)
        {
            try
            {
                Adult added = await adultService.addData(adult);
                return Created($"/{added.Id}", added);

            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}