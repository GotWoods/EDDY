using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C537")]
public class C537_TransportPriority : EdifactComponent
{
	[Position(1)]
	public string TransportServicePriorityCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C537_TransportPriority>(this);
		validator.Required(x=>x.TransportServicePriorityCode);
		validator.Length(x => x.TransportServicePriorityCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
