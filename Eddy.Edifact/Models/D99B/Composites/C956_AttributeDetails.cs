using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C956")]
public class C956_AttributeDetail : EdifactComponent
{
	[Position(1)]
	public string AttributeDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string AttributeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C956_AttributeDetail>(this);
		validator.Length(x => x.AttributeDescriptionCode, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.AttributeDescription, 1, 256);
		return validator.Results;
	}
}
