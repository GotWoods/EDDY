using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("DLI")]
public class DLI_DocumentLineIdentification : EdifactSegment
{
	[Position(1)]
	public string DocumentLineIndicatorCoded { get; set; }

	[Position(2)]
	public string LineItemNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DLI_DocumentLineIdentification>(this);
		validator.Required(x=>x.DocumentLineIndicatorCoded);
		validator.Required(x=>x.LineItemNumber);
		validator.Length(x => x.DocumentLineIndicatorCoded, 1, 3);
		validator.Length(x => x.LineItemNumber, 1, 6);
		return validator.Results;
	}
}
