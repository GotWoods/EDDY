using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("ATT")]
public class ATT_Attribute : EdifactSegment
{
	[Position(1)]
	public string AttributeFunctionQualifier { get; set; }

	[Position(2)]
	public C955_AttributeType AttributeType { get; set; }

	[Position(3)]
	public C956_AttributeDetails AttributeDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ATT_Attribute>(this);
		validator.Required(x=>x.AttributeFunctionQualifier);
		validator.Length(x => x.AttributeFunctionQualifier, 1, 3);
		return validator.Results;
	}
}
