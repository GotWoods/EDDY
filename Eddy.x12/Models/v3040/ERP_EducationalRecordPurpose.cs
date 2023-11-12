using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("ERP")]
public class ERP_EducationalRecordPurpose : EdiX12Segment
{
	[Position(01)]
	public string TransactionTypeCode { get; set; }

	[Position(02)]
	public string StatusReasonCode { get; set; }

	[Position(03)]
	public string ActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ERP_EducationalRecordPurpose>(this);
		validator.Required(x=>x.TransactionTypeCode);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}
