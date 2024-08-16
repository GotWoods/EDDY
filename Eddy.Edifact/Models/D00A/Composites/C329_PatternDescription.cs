using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C329")]
public class C329_PatternDescription : EdifactComponent
{
	[Position(1)]
	public string FrequencyCode { get; set; }

	[Position(2)]
	public string DespatchPatternCode { get; set; }

	[Position(3)]
	public string DespatchPatternTimingCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C329_PatternDescription>(this);
		validator.Length(x => x.FrequencyCode, 1, 3);
		validator.Length(x => x.DespatchPatternCode, 1, 3);
		validator.Length(x => x.DespatchPatternTimingCode, 1, 3);
		return validator.Results;
	}
}
