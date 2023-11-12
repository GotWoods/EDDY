using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7060;

[Segment("NFB")]
public class NFB_NutritionFactsPanelFooterCalorieDiet : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NFB_NutritionFactsPanelFooterCalorieDiet>(this);
		validator.Required(x=>x.Quantity);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
