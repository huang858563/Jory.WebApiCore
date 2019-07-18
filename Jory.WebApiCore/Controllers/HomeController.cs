using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jory.Model;

namespace Jory.WebApiCore.Controllers
{
    /// <summary>
    /// Home控制器
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(UserInfo), 200)]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserInfo>> Get()
        {
            return new List<UserInfo>(){
                new UserInfo{ UserCode="UC0001",UserName="张三"},
                 new UserInfo{ UserCode="UC0002",UserName="李四"}
            };
        }
    }
}
