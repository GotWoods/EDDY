using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("E362")]
public class E362_RelatedTimeInformation : EdifactComponent
{
	[Position(1)]
	public string TimeValue { get; set; }

	[Position(2)]
	public string TimeValue2 { get; set; }

	[Position(3)]
	public string TimeZoneDifferenceValue { get; set; }

	[Position(4)]
	public string DateVariationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E362_RelatedTimeInformation>(this);
		validator.Length(x => x.TimeValue, 4);
		validator.Length(x => x.TimeValue2, 4);
		validator.Length(x => x.TimeZoneDifferenceValue, 1, 4);
		validator.Length(x => x.DateVariationNumber, 1, 5);
		return validator.Results;
	}
}
