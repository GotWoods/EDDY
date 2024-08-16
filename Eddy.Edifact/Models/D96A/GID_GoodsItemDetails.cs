using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("GID")]
public class GID_GoodsItemDetails : EdifactSegment
{
	[Position(1)]
	public string GoodsItemNumber { get; set; }

	[Position(2)]
	public C213_NumberAndTypeOfPackages NumberAndTypeOfPackages { get; set; }

	[Position(3)]
	public C213_NumberAndTypeOfPackages NumberAndTypeOfPackages2 { get; set; }

	[Position(4)]
	public C213_NumberAndTypeOfPackages NumberAndTypeOfPackages3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GID_GoodsItemDetails>(this);
		validator.Length(x => x.GoodsItemNumber, 1, 5);
		return validator.Results;
	}
}
