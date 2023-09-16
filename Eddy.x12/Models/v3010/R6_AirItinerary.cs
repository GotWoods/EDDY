using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

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
	public string EventDate { get; set; }

	[Position(06)]
	public string EventTime { get; set; }

	[Position(07)]
	public string AirportCode2 { get; set; }

	[Position(08)]
	public string EventDate2 { get; set; }

	[Position(09)]
	public string EventTime2 { get; set; }

	[Position(10)]
	public string CountryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<R6_AirItinerary>(this);
		validator.Required(x=>x.RoutingSequenceCode);
		validator.Required(x=>x.AirportCode);
		validator.Required(x=>x.AirCarrierCode);
		validator.Required(x=>x.EventDate);
		validator.Required(x=>x.EventTime);
		validator.Required(x=>x.EventDate2);
		validator.Required(x=>x.EventTime2);
		validator.Length(x => x.RoutingSequenceCode, 1, 2);
		validator.Length(x => x.AirportCode, 3, 5);
		validator.Length(x => x.AirCarrierCode, 3);
		validator.Length(x => x.FlightVoyageNumber, 2, 10);
		validator.Length(x => x.EventDate, 6);
		validator.Length(x => x.EventTime, 4);
		validator.Length(x => x.AirportCode2, 3, 5);
		validator.Length(x => x.EventDate2, 6);
		validator.Length(x => x.EventTime2, 4);
		validator.Length(x => x.CountryCode, 2);
		return validator.Results;
	}
}
