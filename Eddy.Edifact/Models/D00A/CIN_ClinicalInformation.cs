using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("CIN")]
public class CIN_ClinicalInformation : EdifactSegment
{
	[Position(1)]
	public string ClinicalInformationTypeCodeQualifier { get; set; }

	[Position(2)]
	public C836_ClinicalInformationDetails ClinicalInformationDetails { get; set; }

	[Position(3)]
	public C837_CertaintyDetails CertaintyDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CIN_ClinicalInformation>(this);
		validator.Required(x=>x.ClinicalInformationTypeCodeQualifier);
		validator.Length(x => x.ClinicalInformationTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
