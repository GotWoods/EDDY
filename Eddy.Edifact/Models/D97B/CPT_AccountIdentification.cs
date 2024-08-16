using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Models.D97B;

[Segment("CPT")]
public class CPT_AccountIdentification : EdifactSegment
{
	[Position(1)]
	public string AccountTypeQualifier { get; set; }

	[Position(2)]
	public C593_AccountIdentification AccountIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CPT_AccountIdentification>(this);
		validator.Required(x=>x.AccountTypeQualifier);
		validator.Required(x=>x.AccountIdentification);
		validator.Length(x => x.AccountTypeQualifier, 1, 3);
		return validator.Results;
	}
}
