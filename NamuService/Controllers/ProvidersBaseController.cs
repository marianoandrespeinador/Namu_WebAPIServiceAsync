using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Namu.BLL;
using Namu.Entity.ServicePOCOs;

namespace NamuService.Controllers
{
    public abstract class ProvidersBaseController : ApiController
    {
        protected abstract ProviderBaseBO _accessBO { get; }

        // GET api/values
        public async Task<IEnumerable<Provider>> Get()
        {
            return await _accessBO.SelectAll();
        }

        // GET api/values/5
        public async Task<Provider> Get(int id)
        {
            return await _accessBO.Select(id);
        }

        // POST api/values
        public async Task<bool> Post([FromBody]Provider value)
        {
            return await _accessBO.Insert(value);
        }

        // PUT api/values/5
        public async Task<bool> Put(int id, [FromBody]Provider value)
        {
            return await _accessBO.Update(id, value);
        }

        // DELETE api/values/5
        public async Task<bool> Delete(int id)
        {
            return await _accessBO.Delete(id);
        }
    }
}