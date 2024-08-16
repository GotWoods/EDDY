using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("ATR")]
public class ATR_Attribute : EdifactSegment
{
	[Position(1)]
	public string AttributeFunctionCodeQualifier { get; set; }

	[Position(2)]
	public E003_AttributeInformation AttributeInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ATR_Attribute>(this);
		validator.Required(x=>x.AttributeFunctionCodeQualifier);
		validator.Required(x=>x.AttributeInformation);
		validator.Length(x => x.AttributeFunctionCodeQualifier, 1, 3);
		return validator.Results;
	}
}
