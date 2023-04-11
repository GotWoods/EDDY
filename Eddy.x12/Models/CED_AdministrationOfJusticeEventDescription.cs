using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CED")]
public class CED_AdministrationOfJusticeEventDescription : EdiX12Segment
{
	[Position(01)]
	public string AdministrationOfJusticeEventTypeCode { get; set; }

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
		var validator = new BasicValidator<CED_AdministrationOfJusticeEventDescription>(this);
		validator.Required(x=>x.AdministrationOfJusticeEventTypeCode);
		validator.Length(x => x.AdministrationOfJusticeEventTypeCode, 1, 3);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.NoticeTypeCode, 1, 3);
		validator.Length(x => x.CaseTypeCode, 1, 2);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
