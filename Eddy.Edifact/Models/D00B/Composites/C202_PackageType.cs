using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C202")]
public class C202_PackageType : EdifactComponent
{
	[Position(1)]
	public string PackageTypeDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string TypeOfPackages { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C202_PackageType>(this);
		validator.Length(x => x.PackageTypeDescriptionCode, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.TypeOfPackages, 1, 35);
		return validator.Results;
	}
}
