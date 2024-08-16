using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C951")]
public class C951_Occupation : EdifactComponent
{
	[Position(1)]
	public string OccupationCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string Occupation { get; set; }

	[Position(5)]
	public string Occupation2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C951_Occupation>(this);
		validator.Length(x => x.OccupationCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.Occupation, 1, 35);
		validator.Length(x => x.Occupation2, 1, 35);
		return validator.Results;
	}
}
