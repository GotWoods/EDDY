using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C878")]
public class C878_ChargeAllowanceAccount : EdifactComponent
{
	[Position(1)]
	public string InstitutionBranchNumber { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string AccountHolderNumber { get; set; }

	[Position(5)]
	public string CurrencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C878_ChargeAllowanceAccount>(this);
		validator.Required(x=>x.InstitutionBranchNumber);
		validator.Length(x => x.InstitutionBranchNumber, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.AccountHolderNumber, 1, 35);
		validator.Length(x => x.CurrencyCoded, 1, 3);
		return validator.Results;
	}
}
