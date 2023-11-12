using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("G92")]
public class G92_PurchaseOrderChangeType : EdiX12Segment
{
	[Position(01)]
	public string ChangeOrResponseTypeCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string PurchaseOrderNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G92_PurchaseOrderChangeType>(this);
		validator.Required(x=>x.ChangeOrResponseTypeCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.PurchaseOrderNumber);
		validator.Length(x => x.ChangeOrResponseTypeCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		return validator.Results;
	}
}
