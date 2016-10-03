using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Namu.BLL;
using Namu.Entity.ServicePOCOs;

namespace NamuService.Controllers
{
    public class AuthenticateController : ApiController
    {
        protected UserBO _accessBO = new UserBO();

        // api/authenticate/ValidateToken?tokenId=7323494b-4699-431d-a4b9-34a2d9c99359
        [HttpGet]
        public async Task<bool> ValidateToken(string id)
        {
            return await _accessBO.ValidateToken(id);
        }

        // api/authenticate/Authenticate?name=admin&passwordCypher=Hpl2oQeO4go=
        [HttpGet]
        public async Task<User> Authenticate(string name, string passwordCypher)
        {
            return await _accessBO.Login(name, passwordCypher);
        }
    }
}
