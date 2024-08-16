using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C517")]
public class C517_LocationIdentification : EdifactComponent
{
	[Position(1)]
	public string PlaceLocationIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string PlaceLocation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C517_LocationIdentification>(this);
		validator.Length(x => x.PlaceLocationIdentification, 1, 25);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.PlaceLocation, 1, 70);
		return validator.Results;
	}
}
