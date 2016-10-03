using System.Runtime.Serialization;
using Namu.Entity.ServicePOCOs.Contract;

namespace Namu.Entity.ServicePOCOs
{
    [DataContract]
    public class AuditableEntity : IAuditableEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int[] FKs { get; set; }

        public int GetForeignKeyValueSafely(int index = 0)
        {
            return FKs != null ? FKs[index] : 0;
        }

    }
}
