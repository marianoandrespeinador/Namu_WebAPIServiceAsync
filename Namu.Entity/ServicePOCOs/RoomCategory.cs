using System.Runtime.Serialization;

namespace Namu.Entity.ServicePOCOs
{
    [DataContract]
    public class RoomCategory : AuditableEntity
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int MaxCapacity { get; set; }

        [DataMember]
        public virtual ProviderHotelType ProviderHotel { get; set; }
    }
}
