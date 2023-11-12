using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("Q6")]
public class Q6_ShipmentDetails : EdiX12Segment
{
	[Position(01)]
	public decimal? Weight { get; set; }

	[Position(02)]
	public string WeightUnitCode { get; set; }

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
	public string UnitOfTimePeriodOrInterval { get; set; }

	[Position(10)]
	public string ServiceStandard { get; set; }

	[Position(11)]
	public string ServiceLevelCode { get; set; }

	[Position(12)]
	public string ServiceLevelCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Q6_ShipmentDetails>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOfTimePeriodOrInterval, x=>x.ServiceStandard);
		validator.ARequiresB(x=>x.ServiceLevelCode2, x=>x.ServiceLevelCode);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.LadingQuantity, 1, 7);
		validator.Length(x => x.PackagingFormCode, 3);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		validator.Length(x => x.NetAmountDue, 1, 12);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		validator.Length(x => x.ServiceStandard, 1, 4);
		validator.Length(x => x.ServiceLevelCode, 2);
		validator.Length(x => x.ServiceLevelCode2, 2);
		return validator.Results;
	}
}
