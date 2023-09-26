using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("VAT")]
public class VAT_VehicleAttribute : EdiX12Segment
{
	[Position(01)]
	public string IndustryCode { get; set; }

	[Position(02)]
	public string AmountQualifierCode { get; set; }

	[Position(03)]
	public string Amount { get; set; }

	[Position(04)]
	public string CurrencyCode { get; set; }

	[Position(05)]
	public string ProductProcessCharacteristicCode { get; set; }

	[Position(06)]
	public string AgencyQualifierCode { get; set; }

	[Position(07)]
	public string SourceSubqualifier { get; set; }

	[Position(08)]
	public string IndustryCode2 { get; set; }

	[Position(09)]
	public string Description { get; set; }

	[Position(10)]
	public decimal? Quantity { get; set; }

	[Position(11)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<VAT_VehicleAttribute>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountQualifierCode, x=>x.Amount);
		validator.ARequiresB(x=>x.IndustryCode2, x=>x.ProductProcessCharacteristicCode);
		validator.ARequiresB(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.Length(x => x.IndustryCode, 1, 20);
		validator.Length(x => x.AmountQualifierCode, 1, 2);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.ProductProcessCharacteristicCode, 2, 3);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.IndustryCode2, 1, 20);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		return validator.Results;
	}
}
