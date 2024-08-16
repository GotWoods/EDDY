using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C236")]
public class C236_DangerousGoodsLabel : EdifactComponent
{
	[Position(1)]
	public string DangerousGoodsLabelMarking { get; set; }

	[Position(2)]
	public string DangerousGoodsLabelMarking2 { get; set; }

	[Position(3)]
	public string DangerousGoodsLabelMarking3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C236_DangerousGoodsLabel>(this);
		validator.Length(x => x.DangerousGoodsLabelMarking, 1, 4);
		validator.Length(x => x.DangerousGoodsLabelMarking2, 1, 4);
		validator.Length(x => x.DangerousGoodsLabelMarking3, 1, 4);
		return validator.Results;
	}
}
