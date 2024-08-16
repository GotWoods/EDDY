using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C330")]
public class C330_InsuranceCoverType : EdifactComponent
{
	[Position(1)]
	public string InsuranceCoverTypeCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C330_InsuranceCoverType>(this);
		validator.Required(x=>x.InsuranceCoverTypeCoded);
		validator.Length(x => x.InsuranceCoverTypeCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
