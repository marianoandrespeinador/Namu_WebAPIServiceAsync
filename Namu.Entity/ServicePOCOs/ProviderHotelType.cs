using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Namu.Entity.ServicePOCOs
{
    [DataContract]
    public class ProviderHotelType : AuditableEntity
    {
        public ProviderHotelType()
        {
            lstRoomCategories = new List<RoomCategory>();
        }
        
        [DataMember]
        public int CheckIn_Hour { get; set; }
        [DataMember]
        public int CheckIn_Minute { get; set; }
        [DataMember]
        public int Checkout_Hour { get; set; }
        [DataMember]
        public int Checkout_Minute { get; set; }
        [DataMember]
        public int Minimum_Age { get; set; }
    
        [DataMember]
        public virtual Provider ProviderInfo { get; set; }
        [DataMember]
        public virtual List<RoomCategory> lstRoomCategories { get; set; }

        public string CheckInTime
        {
            get { return string.Format("{0}:{1}", CheckIn_Hour, CheckIn_Minute); }
        }

        public string CheckOutTime
        {
            get { return string.Format("{0}:{1}", Checkout_Hour, Checkout_Minute); }
        }
    }
}
