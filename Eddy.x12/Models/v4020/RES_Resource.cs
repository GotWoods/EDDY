using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("RES")]
public class RES_RealEstateSalesPriceChange : EdiX12Segment
{
	[Position(01)]
	public string RealEstateSalesPriceChangeCode { get; set; }

	[Position(02)]
	public string SourceOfFundsCode { get; set; }

	[Position(03)]
	public string TypeOfFundsCode { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public string Description { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(07)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RES_RealEstateSalesPriceChange>(this);
		validator.Required(x=>x.RealEstateSalesPriceChangeCode);
		validator.ARequiresB(x=>x.YesNoConditionOrResponseCode, x=>x.TypeOfFundsCode);
		validator.Length(x => x.RealEstateSalesPriceChangeCode, 1);
		validator.Length(x => x.SourceOfFundsCode, 1);
		validator.Length(x => x.TypeOfFundsCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Date, 8);
		return validator.Results;
	}
}
