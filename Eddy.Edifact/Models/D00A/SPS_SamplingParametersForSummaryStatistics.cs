using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("SPS")]
public class SPS_SamplingParametersForSummaryStatistics : EdifactSegment
{
	[Position(1)]
	public C526_FrequencyDetails FrequencyDetails { get; set; }

	[Position(2)]
	public string ConfidencePercent { get; set; }

	[Position(3)]
	public C512_SizeDetails SizeDetails { get; set; }

	[Position(4)]
	public C512_SizeDetails SizeDetails2 { get; set; }

	[Position(5)]
	public C512_SizeDetails SizeDetails3 { get; set; }

	[Position(6)]
	public C512_SizeDetails SizeDetails4 { get; set; }

	[Position(7)]
	public C512_SizeDetails SizeDetails5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SPS_SamplingParametersForSummaryStatistics>(this);
		validator.Length(x => x.ConfidencePercent, 1, 6);
		return validator.Results;
	}
}
