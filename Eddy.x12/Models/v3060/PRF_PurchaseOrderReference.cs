using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("PRF")]
public class PRF_PurchaseOrderReference : EdiX12Segment
{
	[Position(01)]
	public string PurchaseOrderNumber { get; set; }

	[Position(02)]
	public string ReleaseNumber { get; set; }

	[Position(03)]
	public string ChangeOrderSequenceNumber { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string AssignedIdentification { get; set; }

	[Position(06)]
	public string ContractNumber { get; set; }

	[Position(07)]
	public string PurchaseOrderTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRF_PurchaseOrderReference>(this);
		validator.Required(x=>x.PurchaseOrderNumber);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.ReleaseNumber, 1, 30);
		validator.Length(x => x.ChangeOrderSequenceNumber, 1, 8);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.PurchaseOrderTypeCode, 2);
		return validator.Results;
	}
}
