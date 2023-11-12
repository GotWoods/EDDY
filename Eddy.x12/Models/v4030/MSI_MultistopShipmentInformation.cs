using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("MSI")]
public class MSI_MultiStopShipmentInformation : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public int? StopSequenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MSI_MultiStopShipmentInformation>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.StopSequenceNumber, 1, 3);
		return validator.Results;
	}
}
