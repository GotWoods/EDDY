using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("TFA")]
public class TFA_TariffAdjustments : EdiX12Segment
{
	[Position(01)]
	public string RateValueQualifier { get; set; }

	[Position(02)]
	public decimal? TariffAdjustmentValueAmount { get; set; }

	[Position(03)]
	public decimal? TariffAdjustmentValueAmount2 { get; set; }

	[Position(04)]
	public decimal? TariffAdjustmentValueAmount3 { get; set; }

	[Position(05)]
	public decimal? TariffAdjustmentValueAmount4 { get; set; }

	[Position(06)]
	public decimal? TariffAdjustmentValueAmount5 { get; set; }

	[Position(07)]
	public decimal? TariffAdjustmentValueAmount6 { get; set; }

	[Position(08)]
	public decimal? TariffAdjustmentValueAmount7 { get; set; }

	[Position(09)]
	public decimal? TariffAdjustmentValueAmount8 { get; set; }

	[Position(10)]
	public decimal? TariffAdjustmentValueAmount9 { get; set; }

	[Position(11)]
	public decimal? TariffAdjustmentValueAmount10 { get; set; }

	[Position(12)]
	public decimal? TariffAdjustmentValueAmount11 { get; set; }

	[Position(13)]
	public decimal? TariffAdjustmentValueAmount12 { get; set; }

	[Position(14)]
	public decimal? TariffAdjustmentValueAmount13 { get; set; }

	[Position(15)]
	public decimal? TariffAdjustmentValueAmount14 { get; set; }

	[Position(16)]
	public decimal? TariffAdjustmentValueAmount15 { get; set; }

	[Position(17)]
	public decimal? TariffAdjustmentValueAmount16 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TFA_TariffAdjustments>(this);
		validator.Required(x=>x.RateValueQualifier);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.TariffAdjustmentValueAmount, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount2, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount3, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount4, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount5, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount6, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount7, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount8, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount9, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount10, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount11, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount12, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount13, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount14, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount15, 1, 9);
		validator.Length(x => x.TariffAdjustmentValueAmount16, 1, 9);
		return validator.Results;
	}
}
