using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D07B.Composites;

[Segment("C236")]
public class C236_DangerousGoodsLabel : EdifactComponent
{
	[Position(1)]
	public string DangerousGoodsMarkingIdentifier { get; set; }

	[Position(2)]
	public string DangerousGoodsMarkingIdentifier2 { get; set; }

	[Position(3)]
	public string DangerousGoodsMarkingIdentifier3 { get; set; }

	[Position(4)]
	public string DangerousGoodsMarkingIdentifier4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C236_DangerousGoodsLabel>(this);
		validator.Length(x => x.DangerousGoodsMarkingIdentifier, 1, 4);
		validator.Length(x => x.DangerousGoodsMarkingIdentifier2, 1, 4);
		validator.Length(x => x.DangerousGoodsMarkingIdentifier3, 1, 4);
		validator.Length(x => x.DangerousGoodsMarkingIdentifier4, 1, 4);
		return validator.Results;
	}
}
