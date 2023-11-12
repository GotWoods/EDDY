using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("L3")]
public class L3_TotalWeightAndCharges : EdiX12Segment
{
	[Position(01)]
	public decimal? Weight { get; set; }

	[Position(02)]
	public string WeightQualifier { get; set; }

	[Position(03)]
	public decimal? FreightRate { get; set; }

	[Position(04)]
	public string RateValueQualifier { get; set; }

	[Position(05)]
	public string Charge { get; set; }

	[Position(06)]
	public string Advances { get; set; }

	[Position(07)]
	public string PrepaidAmount { get; set; }

	[Position(08)]
	public string SpecialChargeCode { get; set; }

	[Position(09)]
	public decimal? Volume { get; set; }

	[Position(10)]
	public string VolumeUnitQualifier { get; set; }

	[Position(11)]
	public int? LadingQuantity { get; set; }

	[Position(12)]
	public string WeightUnitQualifier { get; set; }

	[Position(13)]
	public string TariffNumber { get; set; }

	[Position(14)]
	public string DeclaredValue { get; set; }

	[Position(15)]
	public string RateValueQualifier2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L3_TotalWeightAndCharges>(this);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.FreightRate, 1, 9);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Charge, 1, 9);
		validator.Length(x => x.Advances, 1, 9);
		validator.Length(x => x.PrepaidAmount, 1, 9);
		validator.Length(x => x.SpecialChargeCode, 3);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.LadingQuantity, 1, 7);
		validator.Length(x => x.WeightUnitQualifier, 1);
		validator.Length(x => x.TariffNumber, 1, 7);
		validator.Length(x => x.DeclaredValue, 2, 10);
		validator.Length(x => x.RateValueQualifier2, 2);
		return validator.Results;
	}
}
