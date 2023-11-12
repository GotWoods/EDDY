using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("SMS")]
public class SMS_StationCodesSegment : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string FreightStationAccountingCode { get; set; }

	[Position(03)]
	public string Rule260JunctionCode { get; set; }

	[Position(04)]
	public string PostalCode { get; set; }

	[Position(05)]
	public string ReciprocalSwitchCode { get; set; }

	[Position(06)]
	public string TimeCode { get; set; }

	[Position(07)]
	public string LocationIdentifier { get; set; }

	[Position(08)]
	public string LocationIdentifier2 { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(10)]
	public string IdentificationCode { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SMS_StationCodesSegment>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.FreightStationAccountingCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TimeCode, x=>x.YesNoConditionOrResponseCode2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.FreightStationAccountingCode, 1, 5);
		validator.Length(x => x.Rule260JunctionCode, 1, 5);
		validator.Length(x => x.PostalCode, 3, 15);
		validator.Length(x => x.ReciprocalSwitchCode, 1);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.LocationIdentifier2, 1, 30);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
