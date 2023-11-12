using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("R6")]
public class R6_AirItinerary : EdiX12Segment
{
	[Position(01)]
	public string RoutingSequenceCode { get; set; }

	[Position(02)]
	public string AirportCode { get; set; }

	[Position(03)]
	public string AirCarrierCode { get; set; }

	[Position(04)]
	public string FlightVoyageNumber { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string Time { get; set; }

	[Position(07)]
	public string AirportCode2 { get; set; }

	[Position(08)]
	public string Date2 { get; set; }

	[Position(09)]
	public string Time2 { get; set; }

	[Position(10)]
	public string CountryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<R6_AirItinerary>(this);
		validator.Required(x=>x.RoutingSequenceCode);
		validator.Required(x=>x.AirportCode);
		validator.Required(x=>x.AirCarrierCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Time);
		validator.Required(x=>x.Date2);
		validator.Required(x=>x.Time2);
		validator.Length(x => x.RoutingSequenceCode, 1, 2);
		validator.Length(x => x.AirportCode, 3, 5);
		validator.Length(x => x.AirCarrierCode, 3);
		validator.Length(x => x.FlightVoyageNumber, 2, 10);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 6);
		validator.Length(x => x.AirportCode2, 3, 5);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.Time2, 4, 6);
		validator.Length(x => x.CountryCode, 2);
		return validator.Results;
	}
}
