using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("PDI")]
public class PDI_PersonDemographicInformation : EdifactSegment
{
	[Position(1)]
	public string GenderCode { get; set; }

	[Position(2)]
	public C085_MaritalStatusDetails MaritalStatusDetails { get; set; }

	[Position(3)]
	public C101_ReligionDetails ReligionDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PDI_PersonDemographicInformation>(this);
		validator.Length(x => x.GenderCode, 1, 3);
		return validator.Results;
	}
}
