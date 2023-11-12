using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010;

[Segment("SEF")]
public class SEF_PaymentHandling : EdiX12Segment
{
	[Position(01)]
	public string FrequencyPatternCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string PaymentHandlingCode { get; set; }

	[Position(04)]
	public string Description2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SEF_PaymentHandling>(this);
		validator.Required(x=>x.FrequencyPatternCode);
		validator.AtLeastOneIsRequired(x=>x.PaymentHandlingCode, x=>x.Description2);
		validator.Length(x => x.FrequencyPatternCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.PaymentHandlingCode, 2);
		validator.Length(x => x.Description2, 1, 80);
		return validator.Results;
	}
}
