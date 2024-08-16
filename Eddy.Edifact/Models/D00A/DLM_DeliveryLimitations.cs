using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("DLM")]
public class DLM_DeliveryLimitations : EdifactSegment
{
	[Position(1)]
	public string BackOrderArrangementTypeCode { get; set; }

	[Position(2)]
	public C522_Instruction Instruction { get; set; }

	[Position(3)]
	public C214_SpecialServicesIdentification SpecialServicesIdentification { get; set; }

	[Position(4)]
	public string SubstitutionConditionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DLM_DeliveryLimitations>(this);
		validator.Length(x => x.BackOrderArrangementTypeCode, 1, 3);
		validator.Length(x => x.SubstitutionConditionCode, 1, 3);
		return validator.Results;
	}
}
