using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("B5")]
public class B5_BeginningSegmentForAcceptanceRejection : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetIdentifierCode { get; set; }

	[Position(02)]
	public int? NumberOfAcceptedTransactionSets { get; set; }

	[Position(03)]
	public int? NumberOfReceivedTransactionSets { get; set; }

	[Position(04)]
	public int? GroupControlNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B5_BeginningSegmentForAcceptanceRejection>(this);
		validator.Required(x=>x.NumberOfAcceptedTransactionSets);
		validator.Required(x=>x.NumberOfReceivedTransactionSets);
		validator.Required(x=>x.GroupControlNumber);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.NumberOfAcceptedTransactionSets, 1, 6);
		validator.Length(x => x.NumberOfReceivedTransactionSets, 1, 6);
		validator.Length(x => x.GroupControlNumber, 1, 9);
		return validator.Results;
	}
}
