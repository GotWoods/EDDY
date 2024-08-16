using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C585")]
public class C585_PriorityDetails : EdifactComponent
{
	[Position(1)]
	public string PriorityDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string PriorityDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C585_PriorityDetails>(this);
		validator.Length(x => x.PriorityDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.PriorityDescription, 1, 35);
		return validator.Results;
	}
}
