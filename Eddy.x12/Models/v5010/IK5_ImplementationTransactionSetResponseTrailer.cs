using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5010;

[Segment("IK5")]
public class IK5_ImplementationTransactionSetResponseTrailer : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetAcknowledgmentCode { get; set; }

	[Position(02)]
	public string ImplementationTransactionSetSyntaxErrorCode { get; set; }

	[Position(03)]
	public string ImplementationTransactionSetSyntaxErrorCode2 { get; set; }

	[Position(04)]
	public string ImplementationTransactionSetSyntaxErrorCode3 { get; set; }

	[Position(05)]
	public string ImplementationTransactionSetSyntaxErrorCode4 { get; set; }

	[Position(06)]
	public string ImplementationTransactionSetSyntaxErrorCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IK5_ImplementationTransactionSetResponseTrailer>(this);
		validator.Required(x=>x.TransactionSetAcknowledgmentCode);
		validator.Length(x => x.TransactionSetAcknowledgmentCode, 1);
		validator.Length(x => x.ImplementationTransactionSetSyntaxErrorCode, 1, 3);
		validator.Length(x => x.ImplementationTransactionSetSyntaxErrorCode2, 1, 3);
		validator.Length(x => x.ImplementationTransactionSetSyntaxErrorCode3, 1, 3);
		validator.Length(x => x.ImplementationTransactionSetSyntaxErrorCode4, 1, 3);
		validator.Length(x => x.ImplementationTransactionSetSyntaxErrorCode5, 1, 3);
		return validator.Results;
	}
}
