using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("GS")]
public class GS_FunctionalGroupHeader : Eddy.x12.Models.v3030.GS_FunctionalGroupHeader
{
	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GS_FunctionalGroupHeader>(this);
		validator.Required(x=>x.FunctionalIdentifierCode);
		validator.Required(x=>x.ApplicationSendersCode);
		validator.Required(x=>x.ApplicationReceiversCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Time);
		validator.Required(x=>x.GroupControlNumber);
		validator.Required(x=>x.ResponsibleAgencyCode);
		validator.Required(x=>x.VersionReleaseIndustryIdentifierCode);
		validator.Length(x => x.FunctionalIdentifierCode, 2);
		validator.Length(x => x.ApplicationSendersCode, 2, 15);
		validator.Length(x => x.ApplicationReceiversCode, 2, 15);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.GroupControlNumber, 1, 9);
		validator.Length(x => x.ResponsibleAgencyCode, 1, 2);
		validator.Length(x => x.VersionReleaseIndustryIdentifierCode, 1, 12);
		return validator.Results;
	}
}
