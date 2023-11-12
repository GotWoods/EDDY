using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("V9")]
public class V9_EventDetail : EdiX12Segment
{
	[Position(01)]
	public string EventCode { get; set; }

	[Position(02)]
	public string Event { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Time { get; set; }

	[Position(05)]
	public string CityName { get; set; }

	[Position(06)]
	public string StateOrProvinceCode { get; set; }

	[Position(07)]
	public string CountryCode { get; set; }

	[Position(08)]
	public string StatusReasonCode { get; set; }

	[Position(09)]
	public string StandardPointLocationCode { get; set; }

	[Position(10)]
	public string Time2 { get; set; }

	[Position(11)]
	public string TrainDelayReasonCode { get; set; }

	[Position(12)]
	public string FreeFormMessage { get; set; }

	[Position(13)]
	public string TimeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<V9_EventDetail>(this);
		validator.Required(x=>x.EventCode);
		validator.ARequiresB(x=>x.TimeCode, x=>x.Time);
		validator.Length(x => x.EventCode, 3);
		validator.Length(x => x.Event, 1, 25);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.Time2, 4, 8);
		validator.Length(x => x.TrainDelayReasonCode, 2);
		validator.Length(x => x.FreeFormMessage, 1, 30);
		validator.Length(x => x.TimeCode, 2);
		return validator.Results;
	}
}
