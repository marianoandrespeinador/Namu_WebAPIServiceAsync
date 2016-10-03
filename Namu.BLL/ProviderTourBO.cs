using Namu.DAL.DBCalls;

namespace Namu.BLL
{
    public class ProviderTourBO : ProviderBaseBO
    {
        private readonly ProviderHotelDO _accessDOHotel = new ProviderHotelDO();

        protected override ProviderBaseDO _accessDO
        {
            get { return _accessDOHotel; }
        }

    }
}
