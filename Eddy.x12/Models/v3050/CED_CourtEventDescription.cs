using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("CED")]
public class CED_CourtEventDescription : EdiX12Segment
{
	[Position(01)]
	public string CourtEventTypeCode { get; set; }

	[Position(02)]
	public string ActionCode { get; set; }

	[Position(03)]
	public string NoticeTypeCode { get; set; }

	[Position(04)]
	public string CaseTypeCode { get; set; }

	[Position(05)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CED_CourtEventDescription>(this);
		validator.Required(x=>x.CourtEventTypeCode);
		validator.Length(x => x.CourtEventTypeCode, 1, 3);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.NoticeTypeCode, 1, 3);
		validator.Length(x => x.CaseTypeCode, 1, 2);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
