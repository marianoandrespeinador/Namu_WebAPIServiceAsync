
using System;
using System.Runtime.Serialization;

namespace Namu.Entity.ServicePOCOs
{
    [DataContract]
    public  class Token : AuditableEntity
    {
        [DataMember]
        public string AuthToken { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public virtual User UserInfo { get; set; }
    }
}
