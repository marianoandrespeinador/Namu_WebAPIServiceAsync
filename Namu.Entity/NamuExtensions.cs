using System;
using System.Collections.Generic;
using Namu.Entity.ServiceModel;
using Namu.Entity.ServicePOCOs;

namespace Namu.Entity
{
    public static class NamuExtensions
    {
        /// <summary>
        /// Reemplaza la sintaxis del foreach para hacerlo con lambda
        /// </summary>
        public static void Each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

        public static VProviderHotelType ToModel(this Provider thisProvider)
        {
            return new VProviderHotelType
            {
                Id = thisProvider.Id,
                Name = thisProvider.Name,
                PhoneCode = thisProvider.PhoneCode,
                CheckIn_Hour = thisProvider.HotelInfo.CheckIn_Hour,
                CheckIn_Minute = thisProvider.HotelInfo.CheckIn_Minute,
                Checkout_Hour = thisProvider.HotelInfo.Checkout_Hour,
                Checkout_Minute = thisProvider.HotelInfo.Checkout_Minute,
                Minimum_Age = thisProvider.HotelInfo.Minimum_Age                
            };
        }

        public static Provider ToPOCO(this VProviderHotelType thisProvider)
        {
            return new Provider
            {
                Id = thisProvider.Id,
                Name = thisProvider.Name,
                PhoneCode = thisProvider.PhoneCode,
                HotelInfo = new ProviderHotelType
                {
                    CheckIn_Hour = thisProvider.CheckIn_Hour,
                    CheckIn_Minute = thisProvider.CheckIn_Minute,
                    Checkout_Hour = thisProvider.Checkout_Hour,
                    Checkout_Minute = thisProvider.Checkout_Minute,
                    Minimum_Age = thisProvider.Minimum_Age   
                }
            };
        }

    }
}
