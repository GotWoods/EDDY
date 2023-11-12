using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020.Composites;

namespace Eddy.x12.Models.v8020;

[Segment("ING")]
public class ING_Ingredients : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public C068_CompositeIngredientInformation CompositeIngredientInformation { get; set; }

	[Position(03)]
	public decimal? PercentDecimalFormat { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ING_Ingredients>(this);
		validator.Required(x=>x.AssignedIdentification);
		validator.Required(x=>x.CompositeIngredientInformation);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.PercentDecimalFormat, 1, 6);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		return validator.Results;
	}
}
