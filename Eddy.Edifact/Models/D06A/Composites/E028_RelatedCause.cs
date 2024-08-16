using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D06A.Composites;

[Segment("E028")]
public class E028_RelatedCause : EdifactComponent
{
	[Position(1)]
	public string RelatedCauseCode { get; set; }

	[Position(2)]
	public string Date { get; set; }

	[Position(3)]
	public string CountrySubdivisionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E028_RelatedCause>(this);
		validator.Length(x => x.RelatedCauseCode, 1, 3);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.CountrySubdivisionIdentifier, 1, 9);
		return validator.Results;
	}
}
