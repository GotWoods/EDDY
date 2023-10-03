using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010.Composites;

namespace Eddy.x12.Models.v7010;

[Segment("RDM")]
public class RDM_RemittanceDeliveryMethod : EdiX12Segment
{
	[Position(01)]
	public string ReportTransmissionCode { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public string CommunicationNumber { get; set; }

	[Position(04)]
	public C040_ReferenceIdentifier ReferenceIdentifier { get; set; }

	[Position(05)]
	public C040_ReferenceIdentifier ReferenceIdentifier2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RDM_RemittanceDeliveryMethod>(this);
		validator.Required(x=>x.ReportTransmissionCode);
		validator.Length(x => x.ReportTransmissionCode, 1, 2);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.CommunicationNumber, 1, 2048);
		return validator.Results;
	}
}
