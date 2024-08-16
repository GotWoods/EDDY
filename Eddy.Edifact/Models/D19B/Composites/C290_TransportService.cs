using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D19B.Composites;

[Segment("C290")]
public class C290_TransportService : EdifactComponent
{
	[Position(1)]
	public string TransportServiceIdentificationCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string TransportServiceName { get; set; }

	[Position(5)]
	public string TransportServiceDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C290_TransportService>(this);
		validator.Length(x => x.TransportServiceIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.TransportServiceName, 1, 35);
		validator.Length(x => x.TransportServiceDescription, 1, 256);
		return validator.Results;
	}
}
