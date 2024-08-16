using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("USY")]
public class USY_SecurityOnReferences : EdifactSegment
{
	[Position(1)]
	public string SecurityReferenceNumber { get; set; }

	[Position(2)]
	public S508_ValidationResult ValidationResult { get; set; }

	[Position(3)]
	public string SecurityErrorCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USY_SecurityOnReferences>(this);
		validator.Required(x=>x.SecurityReferenceNumber);
		validator.Length(x => x.SecurityReferenceNumber, 1, 14);
		validator.Length(x => x.SecurityErrorCoded, 1, 3);
		return validator.Results;
	}
}
