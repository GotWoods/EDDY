using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v8010;

[Segment("BVI")]
public class BVI_BeverageInformation : EdiX12Segment
{
	[Position(01)]
	public string BeverageCategory { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(04)]
	public string CiderType { get; set; }

	[Position(05)]
	public string PreMixDrinkCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BVI_BeverageInformation>(this);
		validator.Required(x=>x.BeverageCategory);
		validator.Length(x => x.BeverageCategory, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.CiderType, 2);
		validator.Length(x => x.PreMixDrinkCode, 2);
		return validator.Results;
	}
}
