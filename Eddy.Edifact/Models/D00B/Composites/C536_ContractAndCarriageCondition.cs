using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C536")]
public class C536_ContractAndCarriageCondition : EdifactComponent
{
	[Position(1)]
	public string ContractAndCarriageConditionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C536_ContractAndCarriageCondition>(this);
		validator.Required(x=>x.ContractAndCarriageConditionCode);
		validator.Length(x => x.ContractAndCarriageConditionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
