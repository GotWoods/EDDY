using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("SPR")]
public class SPR_OrganisationClassificationDetails : EdifactSegment
{
	[Position(1)]
	public string SectorAreaIdentificationCodeQualifier { get; set; }

	[Position(2)]
	public string OrganisationClassificationCode { get; set; }

	[Position(3)]
	public C844_OrganisationClassificationDetail OrganisationClassificationDetail { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SPR_OrganisationClassificationDetails>(this);
		validator.Required(x=>x.SectorAreaIdentificationCodeQualifier);
		validator.Length(x => x.SectorAreaIdentificationCodeQualifier, 1, 3);
		validator.Length(x => x.OrganisationClassificationCode, 1, 3);
		return validator.Results;
	}
}
