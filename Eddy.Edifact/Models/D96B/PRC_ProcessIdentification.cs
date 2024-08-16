using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Models.D96B;

[Segment("PRC")]
public class PRC_ProcessIdentification : EdifactSegment
{
	[Position(1)]
	public C242_ProcessTypeAndDescription ProcessTypeAndDescription { get; set; }

	[Position(2)]
	public C830_ProcessIdentificationDetails ProcessIdentificationDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRC_ProcessIdentification>(this);
		return validator.Results;
	}
}
