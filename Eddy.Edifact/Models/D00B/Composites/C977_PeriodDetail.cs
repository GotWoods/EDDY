using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C977")]
public class C977_PeriodDetail : EdifactComponent
{
	[Position(1)]
	public string PeriodDetailDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string PeriodDetailDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C977_PeriodDetail>(this);
		validator.Length(x => x.PeriodDetailDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.PeriodDetailDescription, 1, 35);
		return validator.Results;
	}
}
