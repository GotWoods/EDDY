using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("GS")]
public class GS_FunctionalGroupHeader : EdiX12Segment
{
	[Position(01)]
	public string FunctionalIdentifierCode { get; set; }

	[Position(02)]
	public string ApplicationSendersCode { get; set; }

	[Position(03)]
	public string ApplicationReceiversCode { get; set; }

	[Position(04)]
	public string GroupDate { get; set; }

	[Position(05)]
	public string GroupTime { get; set; }

	[Position(06)]
	public int? GroupControlNumber { get; set; }

	[Position(07)]
	public string ResponsibleAgencyCode { get; set; }

	[Position(08)]
	public string VersionReleaseIndustryIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GS_FunctionalGroupHeader>(this);
		validator.Required(x=>x.FunctionalIdentifierCode);
		validator.Required(x=>x.ApplicationSendersCode);
		validator.Required(x=>x.ApplicationReceiversCode);
		validator.Required(x=>x.GroupDate);
		validator.Required(x=>x.GroupTime);
		validator.Required(x=>x.GroupControlNumber);
		validator.Required(x=>x.ResponsibleAgencyCode);
		validator.Required(x=>x.VersionReleaseIndustryIdentifierCode);
		validator.Length(x => x.FunctionalIdentifierCode, 2);
		validator.Length(x => x.ApplicationSendersCode, 2, 12);
		validator.Length(x => x.ApplicationReceiversCode, 2, 12);
		validator.Length(x => x.GroupDate, 6);
		validator.Length(x => x.GroupTime, 4);
		validator.Length(x => x.GroupControlNumber, 1, 9);
		validator.Length(x => x.ResponsibleAgencyCode, 1, 2);
		validator.Length(x => x.VersionReleaseIndustryIdentifierCode, 1, 12);
		return validator.Results;
	}
}
