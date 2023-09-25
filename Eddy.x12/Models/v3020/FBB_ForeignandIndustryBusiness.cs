using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("FBB")]
public class FBB_ForeignAndIndustryBusiness : EdiX12Segment
{
	[Position(01)]
	public string CountryCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? Percent { get; set; }

	[Position(04)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(05)]
	public string IdentificationCode { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(07)]
	public decimal? Percent2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FBB_ForeignAndIndustryBusiness>(this);
		validator.Required(x=>x.CountryCode);
		validator.AtLeastOneIsRequired(x=>x.MonetaryAmount, x=>x.Percent);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.IdentificationCodeQualifier, x=>x.MonetaryAmount2, x=>x.Percent2);
		validator.Length(x => x.CountryCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.Percent2, 1, 10);
		return validator.Results;
	}
}
