using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Namu.Entity.ServicePOCOs
{
    [DataContract]
    public class Address : AuditableEntity
    {
        public Address()
        {
            lstProviders = new List<Provider>();
        }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string ExactAddress { get; set; }

        [DataMember]
        public virtual List<Provider> lstProviders { get; set; }
    }
}
