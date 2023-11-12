using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("BHT")]
public class BHT_BeginningOfHierarchicalTransaction : EdiX12Segment
{
	[Position(01)]
	public string HierarchicalStructureCode { get; set; }

	[Position(02)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(03)]
	public string ReferenceNumber { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Time { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BHT_BeginningOfHierarchicalTransaction>(this);
		validator.Required(x=>x.HierarchicalStructureCode);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.Date);
		validator.Length(x => x.HierarchicalStructureCode, 4);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 6);
		return validator.Results;
	}
}
