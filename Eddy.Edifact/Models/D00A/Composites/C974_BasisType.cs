using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C974")]
public class C974_BasisType : EdifactComponent
{
	[Position(1)]
	public string BasisTypeDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string BasisTypeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C974_BasisType>(this);
		validator.Length(x => x.BasisTypeDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.BasisTypeDescription, 1, 35);
		return validator.Results;
	}
}
