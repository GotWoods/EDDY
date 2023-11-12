using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5040;

[Segment("T2")]
public class T2_TransitInboundLading : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public string LadingDescription { get; set; }

	[Position(03)]
	public decimal? Weight { get; set; }

	[Position(04)]
	public string WeightQualifier { get; set; }

	[Position(05)]
	public decimal? FreightRate { get; set; }

	[Position(06)]
	public string RateValueQualifier { get; set; }

	[Position(07)]
	public decimal? FreightRate2 { get; set; }

	[Position(08)]
	public string RateValueQualifier2 { get; set; }

	[Position(09)]
	public string CityName { get; set; }

	[Position(10)]
	public string CityName2 { get; set; }

	[Position(11)]
	public string ThroughSurchargePercent { get; set; }

	[Position(12)]
	public string PaidInSurchargePercent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<T2_TransitInboundLading>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.FreightRate, x=>x.RateValueQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.FreightRate2, x=>x.RateValueQualifier2);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.LadingDescription, 1, 50);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.FreightRate, 1, 15);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.FreightRate2, 1, 15);
		validator.Length(x => x.RateValueQualifier2, 2);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.CityName2, 2, 30);
		validator.Length(x => x.ThroughSurchargePercent, 2, 4);
		validator.Length(x => x.PaidInSurchargePercent, 2, 4);
		return validator.Results;
	}
}
