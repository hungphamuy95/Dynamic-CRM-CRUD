using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sample.Dao;
using Sample.Models;

namespace Sample.Controllers
{
    public class AccoutController : ApiController
    {
        [Route("api/GetAll")]
        [HttpGet]
        public List<Dictionary<string, object>> GetAll()
        {
            return new AccountDao().GetAll();
        }
        [HttpPost]
        public Dictionary<string, object> GetEntity(string id)
        {
            var fuck = new AccountDao().GetByGuid(id);
            return fuck;
        }
        [HttpPut]
        [Route("api/CreateAccount")]
        public void CreateAccout([FromBody] AccountModel model)
        {
            new AccountDao().Create(model);
        }
        [HttpGet]
        [Route("api/SearchByDetail")]
        public List<Dictionary<string,object>> SearchByDetail(string cate, string attr, string value)
        {
            return new AccountDao().SearchByCategory(cate, attr, value);
        }
        [HttpPut]
        [Route("api/UpdateAccount/{guid}")]
        public void UpdateAccount(string guid, [FromBody] AccountModel m)
        {
            new AccountDao().Update(guid, m);
        }
    }
}
