using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

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
	public string FreeFormMessage { get; set; }

	[Position(07)]
	public string RateValueQualifier2 { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount { get; set; }

	[Position(09)]
	public string PercentQualifier { get; set; }

	[Position(10)]
	public decimal? Percent { get; set; }

	[Position(11)]
	public string PercentQualifier2 { get; set; }

	[Position(12)]
	public decimal? Percent2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M1_Insurance>(this);
		validator.Required(x=>x.CountryCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.RateValueQualifier2, x=>x.MonetaryAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PercentQualifier, x=>x.Percent);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PercentQualifier2, x=>x.Percent2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.CarriageValue, 2, 8);
		validator.Length(x => x.DeclaredValue, 2, 10);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.EntityIdentifierCode, 2);
		validator.Length(x => x.FreeFormMessage, 1, 30);
		validator.Length(x => x.RateValueQualifier2, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.PercentQualifier, 1, 2);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.PercentQualifier2, 1, 2);
		validator.Length(x => x.Percent2, 1, 10);
		return validator.Results;
	}
}
