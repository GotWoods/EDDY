using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Models.D01C;

[Segment("HDS")]
public class HDS_HealthDiagnosisServiceAndDelivery : EdifactSegment
{
	[Position(1)]
	public E029_Diagnosis Diagnosis { get; set; }

	[Position(2)]
	public E021_Service Service { get; set; }

	[Position(3)]
	public E083_DeliveryPattern DeliveryPattern { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HDS_HealthDiagnosisServiceAndDelivery>(this);
		return validator.Results;
	}
}
