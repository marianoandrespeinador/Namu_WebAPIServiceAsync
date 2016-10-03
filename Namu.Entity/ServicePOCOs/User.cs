using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Namu.Entity.ServicePOCOs
{
    [DataContract]
    public class User : AuditableEntity
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public virtual Token CurrentToken { get; set; }
    }
}
