using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namu.Entity.ServiceModel
{
    public class VProviderHotelType : VProviderBase
    {
        public int CheckIn_Hour { get; set; }
        public int CheckIn_Minute { get; set; }
        public int Checkout_Hour { get; set; }
        public int Checkout_Minute { get; set; }
        public int Minimum_Age { get; set; }        
    }
}
