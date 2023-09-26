using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("DP")]
public class DP_AutoClaimDetailParts : EdiX12Segment
{
	[Position(01)]
	public string ActionCode { get; set; }

	[Position(02)]
	public string ProductServiceID { get; set; }

	[Position(03)]
	public string Amount { get; set; }

	[Position(04)]
	public string Amount2 { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(06)]
	public string ConditionIndicator { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode4 { get; set; }

	[Position(10)]
	public string YesNoConditionOrResponseCode5 { get; set; }

	[Position(11)]
	public decimal? Quantity { get; set; }

	[Position(12)]
	public string ProductServiceID2 { get; set; }

	[Position(13)]
	public string FreeFormDescription { get; set; }

	[Position(14)]
	public decimal? Percent { get; set; }

	[Position(15)]
	public string AllowanceOrChargeTotalAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DP_AutoClaimDetailParts>(this);
		validator.Required(x=>x.ActionCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Quantity, x=>x.ProductServiceID, x=>x.ProductServiceID2, x=>x.FreeFormDescription);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.ProductServiceID, 1, 40);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.Amount2, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.ConditionIndicator, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode4, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode5, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ProductServiceID2, 1, 40);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.Percent, 1, 6);
		validator.Length(x => x.AllowanceOrChargeTotalAmount, 1, 15);
		return validator.Results;
	}
}
