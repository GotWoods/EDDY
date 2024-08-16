using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E018")]
public class E018_PriceInformation : EdifactComponent
{
	[Position(1)]
	public string PriceCodeQualifier { get; set; }

	[Position(2)]
	public string PriceAmount { get; set; }

	[Position(3)]
	public string PriceTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E018_PriceInformation>(this);
		validator.Required(x=>x.PriceCodeQualifier);
		validator.Length(x => x.PriceCodeQualifier, 1, 3);
		validator.Length(x => x.PriceAmount, 1, 15);
		validator.Length(x => x.PriceTypeCode, 1, 3);
		return validator.Results;
	}
}
