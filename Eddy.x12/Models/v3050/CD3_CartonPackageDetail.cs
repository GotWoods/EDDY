using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("CD3")]
public class CD3_CartonPackageDetail : EdiX12Segment
{
	[Position(01)]
	public string WeightQualifier { get; set; }

	[Position(02)]
	public decimal? Weight { get; set; }

	[Position(03)]
	public string Zone { get; set; }

	[Position(04)]
	public string ServiceStandard { get; set; }

	[Position(05)]
	public string ServiceLevelCode { get; set; }

	[Position(06)]
	public string PickUpOrDeliveryCode { get; set; }

	[Position(07)]
	public string RateValueQualifier { get; set; }

	[Position(08)]
	public string Charge { get; set; }

	[Position(09)]
	public string RateValueQualifier2 { get; set; }

	[Position(10)]
	public string Charge2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CD3_CartonPackageDetail>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightQualifier, x=>x.Weight);
		validator.IfOneIsFilled_AllAreRequired(x=>x.RateValueQualifier, x=>x.Charge);
		validator.IfOneIsFilled_AllAreRequired(x=>x.RateValueQualifier2, x=>x.Charge2);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.Zone, 2, 3);
		validator.Length(x => x.ServiceStandard, 1, 4);
		validator.Length(x => x.ServiceLevelCode, 2);
		validator.Length(x => x.PickUpOrDeliveryCode, 1, 2);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Charge, 1, 9);
		validator.Length(x => x.RateValueQualifier2, 2);
		validator.Length(x => x.Charge2, 1, 9);
		return validator.Results;
	}
}
