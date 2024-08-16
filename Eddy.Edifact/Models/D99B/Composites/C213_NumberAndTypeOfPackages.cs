using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C213")]
public class C213_NumberAndTypeOfPackages : EdifactComponent
{
	[Position(1)]
	public string NumberOfPackages { get; set; }

	[Position(2)]
	public string PackageTypeDescriptionCode { get; set; }

	[Position(3)]
	public string CodeListIdentificationCode { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(5)]
	public string TypeOfPackages { get; set; }

	[Position(6)]
	public string PackagingRelatedDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C213_NumberAndTypeOfPackages>(this);
		validator.Length(x => x.NumberOfPackages, 1, 8);
		validator.Length(x => x.PackageTypeDescriptionCode, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.TypeOfPackages, 1, 35);
		validator.Length(x => x.PackagingRelatedDescriptionCode, 1, 3);
		return validator.Results;
	}
}
