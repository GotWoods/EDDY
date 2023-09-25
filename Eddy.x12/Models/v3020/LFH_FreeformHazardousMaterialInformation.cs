using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("LFH")]
public class LFH_FreeformHazardousMaterialInformation : EdiX12Segment
{
	[Position(01)]
	public string HazardousMaterialShipmentInformationQualifier { get; set; }

	[Position(02)]
	public string HazardousMaterialShipmentInformation { get; set; }

	[Position(03)]
	public string HazardousMaterialShipmentInformation2 { get; set; }

	[Position(04)]
	public string HazardZoneCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LFH_FreeformHazardousMaterialInformation>(this);
		validator.Required(x=>x.HazardousMaterialShipmentInformationQualifier);
		validator.Required(x=>x.HazardousMaterialShipmentInformation);
		validator.Length(x => x.HazardousMaterialShipmentInformationQualifier, 3);
		validator.Length(x => x.HazardousMaterialShipmentInformation, 1, 25);
		validator.Length(x => x.HazardousMaterialShipmentInformation2, 1, 25);
		validator.Length(x => x.HazardZoneCode, 1);
		return validator.Results;
	}
}
