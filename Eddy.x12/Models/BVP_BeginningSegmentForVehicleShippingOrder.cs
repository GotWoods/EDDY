using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("BVP")]
public class BVP_BeginningSegmentForVehicleShippingOrder : EdiX12Segment
{
	[Position(01)]
	public string VehicleProductionStatus { get; set; }

	[Position(02)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(03)]
	public string IdentificationCode { get; set; }

	[Position(04)]
	public string IdentificationCodeQualifier2 { get; set; }

	[Position(05)]
	public string IdentificationCode2 { get; set; }

	[Position(06)]
	public string VehicleServiceCode { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(08)]
	public string VehicleStatus { get; set; }

	[Position(09)]
	public string ReferenceIdentification { get; set; }

	[Position(10)]
	public string Date { get; set; }

	[Position(11)]
	public string TransactionSetPurposeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BVP_BeginningSegmentForVehicleShippingOrder>(this);
		validator.Required(x=>x.VehicleProductionStatus);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier2, x=>x.IdentificationCode2);
		validator.AtLeastOneIsRequired(x=>x.IdentificationCode2, x=>x.VehicleServiceCode);
		validator.Length(x => x.VehicleProductionStatus, 1, 2);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.IdentificationCodeQualifier2, 1, 2);
		validator.Length(x => x.IdentificationCode2, 2, 80);
		validator.Length(x => x.VehicleServiceCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.VehicleStatus, 1, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		return validator.Results;
	}
}
