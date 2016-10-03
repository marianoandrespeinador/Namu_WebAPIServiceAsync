using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Namu.Entity.ServicePOCOs
{
    [DataContract]
    public class ProviderTourType : AuditableEntity
    {
        public ProviderTourType()
        {
            lstTours = new List<Tour>();
        }

        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public virtual Provider ProviderInfo { get; set; }
        [DataMember]
        public virtual List<Tour> lstTours { get; set; }
    }
}
