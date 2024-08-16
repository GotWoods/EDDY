using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Models.D96B;

[Segment("CIN")]
public class CIN_ClinicalInformation : EdifactSegment
{
	[Position(1)]
	public string ClinicalInformationQualifier { get; set; }

	[Position(2)]
	public C836_ClinicalInformationDetails ClinicalInformationDetails { get; set; }

	[Position(3)]
	public C837_CertaintyDetails CertaintyDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CIN_ClinicalInformation>(this);
		validator.Required(x=>x.ClinicalInformationQualifier);
		validator.Length(x => x.ClinicalInformationQualifier, 1, 3);
		return validator.Results;
	}
}
