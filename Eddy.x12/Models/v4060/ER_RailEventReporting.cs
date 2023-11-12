using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4060;

[Segment("ER")]
public class ER_RailEventReporting : EdiX12Segment
{
	[Position(01)]
	public string ActionCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string EventCode { get; set; }

	[Position(04)]
	public string StandardPointLocationCode { get; set; }

	[Position(05)]
	public string DateTimeQualifier { get; set; }

	[Position(06)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(07)]
	public string DateTimePeriod { get; set; }

	[Position(08)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(09)]
	public string InterchangeTrainIdentification { get; set; }

	[Position(10)]
	public string Date { get; set; }

	[Position(11)]
	public string LoadEmptyStatusCode { get; set; }

	[Position(12)]
	public string StandardPointLocationCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ER_RailEventReporting>(this);
		validator.Required(x=>x.ActionCode);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.EventCode);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.DateTimeQualifier);
		validator.Required(x=>x.DateTimePeriodFormatQualifier);
		validator.Required(x=>x.DateTimePeriod);
		validator.ARequiresB(x=>x.InterchangeTrainIdentification, x=>x.Date);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.EventCode, 3);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.InterchangeTrainIdentification, 1, 10);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.LoadEmptyStatusCode, 1);
		validator.Length(x => x.StandardPointLocationCode2, 6, 9);
		return validator.Results;
	}
}
