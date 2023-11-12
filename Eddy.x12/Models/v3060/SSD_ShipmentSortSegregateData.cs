using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("SSD")]
public class SSD_ShipmentSortSegregateData : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string ReferenceIdentification2 { get; set; }

	[Position(03)]
	public string PurchaseOrderNumber { get; set; }

	[Position(04)]
	public string ApplicationErrorConditionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SSD_ShipmentSortSegregateData>(this);
		validator.ARequiresB(x=>x.ApplicationErrorConditionCode, x=>x.PurchaseOrderNumber);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.ApplicationErrorConditionCode, 1, 3);
		return validator.Results;
	}
}
