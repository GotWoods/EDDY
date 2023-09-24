using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4060;

[Segment("H6")]
public class H6_SpecialServices : EdiX12Segment
{
	[Position(01)]
	public string SpecialServicesCode { get; set; }

	[Position(02)]
	public string SpecialServicesCode2 { get; set; }

	[Position(03)]
	public int? QuantityOfPalletsShipped { get; set; }

	[Position(04)]
	public string PalletExchangeCode { get; set; }

	[Position(05)]
	public decimal? Weight { get; set; }

	[Position(06)]
	public string WeightUnitCode { get; set; }

	[Position(07)]
	public string PickupOrDeliveryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<H6_SpecialServices>(this);
		validator.AtLeastOneIsRequired(x=>x.SpecialServicesCode, x=>x.PickupOrDeliveryCode);
		validator.ARequiresB(x=>x.SpecialServicesCode2, x=>x.SpecialServicesCode);
		validator.Length(x => x.SpecialServicesCode, 2, 10);
		validator.Length(x => x.SpecialServicesCode2, 2, 10);
		validator.Length(x => x.QuantityOfPalletsShipped, 1, 3);
		validator.Length(x => x.PalletExchangeCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.PickupOrDeliveryCode, 1, 2);
		return validator.Results;
	}
}
