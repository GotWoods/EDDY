using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("NF1")]
public class NF1_NutritionFactsPanel : EdiX12Segment
{
	[Position(01)]
	public string NutritionFactsTableNFTFormatType { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string ConditionIndicatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NF1_NutritionFactsPanel>(this);
		validator.Required(x=>x.NutritionFactsTableNFTFormatType);
		validator.Required(x=>x.Quantity);
		validator.Length(x => x.NutritionFactsTableNFTFormatType, 1, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ConditionIndicatorCode, 2, 3);
		return validator.Results;
	}
}
