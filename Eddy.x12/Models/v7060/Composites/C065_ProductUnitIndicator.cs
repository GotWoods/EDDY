using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7060.Composites;

[Segment("C065")]
public class C065_ProductUnitIndicator : EdiX12Component
{
	[Position(00)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(01)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode4 { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode5 { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode6 { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode7 { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode8 { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode9 { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode10 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C065_ProductUnitIndicator>(this);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode4, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode5, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode6, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode7, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode8, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode9, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode10, 1);
		return validator.Results;
	}
}
