using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C288")]
public class C288_ProductGroup : EdifactComponent
{
	[Position(1)]
	public string ProductGroupCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string ProductGroup { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C288_ProductGroup>(this);
		validator.Length(x => x.ProductGroupCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.ProductGroup, 1, 35);
		return validator.Results;
	}
}
