using ApiSpeedUp.Data;
using ApiSpeedUp.Models;
using ApiSpeedUp.SqlDataFetch;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiSpeedUp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiSpeedController : ControllerBase
    {
        public readonly travelDbContext dbcontext;
        public IApiRep apiRep { get; set; }
        public ApiSpeedController(travelDbContext dbcontext, IApiRep apiRep)
        {
            this.dbcontext = dbcontext;
            this.apiRep = apiRep;

                
        }
        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var apilist = await apiRep.GetAllList();
                return Ok(apilist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpGet]
        [Route("GetCount/{org}")]
        public async Task<IActionResult> getcount(string org)
        {
            try
            {
                var count = await apiRep.getcount(org);
                if(count == 0)
                {
                    return NotFound();  
                }
                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllOrg")]
        public async Task<IActionResult> AllOrg()
        {
            try
            {
                var listOrg = await apiRep.GetAllorg();
                if (listOrg == null)
                {
                    return NotFound();
                }
                return Ok(listOrg);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
