using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("B2A")]
public class B2A_SetPurpose : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ApplicationTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B2A_SetPurpose>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ApplicationTypeCode, 2);
		return validator.Results;
	}
}
