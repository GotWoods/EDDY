using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("PDI")]
public class PDI_PersonDemographicInformation : EdifactSegment
{
	[Position(1)]
	public string SexCoded { get; set; }

	[Position(2)]
	public C085_MaritalStatusDetails MaritalStatusDetails { get; set; }

	[Position(3)]
	public C101_ReligionDetails ReligionDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PDI_PersonDemographicInformation>(this);
		validator.Length(x => x.SexCoded, 1, 3);
		return validator.Results;
	}
}
