using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("ADJ")]
public class ADJ_AdjustmentsToBalancesOrServices : EdiX12Segment
{
	[Position(01)]
	public string AdjustmentApplicationCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	[Position(06)]
	public int? NumberOfDays { get; set; }

	[Position(07)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ADJ_AdjustmentsToBalancesOrServices>(this);
		validator.Required(x=>x.AdjustmentApplicationCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.MonetaryAmount2);
		validator.Length(x => x.AdjustmentApplicationCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.NumberOfDays, 1, 3);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
