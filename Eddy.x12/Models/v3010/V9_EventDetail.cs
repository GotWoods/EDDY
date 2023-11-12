using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("V9")]
public class V9_EventDetail : EdiX12Segment
{
	[Position(01)]
	public string EventCode { get; set; }

	[Position(02)]
	public string Event { get; set; }

	[Position(03)]
	public string EventDate { get; set; }

	[Position(04)]
	public string EventTime { get; set; }

	[Position(05)]
	public string CityName { get; set; }

	[Position(06)]
	public string StateOrProvinceCode { get; set; }

	[Position(07)]
	public string CountryCode { get; set; }

	[Position(08)]
	public string StatusReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<V9_EventDetail>(this);
		validator.Required(x=>x.EventCode);
		validator.Length(x => x.EventCode, 3);
		validator.Length(x => x.Event, 1, 25);
		validator.Length(x => x.EventDate, 6);
		validator.Length(x => x.EventTime, 4);
		validator.Length(x => x.CityName, 2, 19);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2);
		validator.Length(x => x.StatusReasonCode, 3);
		return validator.Results;
	}
}
