using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("BVB")]
public class BVB_BeginningSegmentForVehicleBayingOrder : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(03)]
	public string IdentificationCode { get; set; }

	[Position(04)]
	public string BayTypeCode { get; set; }

	[Position(05)]
	public string CapacityQualifier { get; set; }

	[Position(06)]
	public decimal? Quantity { get; set; }

	[Position(07)]
	public string TransactionSetPurposeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BVB_BeginningSegmentForVehicleBayingOrder>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CapacityQualifier, x=>x.Quantity);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.BayTypeCode, 1);
		validator.Length(x => x.CapacityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		return validator.Results;
	}
}
