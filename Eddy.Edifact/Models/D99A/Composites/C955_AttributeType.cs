using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99A.Composites;

[Segment("C955")]
public class C955_AttributeType : EdifactComponent
{
	[Position(1)]
	public string AttributeTypeIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C955_AttributeType>(this);
		validator.Required(x=>x.AttributeTypeIdentification);
		validator.Length(x => x.AttributeTypeIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
