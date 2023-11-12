using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("REA")]
public class REA_RealEstatePropertyInformation : EdiX12Segment
{
	[Position(01)]
	public string TypeOfRealEstateAssetCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string PropertyOwnershipRightsCode { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	[Position(06)]
	public string StatusOfPlansForRealEstateAssetCode { get; set; }

	[Position(07)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(08)]
	public string DateTimePeriod { get; set; }

	[Position(09)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(10)]
	public decimal? Quantity2 { get; set; }

	[Position(11)]
	public string LocationQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<REA_RealEstatePropertyInformation>(this);
		validator.Required(x=>x.TypeOfRealEstateAssetCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.ARequiresB(x=>x.Quantity2, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.TypeOfRealEstateAssetCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.PropertyOwnershipRightsCode, 1);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.StatusOfPlansForRealEstateAssetCode, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.LocationQualifier, 1, 2);
		return validator.Results;
	}
}
