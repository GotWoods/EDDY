using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("PDT")]
public class PDT_ProductInformation : EdifactSegment
{
	[Position(1)]
	public string ProductDetailsQualifier { get; set; }

	[Position(2)]
	public E996_ProductClassDetails ProductClassDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PDT_ProductInformation>(this);
		validator.Length(x => x.ProductDetailsQualifier, 1, 3);
		return validator.Results;
	}
}
