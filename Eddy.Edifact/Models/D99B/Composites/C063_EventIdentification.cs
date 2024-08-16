using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C063")]
public class C063_EventIdentification : EdifactComponent
{
	[Position(1)]
	public string EventDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string Event { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C063_EventIdentification>(this);
		validator.Length(x => x.EventDescriptionCode, 1, 35);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.Event, 1, 256);
		return validator.Results;
	}
}
