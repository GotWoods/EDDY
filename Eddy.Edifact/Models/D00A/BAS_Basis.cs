using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("BAS")]
public class BAS_Basis : EdifactSegment
{
	[Position(1)]
	public string BasisCodeQualifier { get; set; }

	[Position(2)]
	public C974_BasisType BasisType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BAS_Basis>(this);
		validator.Required(x=>x.BasisCodeQualifier);
		validator.Required(x=>x.BasisType);
		validator.Length(x => x.BasisCodeQualifier, 1, 3);
		return validator.Results;
	}
}
