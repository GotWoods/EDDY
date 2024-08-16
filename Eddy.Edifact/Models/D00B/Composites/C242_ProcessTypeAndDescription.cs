using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C242")]
public class C242_ProcessTypeAndDescription : EdifactComponent
{
	[Position(1)]
	public string ProcessTypeDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ProcessTypeDescription { get; set; }

	[Position(5)]
	public string ProcessTypeDescription2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C242_ProcessTypeAndDescription>(this);
		validator.Required(x=>x.ProcessTypeDescriptionCode);
		validator.Length(x => x.ProcessTypeDescriptionCode, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ProcessTypeDescription, 1, 35);
		validator.Length(x => x.ProcessTypeDescription2, 1, 35);
		return validator.Results;
	}
}
