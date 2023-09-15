using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("ETD")]
public class ETD_ExcessTransportationDetail : EdiX12Segment
{
	[Position(01)]
	public string ExcessTransportationReasonCode { get; set; }

	[Position(02)]
	public string ExcessTransportationResponsibilityCode { get; set; }

	[Position(03)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string ReturnableContainerFreightPaymentResponsibilityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ETD_ExcessTransportationDetail>(this);
		validator.Required(x=>x.ExcessTransportationReasonCode);
		validator.Required(x=>x.ExcessTransportationResponsibilityCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.ExcessTransportationReasonCode, 1, 2);
		validator.Length(x => x.ExcessTransportationResponsibilityCode, 1);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ReturnableContainerFreightPaymentResponsibilityCode, 1, 2);
		return validator.Results;
	}
}
