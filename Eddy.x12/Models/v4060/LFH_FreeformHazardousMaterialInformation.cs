using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4060;

[Segment("LFH")]
public class LFH_FreeFormHazardousMaterialInformation : EdiX12Segment
{
	[Position(01)]
	public string HazardousMaterialShipmentInformationQualifier { get; set; }

	[Position(02)]
	public string HazardousMaterialShipmentInformation { get; set; }

	[Position(03)]
	public string HazardousMaterialShipmentInformation2 { get; set; }

	[Position(04)]
	public string HazardZoneCode { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(06)]
	public decimal? Quantity { get; set; }

	[Position(07)]
	public decimal? Quantity2 { get; set; }

	[Position(08)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LFH_FreeFormHazardousMaterialInformation>(this);
		validator.Required(x=>x.HazardousMaterialShipmentInformationQualifier);
		validator.Required(x=>x.HazardousMaterialShipmentInformation);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.Length(x => x.HazardousMaterialShipmentInformationQualifier, 3);
		validator.Length(x => x.HazardousMaterialShipmentInformation, 1, 25);
		validator.Length(x => x.HazardousMaterialShipmentInformation2, 1, 25);
		validator.Length(x => x.HazardZoneCode, 1);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Date, 8);
		return validator.Results;
	}
}
