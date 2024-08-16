using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C049")]
public class C049_RemunerationTypeIdentification : EdifactComponent
{
	[Position(1)]
	public string RemunerationTypeCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string RemunerationType { get; set; }

	[Position(5)]
	public string RemunerationType2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C049_RemunerationTypeIdentification>(this);
		validator.Length(x => x.RemunerationTypeCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.RemunerationType, 1, 35);
		validator.Length(x => x.RemunerationType2, 1, 35);
		return validator.Results;
	}
}