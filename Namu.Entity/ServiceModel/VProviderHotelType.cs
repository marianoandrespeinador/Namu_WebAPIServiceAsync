
using System.Collections.Generic;


namespace Namu.Entity.ServiceModel
{
    public class VProviderHotelType : VProviderBase
    {
        public int CheckIn_Hour { get; set; }
        public int CheckIn_Minute { get; set; }
        public int Checkout_Hour { get; set; }
        public int Checkout_Minute { get; set; }
        public int Minimum_Age { get; set; }

        public List<VRoomCategory> LstRooms { get; set; }
    }
}
