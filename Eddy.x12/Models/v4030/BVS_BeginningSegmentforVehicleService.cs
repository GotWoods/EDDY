using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("BVS")]
public class BVS_BeginningSegmentForVehicleService : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(03)]
	public string IdentificationCode { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string VehicleServiceCode { get; set; }

	[Position(06)]
	public string VehicleStatus { get; set; }

	[Position(07)]
	public string InvoiceNumber { get; set; }

	[Position(08)]
	public string IdentificationCodeQualifier2 { get; set; }

	[Position(09)]
	public string IdentificationCode2 { get; set; }

	[Position(10)]
	public string BillOfLadingWaybillNumber { get; set; }

	[Position(11)]
	public string AccountNumber { get; set; }

	[Position(12)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BVS_BeginningSegmentForVehicleService>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier2, x=>x.IdentificationCode2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.VehicleServiceCode, 2, 4);
		validator.Length(x => x.VehicleStatus, 1, 2);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.IdentificationCodeQualifier2, 1, 2);
		validator.Length(x => x.IdentificationCode2, 2, 80);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 25);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		return validator.Results;
	}
}
