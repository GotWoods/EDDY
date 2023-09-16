using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("Q1")]
public class Q1_StatusDetailsAir : EdiX12Segment
{
	[Position(01)]
	public string StatusCode { get; set; }

	[Position(02)]
	public string StatusLocation { get; set; }

	[Position(03)]
	public string StatusDate { get; set; }

	[Position(04)]
	public string StatusTime { get; set; }

	[Position(05)]
	public string FlightVoyageNumber { get; set; }

	[Position(06)]
	public string TimeQualifier { get; set; }

	[Position(07)]
	public string AirportCode { get; set; }

	[Position(08)]
	public string CustomsInhibitClearanceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Q1_StatusDetailsAir>(this);
		validator.Required(x=>x.StatusCode);
		validator.Required(x=>x.StatusLocation);
		validator.Required(x=>x.StatusDate);
		validator.Required(x=>x.StatusTime);
		validator.Length(x => x.StatusCode, 1, 2);
		validator.Length(x => x.StatusLocation, 3, 5);
		validator.Length(x => x.StatusDate, 6);
		validator.Length(x => x.StatusTime, 4);
		validator.Length(x => x.FlightVoyageNumber, 2, 10);
		validator.Length(x => x.TimeQualifier, 1);
		validator.Length(x => x.AirportCode, 3, 5);
		validator.Length(x => x.CustomsInhibitClearanceCode, 2);
		return validator.Results;
	}
}
