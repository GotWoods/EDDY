using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7060;

[Segment("NFE")]
public class NFE_NutritionFactsPanelProductName : EdiX12Segment
{
	[Position(01)]
	public C071_CompositeMultipleLanguageTextInformation CompositeMultipleLanguageTextInformation { get; set; }

	[Position(02)]
	public C071_CompositeMultipleLanguageTextInformation CompositeMultipleLanguageTextInformation2 { get; set; }

	[Position(03)]
	public C071_CompositeMultipleLanguageTextInformation CompositeMultipleLanguageTextInformation3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NFE_NutritionFactsPanelProductName>(this);
		validator.Required(x=>x.CompositeMultipleLanguageTextInformation);
		return validator.Results;
	}
}
