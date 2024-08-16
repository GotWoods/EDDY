using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E816")]
public class E816_NameComponentDetails : EdifactComponent
{
	[Position(1)]
	public string NameComponentQualifier { get; set; }

	[Position(2)]
	public string NameComponent { get; set; }

	[Position(3)]
	public string NameComponentStatusCoded { get; set; }

	[Position(4)]
	public string NameComponentOriginalRepresentationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E816_NameComponentDetails>(this);
		validator.Required(x=>x.NameComponentQualifier);
		validator.Length(x => x.NameComponentQualifier, 1, 3);
		validator.Length(x => x.NameComponent, 1, 70);
		validator.Length(x => x.NameComponentStatusCoded, 1, 3);
		validator.Length(x => x.NameComponentOriginalRepresentationCoded, 1, 3);
		return validator.Results;
	}
}
