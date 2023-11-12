using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("F06")]
public class F06_IdentificationAutomotive : EdiX12Segment
{
	[Position(01)]
	public string VehicleIdentificationNumber { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string ReferenceNumber2 { get; set; }

	[Position(04)]
	public string ReferenceNumber3 { get; set; }

	[Position(05)]
	public string CarriersDeliveryReceiptNumber { get; set; }

	[Position(06)]
	public string Date { get; set; }

	[Position(07)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F06_IdentificationAutomotive>(this);
		validator.Required(x=>x.VehicleIdentificationNumber);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.ReferenceNumber2);
		validator.Required(x=>x.ReferenceNumber3);
		validator.Required(x=>x.CarriersDeliveryReceiptNumber);
		validator.Required(x=>x.Date);
		validator.Length(x => x.VehicleIdentificationNumber, 17);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.ReferenceNumber3, 1, 30);
		validator.Length(x => x.CarriersDeliveryReceiptNumber, 3, 10);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		return validator.Results;
	}
}
