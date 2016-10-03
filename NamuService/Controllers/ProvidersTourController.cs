using Namu.BLL;

namespace NamuService.Controllers
{
    public class ProvidersTourController : ProvidersBaseController
    {
        private readonly ProviderTourBO _accesTourBO = new ProviderTourBO();

        protected override ProviderBaseBO _accessBO
        {
            get { return _accesTourBO; }
        }
    }
}