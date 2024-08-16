using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96B.Composites;

[Segment("C839")]
public class C839_AttendeeCategory : EdifactComponent
{
	[Position(1)]
	public string AttendeeCategoryCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string AttendeeCategory { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C839_AttendeeCategory>(this);
		validator.Length(x => x.AttendeeCategoryCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.AttendeeCategory, 1, 35);
		return validator.Results;
	}
}
