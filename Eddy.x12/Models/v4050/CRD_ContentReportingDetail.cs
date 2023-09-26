using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("CRD")]
public class CRD_ContentReportingDetail : EdiX12Segment
{
	[Position(01)]
	public string CountryCode { get; set; }

	[Position(02)]
	public string AmountQualifierCode { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public int? PercentIntegerFormat { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CRD_ContentReportingDetail>(this);
		validator.Required(x=>x.CountryCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.AtLeastOneIsRequired(x=>x.MonetaryAmount, x=>x.PercentIntegerFormat);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.PercentIntegerFormat, 1, 3);
		return validator.Results;
	}
}
