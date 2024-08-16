using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C088")]
public class C088_InstitutionIdentification : EdifactComponent
{
	[Position(1)]
	public string InstitutionNameCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string InstitutionBranchIdentifier { get; set; }

	[Position(5)]
	public string CodeListIdentificationCode2 { get; set; }

	[Position(6)]
	public string CodeListResponsibleAgencyCode2 { get; set; }

	[Position(7)]
	public string InstitutionName { get; set; }

	[Position(8)]
	public string InstitutionBranchLocationName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C088_InstitutionIdentification>(this);
		validator.Length(x => x.InstitutionNameCode, 1, 11);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.InstitutionBranchIdentifier, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode2, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode2, 1, 3);
		validator.Length(x => x.InstitutionName, 1, 70);
		validator.Length(x => x.InstitutionBranchLocationName, 1, 70);
		return validator.Results;
	}
}
