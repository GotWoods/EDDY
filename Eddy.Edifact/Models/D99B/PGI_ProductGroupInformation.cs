using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("PGI")]
public class PGI_ProductGroupInformation : EdifactSegment
{
	[Position(1)]
	public string ProductGroupTypeCode { get; set; }

	[Position(2)]
	public C288_ProductGroup ProductGroup { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PGI_ProductGroupInformation>(this);
		validator.Required(x=>x.ProductGroupTypeCode);
		validator.Length(x => x.ProductGroupTypeCode, 1, 3);
		return validator.Results;
	}
}
