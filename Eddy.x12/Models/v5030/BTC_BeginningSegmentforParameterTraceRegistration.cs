using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("BTC")]
public class BTC_BeginningSegmentForParameterTraceRegistration : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ParameterTraceRegistrationTypeCode { get; set; }

	[Position(03)]
	public string ParameterTraceTypeCode { get; set; }

	[Position(04)]
	public string OutputEventSelectionCode { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(09)]
	public int? Count { get; set; }

	[Position(10)]
	public string IdentificationCode { get; set; }

	[Position(11)]
	public string AssociationOfAmericanRailroadsAARPoolCode { get; set; }

	[Position(12)]
	public string IndustryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BTC_BeginningSegmentForParameterTraceRegistration>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ParameterTraceRegistrationTypeCode);
		validator.Required(x=>x.ParameterTraceTypeCode);
		validator.Required(x=>x.OutputEventSelectionCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ParameterTraceRegistrationTypeCode, 1);
		validator.Length(x => x.ParameterTraceTypeCode, 1);
		validator.Length(x => x.OutputEventSelectionCode, 1);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.Count, 1, 9);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.AssociationOfAmericanRailroadsAARPoolCode, 7);
		validator.Length(x => x.IndustryCode, 1, 30);
		return validator.Results;
	}
}
