using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D09B.Composites;

[Segment("C289")]
public class C289_TunnelRestriction : EdifactComponent
{
	[Position(1)]
	public string TunnelRestrictionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C289_TunnelRestriction>(this);
		validator.Length(x => x.TunnelRestrictionCode, 1, 6);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
