using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("ISR")]
public class ISR_ItemStatusReport : EdiX12Segment
{
	[Position(01)]
	public string ShipmentOrderStatusCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string StatusReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ISR_ItemStatusReport>(this);
		validator.Required(x=>x.ShipmentOrderStatusCode);
		validator.Length(x => x.ShipmentOrderStatusCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.StatusReasonCode, 3);
		return validator.Results;
	}
}
