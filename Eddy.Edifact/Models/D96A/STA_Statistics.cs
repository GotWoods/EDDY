using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("STA")]
public class STA_Statistics : EdifactSegment
{
	[Position(1)]
	public string StatisticTypeCoded { get; set; }

	[Position(2)]
	public C527_StatisticalDetails StatisticalDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<STA_Statistics>(this);
		validator.Required(x=>x.StatisticTypeCoded);
		validator.Length(x => x.StatisticTypeCoded, 1, 3);
		return validator.Results;
	}
}
