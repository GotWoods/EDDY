using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("LHE")]
public class LHE_EmptyEquipmentHazardousMaterialInformation : EdiX12Segment
{
	[Position(01)]
	public string HazardousMaterialShippingName { get; set; }

	[Position(02)]
	public string HazardousPlacardNotation { get; set; }

	[Position(03)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(04)]
	public string ReferenceNumber { get; set; }

	[Position(05)]
	public string ReportableQuantityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LHE_EmptyEquipmentHazardousMaterialInformation>(this);
		validator.Required(x=>x.HazardousMaterialShippingName);
		validator.Required(x=>x.HazardousPlacardNotation);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.Length(x => x.HazardousMaterialShippingName, 1, 50);
		validator.Length(x => x.HazardousPlacardNotation, 16, 40);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReportableQuantityCode, 2);
		return validator.Results;
	}
}
