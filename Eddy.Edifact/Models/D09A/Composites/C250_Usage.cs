using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D09A.Composites;

[Segment("C250")]
public class C250_Usage : EdifactComponent
{
	[Position(1)]
	public string UsageDescriptionCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string UsageDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C250_Usage>(this);
		validator.Length(x => x.UsageDescriptionCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.UsageDescription, 1, 256);
		return validator.Results;
	}
}
