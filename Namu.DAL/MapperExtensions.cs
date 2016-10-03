
using System;
using System.Linq;
using Namu.Entity.DB;
using Namu.Entity.ServicePOCOs;

namespace Namu.DAL
{
    /// <summary>
    /// Extensiones para conversión POCO - Entity Framework.
    /// </summary>
    internal static partial class MapperExtensions
    {
        public static taddress GetAsEntityFrameworkGenerated(this Address thisAddress)
        {
            return thisAddress != null
                ? new taddress
                {
                    idtaddress = thisAddress.Id,
                    city = thisAddress.City,
                    userid = thisAddress.UserId,
                    country = thisAddress.Country,
                    exactAddress = thisAddress.ExactAddress,
                    state = thisAddress.State
                }
                : null;
        }

        public static Address GetAsPOCO(this taddress thisTaddress)
        {
            return thisTaddress != null
                ? new Address
                {
                    Id = thisTaddress.idtaddress,
                    City = thisTaddress.city,
                    Country = thisTaddress.country,
                    ExactAddress = thisTaddress.exactAddress,
                    State = thisTaddress.state,
                    UserId = thisTaddress.userid ?? 0
                }
                : null;
        }

        public static tprovider GetAsEntityFrameworkGenerated(this Provider thisProvider)
        {
            return thisProvider != null
                ? new tprovider
                {
                    idtprovider = thisProvider.Id,
                    name = thisProvider.Name,
                    numcode = thisProvider.NumCode,
                    phonecode = thisProvider.PhoneCode,
                    providerTypeCode = thisProvider.ProviderTypeCode,
                    taddresses = thisProvider.lstAddresses != null
                        ? thisProvider.lstAddresses
                            .Select(a => a.GetAsEntityFrameworkGenerated())
                            .ToList()
                        : null,
                    tprovider_hoteltype = thisProvider.HotelInfo != null
                        ? thisProvider.HotelInfo.GetAsEntityFrameworkGenerated()
                        : null,
                    tprovider_tourtype = thisProvider.TourInfo != null
                        ? thisProvider.TourInfo.GetAsEntityFrameworkGenerated()
                        : null
                }
                : null;
        }

        public static Provider GetAsPOCO(this tprovider thisTprovider)
        {
            return thisTprovider != null
                ? new Provider
                {
                    Id = thisTprovider.idtprovider,
                    Name = thisTprovider.name,
                    NumCode = thisTprovider.numcode,
                    PhoneCode = thisTprovider.phonecode,
                    ProviderTypeCode = thisTprovider.providerTypeCode,
                    lstAddresses = thisTprovider.taddresses != null
                        ? thisTprovider.taddresses
                            .Select(a => a.GetAsPOCO())
                            .ToList()
                        : null,
                    HotelInfo = thisTprovider.tprovider_hoteltype != null
                        ? thisTprovider.tprovider_hoteltype.GetAsPOCO()
                        : null,
                    TourInfo = thisTprovider.tprovider_tourtype != null
                        ? thisTprovider.tprovider_tourtype.GetAsPOCO()
                        : null
                }
                : null;
        }

        public static tprovider_tourtype GetAsEntityFrameworkGenerated(this ProviderTourType thisProviderTourType)
        {
            return thisProviderTourType != null
                ? new tprovider_tourtype
                {
                    idtprovider = thisProviderTourType.Id,
                    location = thisProviderTourType.Location,
                    ttours = thisProviderTourType.lstTours != null
                            ? thisProviderTourType.lstTours
                            .Select(t=> t.GetAsEntityFrameworkGenerated())
                            .ToList()
                            :null                    
                }
                : null;
        }

        public static ProviderTourType GetAsPOCO(this tprovider_tourtype thisTprovider_tourtype)
        {
            return thisTprovider_tourtype != null
                ? new ProviderTourType
                {
                    Id = thisTprovider_tourtype.idtprovider,
                    Location = thisTprovider_tourtype.location,
                    lstTours = thisTprovider_tourtype.ttours != null
                            ? thisTprovider_tourtype.ttours
                            .Select(t => t.GetAsPOCO())
                            .ToList()
                            : null
                }
                : null;
        }

        public static tprovider_hoteltype GetAsEntityFrameworkGenerated(this ProviderHotelType thisProviderHotelType)
        {
            return thisProviderHotelType != null
                ? new tprovider_hoteltype
                {
                    idtprovider = thisProviderHotelType.Id,
                    checkin_hour = thisProviderHotelType.CheckIn_Hour,
                    checkin_minute = thisProviderHotelType.CheckIn_Minute,
                    checkout_hour = thisProviderHotelType.Checkout_Hour,
                    checkout_minute = thisProviderHotelType.Checkout_Minute,
                    minimum_age = thisProviderHotelType.Minimum_Age,
                    userid = thisProviderHotelType.UserId,
                    troomcategories = thisProviderHotelType.lstRoomCategories != null
                            ? thisProviderHotelType.lstRoomCategories
                            .Select(r => r.GetAsEntityFrameworkGenerated())
                            .ToList()
                            : null
                }
                : null;
        }

        public static ProviderHotelType GetAsPOCO(this tprovider_hoteltype thisTprovider_Hoteltype)
        {
            return thisTprovider_Hoteltype != null
                ? new ProviderHotelType
                {
                    Id = thisTprovider_Hoteltype.idtprovider,
                    CheckIn_Hour = thisTprovider_Hoteltype.checkin_hour,
                    CheckIn_Minute = thisTprovider_Hoteltype.checkin_minute,
                    Checkout_Hour = thisTprovider_Hoteltype.checkout_hour,
                    Checkout_Minute = thisTprovider_Hoteltype.checkout_minute,
                    Minimum_Age = thisTprovider_Hoteltype.minimum_age,
                    UserId = thisTprovider_Hoteltype.userid??0,
                    lstRoomCategories = thisTprovider_Hoteltype.troomcategories != null
                            ? thisTprovider_Hoteltype.troomcategories
                            .Select(r => r.GetAsPOCO())
                            .ToList()
                            : null
                }
                : null;
        }

        public static ttour GetAsEntityFrameworkGenerated(this Tour thisTour)
        {
            return thisTour != null
                ? new ttour
                {
                    idttour = thisTour.Id,
                    departuretime_hour = thisTour.DepartureTime_Hour,
                    departuretime_minute = thisTour.DepartureTime_Minute,
                    description = thisTour.Description,
                    location = thisTour.Location,
                    userid = thisTour.UserId
                }
                : null;
        }

        public static Tour GetAsPOCO(this ttour thisTTour)
        {
            return thisTTour != null
                ? new Tour
                {
                    Id = thisTTour.idttour,
                    DepartureTime_Hour = thisTTour.departuretime_hour,
                    DepartureTime_Minute = thisTTour.departuretime_minute,
                    Description = thisTTour.description,
                    Location = thisTTour.location,
                    UserId = thisTTour.userid ?? 0
                }
                : null;
        }

        public static troomcategory GetAsEntityFrameworkGenerated(this RoomCategory thisRoomCategory)
        {
            return thisRoomCategory != null
                ? new troomcategory
                {
                    name = thisRoomCategory.Name,
                    maxcapacity = thisRoomCategory.MaxCapacity
                }
                : null;
        }

        public static RoomCategory GetAsPOCO(this troomcategory thisTRoomCategory)
        {
            return thisTRoomCategory != null
                ? new RoomCategory
                {
                    Id = thisTRoomCategory.idtroomcategory,
                    Name = thisTRoomCategory.name,
                    MaxCapacity = thisTRoomCategory.maxcapacity
                }
                : null;
        }

        public static tuser GetAsEntityFrameworkGenerated(this User thisUser)
        {
            return thisUser != null
                ? new tuser
                {
                    idtuser = thisUser.Id,
                    name = thisUser.Name,
                    passwordCypher = thisUser.Password,
                    ttokens = thisUser.CurrentToken != null
                    ? new []{ thisUser.CurrentToken.GetAsEntityFrameworkGenerated()}
                    :null
                }
                : null;
        }

        public static User GetAsPOCO(this tuser thisTUser)
        {
            return thisTUser != null
                ? new User
                {
                    Id = thisTUser.idtuser,
                    Name = thisTUser.name,
                    Password = thisTUser.passwordCypher,
                    CurrentToken = thisTUser.ttokens != null
                        ? thisTUser.ttokens.FirstOrDefault(t => t.endDate > DateTime.Now).GetAsPOCO()
                        : null
                }
                : null;
        }

        public static ttoken GetAsEntityFrameworkGenerated(this Token thisToken)
        {
            return thisToken != null
                ? new ttoken
                {
                    idttokens = thisToken.Id,
                    authToken = thisToken.AuthToken,
                    startDate = thisToken.StartDate,
                    endDate = thisToken.EndDate,
                    fktuser = thisToken.GetForeignKeyValueSafely()
                }
                : null;
        }

        public static Token GetAsPOCO(this ttoken thisTToken)
        {
            return thisTToken != null
                ? new Token
                {
                    Id = thisTToken.idttokens,
                    AuthToken = thisTToken.authToken,
                    StartDate = thisTToken.startDate,
                    EndDate = thisTToken.endDate
                }
                : null;
        }

    }
}
