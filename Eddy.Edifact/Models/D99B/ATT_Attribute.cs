using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("ATT")]
public class ATT_Attribute : EdifactSegment
{
	[Position(1)]
	public string AttributeFunctionCodeQualifier { get; set; }

	[Position(2)]
	public C955_AttributeType AttributeType { get; set; }

	[Position(3)]
	public C956_AttributeDetail AttributeDetail { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ATT_Attribute>(this);
		validator.Required(x=>x.AttributeFunctionCodeQualifier);
		validator.Length(x => x.AttributeFunctionCodeQualifier, 1, 3);
		return validator.Results;
	}
}
