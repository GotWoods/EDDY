using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("M1")]
public class M1_Insurance : EdiX12Segment
{
	[Position(01)]
	public string CountryCode { get; set; }

	[Position(02)]
	public int? CarriageValue { get; set; }

	[Position(03)]
	public string DeclaredValue { get; set; }

	[Position(04)]
	public string RateValueQualifier { get; set; }

	[Position(05)]
	public string EntityIdentifierCode { get; set; }

	[Position(06)]
	public string FreeFormInformation { get; set; }

	[Position(07)]
	public string RateValueQualifier2 { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount { get; set; }

	[Position(09)]
	public string PercentQualifier { get; set; }

	[Position(10)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(11)]
	public string PercentQualifier2 { get; set; }

	[Position(12)]
	public decimal? PercentageAsDecimal2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M1_Insurance>(this);
		validator.Required(x=>x.CountryCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.RateValueQualifier2, x=>x.MonetaryAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PercentQualifier, x=>x.PercentageAsDecimal);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PercentQualifier2, x=>x.PercentageAsDecimal2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.CarriageValue, 2, 8);
		validator.Length(x => x.DeclaredValue, 2, 12);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.FreeFormInformation, 1, 30);
		validator.Length(x => x.RateValueQualifier2, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.PercentQualifier, 1, 2);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.PercentQualifier2, 1, 2);
		validator.Length(x => x.PercentageAsDecimal2, 1, 10);
		return validator.Results;
	}
}
