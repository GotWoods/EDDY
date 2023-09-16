using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("Q6")]
public class Q6_ShipmentDetails : EdiX12Segment
{
	[Position(01)]
	public decimal? Weight { get; set; }

	[Position(02)]
	public string WeightUnitQualifier { get; set; }

	[Position(03)]
	public string WeightQualifier { get; set; }

	[Position(04)]
	public int? LadingQuantity { get; set; }

	[Position(05)]
	public string PackagingFormCode { get; set; }

	[Position(06)]
	public string ShipmentMethodOfPayment { get; set; }

	[Position(07)]
	public string NetAmountDue { get; set; }

	[Position(08)]
	public string CurrencyCode { get; set; }

	[Position(09)]
	public string UnitOfTimePeriodCode { get; set; }

	[Position(10)]
	public string ServiceStandard { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Q6_ShipmentDetails>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOfTimePeriodCode, x=>x.ServiceStandard);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.WeightUnitQualifier, 1);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.LadingQuantity, 1, 7);
		validator.Length(x => x.PackagingFormCode, 3);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		validator.Length(x => x.NetAmountDue, 1, 9);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.UnitOfTimePeriodCode, 2);
		validator.Length(x => x.ServiceStandard, 1, 4);
		return validator.Results;
	}
}
