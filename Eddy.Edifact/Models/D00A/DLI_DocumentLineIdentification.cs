using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("DLI")]
public class DLI_DocumentLineIdentification : EdifactSegment
{
	[Position(1)]
	public string DocumentLineActionCode { get; set; }

	[Position(2)]
	public string LineItemIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DLI_DocumentLineIdentification>(this);
		validator.Required(x=>x.DocumentLineActionCode);
		validator.Required(x=>x.LineItemIdentifier);
		validator.Length(x => x.DocumentLineActionCode, 1, 3);
		validator.Length(x => x.LineItemIdentifier, 1, 6);
		return validator.Results;
	}
}
