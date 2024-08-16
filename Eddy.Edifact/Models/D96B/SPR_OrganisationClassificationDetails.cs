using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Models.D96B;

[Segment("SPR")]
public class SPR_OrganisationClassificationDetails : EdifactSegment
{
	[Position(1)]
	public string SectorSubjectIdentificationQualifier { get; set; }

	[Position(2)]
	public string OrganisationClassificationCoded { get; set; }

	[Position(3)]
	public C844_OrganisationClassificationDetail OrganisationClassificationDetail { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SPR_OrganisationClassificationDetails>(this);
		validator.Required(x=>x.SectorSubjectIdentificationQualifier);
		validator.Length(x => x.SectorSubjectIdentificationQualifier, 1, 3);
		validator.Length(x => x.OrganisationClassificationCoded, 1, 3);
		return validator.Results;
	}
}
