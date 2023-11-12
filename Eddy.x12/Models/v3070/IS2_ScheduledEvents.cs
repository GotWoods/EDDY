using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("IS2")]
public class IS2_ScheduledEvents : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string EventCode { get; set; }

	[Position(03)]
	public string AccomplishCode { get; set; }

	[Position(04)]
	public string StandardPointLocationCode { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string Time { get; set; }

	[Position(07)]
	public string TimeCode { get; set; }

	[Position(08)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(09)]
	public string InterchangeTrainIdentification { get; set; }

	[Position(10)]
	public string Date2 { get; set; }

	[Position(11)]
	public string BlockIdentification { get; set; }

	[Position(12)]
	public string Date3 { get; set; }

	[Position(13)]
	public string Time2 { get; set; }

	[Position(14)]
	public string Date4 { get; set; }

	[Position(15)]
	public string Time3 { get; set; }

	[Position(16)]
	public string CityName { get; set; }

	[Position(17)]
	public string StateOrProvinceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IS2_ScheduledEvents>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.EventCode);
		validator.Required(x=>x.AccomplishCode);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Time);
		validator.ARequiresB(x=>x.StateOrProvinceCode, x=>x.CityName);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.EventCode, 3);
		validator.Length(x => x.AccomplishCode, 1);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.InterchangeTrainIdentification, 1, 10);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.BlockIdentification, 1, 12);
		validator.Length(x => x.Date3, 6);
		validator.Length(x => x.Time2, 4, 8);
		validator.Length(x => x.Date4, 6);
		validator.Length(x => x.Time3, 4, 8);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		return validator.Results;
	}
}
