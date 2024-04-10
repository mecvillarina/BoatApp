using System.ComponentModel;
using System.Globalization;
using BoatApp.Common.Enums;

namespace BoatApp.Common.Extensions;

public static class EnumExtensions
{
    public static string GetDescription<T>(this T e) where T : IConvertible
    {
        if (e is Enum)
        {
            Type type = e.GetType();
            Array values = Enum.GetValues(type);

            foreach (int val in values)
            {
                if (val == e.ToInt32(CultureInfo.InvariantCulture))
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttribute = memInfo[0]
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .FirstOrDefault() as DescriptionAttribute;

                    if (descriptionAttribute != null)
                    {
                        return descriptionAttribute.Description;
                    }
                }
            }

            return e.ToString();
        }

        return string.Empty;
    }

    public static List<TEnum> GetValues<TEnum>() where TEnum : struct, Enum => Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
    
    public static BoatRequestStatus GetBoatRequestStatus(string value)
    {
        return value switch
        {
            "drop_request_submitted" => BoatRequestStatus.DropRequestSubmitted,
            "drop_confirmed" => BoatRequestStatus.DropConfirmed,
            "in_transit_drop" => BoatRequestStatus.InTransitDrop,
            "dropoff_completed" => BoatRequestStatus.DropOffCompleted,
            "pickup_request_submitted" => BoatRequestStatus.PickupRequestSubmitted,
            "pickup_confirmed" => BoatRequestStatus.PickupConfirmed,
            "in_transit_pickup" => BoatRequestStatus.InTransitPickup,
            "pickup_completed" => BoatRequestStatus.PickupCompleted,
            _ => BoatRequestStatus.RequestDrop
        };
    }
}