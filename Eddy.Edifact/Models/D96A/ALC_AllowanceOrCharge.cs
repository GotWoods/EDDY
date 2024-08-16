using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("ALC")]
public class ALC_AllowanceOrCharge : EdifactSegment
{
	[Position(1)]
	public string AllowanceOrChargeQualifier { get; set; }

	[Position(2)]
	public C552_AllowanceChargeInformation AllowanceChargeInformation { get; set; }

	[Position(3)]
	public string SettlementCoded { get; set; }

	[Position(4)]
	public string CalculationSequenceIndicatorCoded { get; set; }

	[Position(5)]
	public C214_SpecialServicesIdentification SpecialServicesIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ALC_AllowanceOrCharge>(this);
		validator.Required(x=>x.AllowanceOrChargeQualifier);
		validator.Length(x => x.AllowanceOrChargeQualifier, 1, 3);
		validator.Length(x => x.SettlementCoded, 1, 3);
		validator.Length(x => x.CalculationSequenceIndicatorCoded, 1, 3);
		return validator.Results;
	}
}
