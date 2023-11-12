using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("LHE")]
public class LHE_EmptyEquipmentHazardousMaterialInformation : EdiX12Segment
{
	[Position(01)]
	public string HazardousMaterialShippingName { get; set; }

	[Position(02)]
	public string HazardousPlacardNotation { get; set; }

	[Position(03)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string ReportableQuantityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LHE_EmptyEquipmentHazardousMaterialInformation>(this);
		validator.Required(x=>x.HazardousMaterialShippingName);
		validator.Required(x=>x.HazardousPlacardNotation);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Length(x => x.HazardousMaterialShippingName, 1, 25);
		validator.Length(x => x.HazardousPlacardNotation, 14, 40);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReportableQuantityCode, 2);
		return validator.Results;
	}
}
