using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("F6X")]
public class F6X_IdentificationAutomotive : EdiX12Segment
{
	[Position(01)]
	public string VehicleIdentificationNumber { get; set; }

	[Position(02)]
	public string AutomotiveManufacturersCode { get; set; }

	[Position(03)]
	public string DealerCode { get; set; }

	[Position(04)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(05)]
	public string IdentificationCode { get; set; }

	[Position(06)]
	public string InvoiceNumber { get; set; }

	[Position(07)]
	public string Date { get; set; }

	[Position(08)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F6X_IdentificationAutomotive>(this);
		validator.Required(x=>x.VehicleIdentificationNumber);
		validator.Required(x=>x.AutomotiveManufacturersCode);
		validator.Required(x=>x.DealerCode);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.Required(x=>x.InvoiceNumber);
		validator.Length(x => x.VehicleIdentificationNumber, 1, 25);
		validator.Length(x => x.AutomotiveManufacturersCode, 2);
		validator.Length(x => x.DealerCode, 2, 9);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		return validator.Results;
	}
}
