using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C288")]
public class C288_ProductGroup : EdifactComponent
{
	[Position(1)]
	public string ProductGroupNameCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ProductGroupName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C288_ProductGroup>(this);
		validator.Length(x => x.ProductGroupNameCode, 1, 25);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ProductGroupName, 1, 35);
		return validator.Results;
	}
}
