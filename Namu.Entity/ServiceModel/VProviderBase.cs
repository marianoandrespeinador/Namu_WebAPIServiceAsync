using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namu.Entity.ServiceModel
{
    public abstract class VProviderBase : ModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProviderTypeCode { get; set; }
        public int PhoneCode { get; set; }
    }
}
