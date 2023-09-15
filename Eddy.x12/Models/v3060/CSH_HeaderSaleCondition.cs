using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("CSH")]
public class CSH_SalesRequirements : EdiX12Segment
{
	[Position(01)]
	public string SalesRequirementCode { get; set; }

	[Position(02)]
	public string DoNotExceedActionCode { get; set; }

	[Position(03)]
	public string Amount { get; set; }

	[Position(04)]
	public string AccountNumber { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string AgencyQualifierCode { get; set; }

	[Position(07)]
	public string SpecialServicesCode { get; set; }

	[Position(08)]
	public string ProductServiceSubstitutionCode { get; set; }

	[Position(09)]
	public decimal? Percent { get; set; }

	[Position(10)]
	public string PercentQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CSH_SalesRequirements>(this);
		validator.ARequiresB(x=>x.DoNotExceedActionCode, x=>x.Amount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AgencyQualifierCode, x=>x.SpecialServicesCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Percent, x=>x.PercentQualifier);
		validator.Length(x => x.SalesRequirementCode, 1, 2);
		validator.Length(x => x.DoNotExceedActionCode, 1);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SpecialServicesCode, 2, 10);
		validator.Length(x => x.ProductServiceSubstitutionCode, 1, 2);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.PercentQualifier, 1, 2);
		return validator.Results;
	}
}
