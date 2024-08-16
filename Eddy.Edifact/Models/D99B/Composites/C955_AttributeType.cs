using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C955")]
public class C955_AttributeType : EdifactComponent
{
	[Position(1)]
	public string AttributeTypeDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string AttributeTypeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C955_AttributeType>(this);
		validator.Length(x => x.AttributeTypeDescriptionCode, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.AttributeTypeDescription, 1, 70);
		return validator.Results;
	}
}