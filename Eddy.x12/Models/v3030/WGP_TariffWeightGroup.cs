using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("WGP")]
public class WGP_TariffWeightGroup : EdiX12Segment
{
	[Position(01)]
	public decimal? Weight { get; set; }

	[Position(02)]
	public decimal? Weight2 { get; set; }

	[Position(03)]
	public decimal? Weight3 { get; set; }

	[Position(04)]
	public decimal? Weight4 { get; set; }

	[Position(05)]
	public decimal? Weight5 { get; set; }

	[Position(06)]
	public decimal? Weight6 { get; set; }

	[Position(07)]
	public decimal? Weight7 { get; set; }

	[Position(08)]
	public decimal? Weight8 { get; set; }

	[Position(09)]
	public decimal? Weight9 { get; set; }

	[Position(10)]
	public decimal? Weight10 { get; set; }

	[Position(11)]
	public decimal? Weight11 { get; set; }

	[Position(12)]
	public decimal? Weight12 { get; set; }

	[Position(13)]
	public decimal? Weight13 { get; set; }

	[Position(14)]
	public decimal? Weight14 { get; set; }

	[Position(15)]
	public decimal? Weight15 { get; set; }

	[Position(16)]
	public decimal? Weight16 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<WGP_TariffWeightGroup>(this);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.Weight2, 1, 10);
		validator.Length(x => x.Weight3, 1, 10);
		validator.Length(x => x.Weight4, 1, 10);
		validator.Length(x => x.Weight5, 1, 10);
		validator.Length(x => x.Weight6, 1, 10);
		validator.Length(x => x.Weight7, 1, 10);
		validator.Length(x => x.Weight8, 1, 10);
		validator.Length(x => x.Weight9, 1, 10);
		validator.Length(x => x.Weight10, 1, 10);
		validator.Length(x => x.Weight11, 1, 10);
		validator.Length(x => x.Weight12, 1, 10);
		validator.Length(x => x.Weight13, 1, 10);
		validator.Length(x => x.Weight14, 1, 10);
		validator.Length(x => x.Weight15, 1, 10);
		validator.Length(x => x.Weight16, 1, 10);
		return validator.Results;
	}
}
