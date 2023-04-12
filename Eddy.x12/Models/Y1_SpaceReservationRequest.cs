using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("Y1")]
public class Y1_SpaceReservationRequest : EdiX12Segment
{
	[Position(01)]
	public string SailingFlightDateEstimated { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(04)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(05)]
	public string EntityIdentifierCode { get; set; }

	[Position(06)]
	public string CityName { get; set; }

	[Position(07)]
	public string StateOrProvinceCode { get; set; }

	[Position(08)]
	public string TariffServiceCode { get; set; }

	[Position(09)]
	public string DateTimeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Y1_SpaceReservationRequest>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Date, x=>x.DateTimeQualifier);
		validator.Length(x => x.SailingFlightDateEstimated, 8);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.TariffServiceCode, 2);
		validator.Length(x => x.DateTimeQualifier, 3);
		return validator.Results;
	}
}
