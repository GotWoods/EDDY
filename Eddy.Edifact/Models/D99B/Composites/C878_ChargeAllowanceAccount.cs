using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C878")]
public class C878_ChargeAllowanceAccount : EdifactComponent
{
	[Position(1)]
	public string InstitutionBranchNumber { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string AccountHolderNumber { get; set; }

	[Position(5)]
	public string CurrencyIdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C878_ChargeAllowanceAccount>(this);
		validator.Required(x=>x.InstitutionBranchNumber);
		validator.Length(x => x.InstitutionBranchNumber, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.AccountHolderNumber, 1, 35);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		return validator.Results;
	}
}