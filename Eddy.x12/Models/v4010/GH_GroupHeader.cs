using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("GH")]
public class GH_GroupHeader : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public int? NumberOfLineItems { get; set; }

	[Position(04)]
	public int? RevisionNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GH_GroupHeader>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.NumberOfLineItems, 1, 6);
		validator.Length(x => x.RevisionNumber, 1, 4);
		return validator.Results;
	}
}
