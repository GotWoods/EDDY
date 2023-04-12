using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("TBP")]
public class TBP_FrequencyBasis : EdiX12Segment
{
	[Position(01)]
	public string ProductProcessCharacteristicCode { get; set; }

	[Position(02)]
	public string FrequencyCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TBP_FrequencyBasis>(this);
		validator.Required(x=>x.ProductProcessCharacteristicCode);
		validator.AtLeastOneIsRequired(x=>x.FrequencyCode, x=>x.Description);
		validator.Length(x => x.ProductProcessCharacteristicCode, 2, 3);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
