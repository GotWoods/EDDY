using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("ALC")]
public class ALC_AllowanceOrCharge : EdifactSegment
{
	[Position(1)]
	public string AllowanceOrChargeCodeQualifier { get; set; }

	[Position(2)]
	public C552_AllowanceChargeInformation AllowanceChargeInformation { get; set; }

	[Position(3)]
	public string SettlementMeansCode { get; set; }

	[Position(4)]
	public string CalculationSequenceCode { get; set; }

	[Position(5)]
	public C214_SpecialServicesIdentification SpecialServicesIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ALC_AllowanceOrCharge>(this);
		validator.Required(x=>x.AllowanceOrChargeCodeQualifier);
		validator.Length(x => x.AllowanceOrChargeCodeQualifier, 1, 3);
		validator.Length(x => x.SettlementMeansCode, 1, 3);
		validator.Length(x => x.CalculationSequenceCode, 1, 3);
		return validator.Results;
	}
}
