using Namu.BLL;

namespace NamuService.Controllers
{
    public class ProvidersHotelController : ProvidersBaseController
    {
        private readonly ProviderHotelBO _accesHotelBO = new ProviderHotelBO();

        protected override ProviderBaseBO _accessBO
        {
            get { return _accesHotelBO; }
        }
    }
}