using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("DVI")]
public class DVI_DynamicVehicleInformation : EdiX12Segment
{
	[Position(01)]
	public string PriceIdentifierCode { get; set; }

	[Position(02)]
	public decimal? UnitPrice { get; set; }

	[Position(03)]
	public string CurrencyCode { get; set; }

	[Position(04)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(05)]
	public string DateTimePeriod { get; set; }

	[Position(06)]
	public string Name { get; set; }

	[Position(07)]
	public decimal? Quantity { get; set; }

	[Position(08)]
	public string ReferenceIdentification { get; set; }

	[Position(09)]
	public string StateOrProvinceCode { get; set; }

	[Position(10)]
	public string DateTimePeriodFormatQualifier2 { get; set; }

	[Position(11)]
	public string DateTimePeriod2 { get; set; }

	[Position(12)]
	public string LicensePlateType { get; set; }

	[Position(13)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DVI_DynamicVehicleInformation>(this);
		validator.ARequiresB(x=>x.PriceIdentifierCode, x=>x.UnitPrice);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier2, x=>x.DateTimePeriod2);
		validator.Length(x => x.PriceIdentifierCode, 3);
		validator.Length(x => x.UnitPrice, 1, 17);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier2, 2, 3);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.LicensePlateType, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
