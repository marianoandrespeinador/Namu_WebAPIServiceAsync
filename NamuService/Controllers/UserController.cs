using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Namu.BLL;
using Namu.Entity.ServicePOCOs;

namespace NamuService.Controllers
{
    public  class UserController : ApiController
    {
        protected UserBO _accessBO = new UserBO();

        // GET api/User
        public async Task<IEnumerable<User>> Get()
        {
            return await _accessBO.SelectAll();
        }

        // GET api/User/5
        public async Task<User> Get(int id)
        {
            return await _accessBO.Select(id);
        }

        // POST api/User
        public async Task<bool> Post([FromBody]User value)
        {
            return await _accessBO.Insert(value);
        }

        // PUT api/User/5
        public async Task<bool> Put(int id, [FromBody]User value)
        {
            return await _accessBO.Update(id, value);
        }

        // DELETE api/User/5
        public async Task<bool> Delete(int id)
        {
            return await _accessBO.Delete(id);
        }
    }
}