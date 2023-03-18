using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._210;

public class InterlineInformation
{
    public string StandardCarrierAlphaCode { get; set; }
    public string RoutingSequenceCode { get; set; }
    public string CityName { get; set; }
    public string TransportationMethod { get; set; }
    public string StateOrProvinceCode { get; set; }

    public static InterlineInformation FromMS3(MS3_InterlineInformation input)
    {
        var result = new InterlineInformation()
        {
            StandardCarrierAlphaCode = input.StandardCarrierAlphaCode,
            RoutingSequenceCode = input.RoutingSequenceCode,
            CityName = input.CityName,
            TransportationMethod = input.TransportationMethodTypeCode,
            StateOrProvinceCode = input.StateOrProvinceCode
        };
        return result;
    }

    public MS3_InterlineInformation ToMS3()
    {
        var result = new MS3_InterlineInformation()
        {
            StandardCarrierAlphaCode = StandardCarrierAlphaCode,
            RoutingSequenceCode = RoutingSequenceCode,
            CityName = CityName,
            TransportationMethodTypeCode = TransportationMethod,
            StateOrProvinceCode = StateOrProvinceCode
        };
        return result;
    }
}