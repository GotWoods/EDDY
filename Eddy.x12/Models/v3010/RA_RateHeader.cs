using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("RA")]
public class RA_RateHeader : EdiX12Segment
{
	[Position(01)]
	public string RouteCode { get; set; }

	[Position(02)]
	public string RateValueQualifier { get; set; }

	[Position(03)]
	public string RateValueQualifier2 { get; set; }

	[Position(04)]
	public string AlternationPrecedenceCode { get; set; }

	[Position(05)]
	public int? NumberOfRates { get; set; }

	[Position(06)]
	public string UnitConversionFactor { get; set; }

	[Position(07)]
	public string RateLevelQualifierCode { get; set; }

	[Position(08)]
	public string RateLevel { get; set; }

	[Position(09)]
	public string Date { get; set; }

	[Position(10)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RA_RateHeader>(this);
		validator.Required(x=>x.RouteCode);
		validator.Required(x=>x.RateValueQualifier);
		validator.Length(x => x.RouteCode, 1, 13);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.RateValueQualifier2, 2);
		validator.Length(x => x.AlternationPrecedenceCode, 1);
		validator.Length(x => x.NumberOfRates, 1);
		validator.Length(x => x.UnitConversionFactor, 1, 9);
		validator.Length(x => x.RateLevelQualifierCode, 1);
		validator.Length(x => x.RateLevel, 1, 5);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		return validator.Results;
	}
}
