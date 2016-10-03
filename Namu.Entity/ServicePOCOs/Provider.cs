using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Namu.Entity.ServicePOCOs
{
    [DataContract]
    public class Provider : AuditableEntity
    {
        public Provider()
        {
            lstAddresses = new List<Address>();
        }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int ProviderTypeCode { get; set; }
        [DataMember]
        public int NumCode { get; set; }
        [DataMember]
        public int PhoneCode { get; set; }

        [DataMember]
        public virtual ProviderHotelType HotelInfo { get; set; }
        [DataMember]
        public virtual ProviderTourType TourInfo { get; set; }
        [DataMember]
        public virtual List<Address> lstAddresses { get; set; }
    }
}
