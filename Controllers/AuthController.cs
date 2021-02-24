using authwebapi.Model;
using authwebapi.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace authwebapi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private ICustomJWTService _iJWTService = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public AuthController(ICustomJWTService service)
        {
            _iJWTService = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Route("accredit")]
        [HttpPost]
        public JsonResult Accredit([FromForm] string username, [FromForm] string password)
        {
            //AjaxResult<User> ajaxResult = _HttpHelperService.VerifyUser(username, password);
            AjaxResult<User> ajaxResult = new AjaxResult<User>()
            {
                Success = true,
                TData = new User() { username = username, id = 1 , created=DateTime.Now, phone="13000001111"}
            };
            if (ajaxResult.Success)
            {
                string token = this._iJWTService.GetToken(username, password, ajaxResult.TData);
                ajaxResult.Data = token;
            }
            Console.WriteLine($"Accredit Result : {JsonConvert.SerializeObject(ajaxResult)}");
            return new JsonResult(ajaxResult);
        }
        // GET: api/<AuthController>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
