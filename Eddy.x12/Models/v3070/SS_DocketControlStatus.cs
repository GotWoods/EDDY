using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("SS")]
public class SS_DocketControlStatus : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string RateLevel { get; set; }

	[Position(03)]
	public string RateDistributionCode { get; set; }

	[Position(04)]
	public string IndependenceCode { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	[Position(06)]
	public string Date3 { get; set; }

	[Position(07)]
	public int? NumberOfPeriods { get; set; }

	[Position(08)]
	public string Date4 { get; set; }

	[Position(09)]
	public string RateMaintenanceAuthorityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SS_DocketControlStatus>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Date, x=>x.RateLevel);
		validator.Required(x=>x.RateDistributionCode);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.RateLevel, 1, 5);
		validator.Length(x => x.RateDistributionCode, 1);
		validator.Length(x => x.IndependenceCode, 1);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.Date3, 6);
		validator.Length(x => x.NumberOfPeriods, 1, 3);
		validator.Length(x => x.Date4, 6);
		validator.Length(x => x.RateMaintenanceAuthorityCode, 1);
		return validator.Results;
	}
}
