using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C852")]
public class C852_RiskObjectSubType : EdifactComponent
{
	[Position(1)]
	public string RiskObjectSubTypeIdentification { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string RiskObjectSubType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C852_RiskObjectSubType>(this);
		validator.Length(x => x.RiskObjectSubTypeIdentification, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.RiskObjectSubType, 1, 70);
		return validator.Results;
	}
}
