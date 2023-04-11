using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("BMG")]
public class BMG_BeginningSegmentForTextMessage : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string TransactionTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BMG_BeginningSegmentForTextMessage>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.TransactionTypeCode, 2);
		return validator.Results;
	}
}
