using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4060;

[Segment("RAB")]
public class RAB_RateOrMinimumQualifiers : EdiX12Segment
{
	[Position(01)]
	public string RateValueQualifier { get; set; }

	[Position(02)]
	public int? AssignedNumber { get; set; }

	[Position(03)]
	public string AlternationPrecedenceCode { get; set; }

	[Position(04)]
	public string RateValueQualifier2 { get; set; }

	[Position(05)]
	public string MinimumWeightLogic { get; set; }

	[Position(06)]
	public string LoadingRestriction { get; set; }

	[Position(07)]
	public string LoadingRestriction2 { get; set; }

	[Position(08)]
	public int? PercentIntegerFormat { get; set; }

	[Position(09)]
	public string UnitConversionFactor { get; set; }

	[Position(10)]
	public int? AssignedNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RAB_RateOrMinimumQualifiers>(this);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.MinimumWeightLogic, x=>x.RateValueQualifier2, x=>x.PercentIntegerFormat);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.AlternationPrecedenceCode, 1);
		validator.Length(x => x.RateValueQualifier2, 2);
		validator.Length(x => x.MinimumWeightLogic, 1, 2);
		validator.Length(x => x.LoadingRestriction, 1, 7);
		validator.Length(x => x.LoadingRestriction2, 1, 7);
		validator.Length(x => x.PercentIntegerFormat, 1, 3);
		validator.Length(x => x.UnitConversionFactor, 1, 9);
		validator.Length(x => x.AssignedNumber2, 1, 6);
		return validator.Results;
	}
}
