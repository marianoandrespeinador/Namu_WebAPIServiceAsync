

namespace Namu.DAL.DBCalls
{
    public class ProviderHotelDO : ProviderBaseDO
    {
        private const string ProviderHotelTable = "tprovider_hoteltype";
        private const string ProviderHotelRoomsTable = "tprovider_hoteltype.troomcategories";

        public override string[] IncludeExpression
        {
            get { return new[] { ProviderHotelTable, ProviderHotelRoomsTable }; }
        }
    }
}
