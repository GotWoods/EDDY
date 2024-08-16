using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C531")]
public class C531_PackagingDetails : EdifactComponent
{
	[Position(1)]
	public string PackagingLevelCode { get; set; }

	[Position(2)]
	public string PackagingRelatedDescriptionCode { get; set; }

	[Position(3)]
	public string PackagingTermsAndConditionsCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C531_PackagingDetails>(this);
		validator.Length(x => x.PackagingLevelCode, 1, 3);
		validator.Length(x => x.PackagingRelatedDescriptionCode, 1, 3);
		validator.Length(x => x.PackagingTermsAndConditionsCode, 1, 3);
		return validator.Results;
	}
}
