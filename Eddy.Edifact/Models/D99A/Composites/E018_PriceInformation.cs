using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99A.Composites;

[Segment("E018")]
public class E018_PriceInformation : EdifactComponent
{
	[Position(1)]
	public string PriceQualifier { get; set; }

	[Position(2)]
	public string Price { get; set; }

	[Position(3)]
	public string PriceTypeCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E018_PriceInformation>(this);
		validator.Required(x=>x.PriceQualifier);
		validator.Length(x => x.PriceQualifier, 1, 3);
		validator.Length(x => x.Price, 1, 15);
		validator.Length(x => x.PriceTypeCoded, 1, 3);
		return validator.Results;
	}
}
