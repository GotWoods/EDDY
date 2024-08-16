using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("DMS")]
public class DMS_DocumentMessageSummary : EdifactSegment
{
	[Position(1)]
	public string DocumentMessageNumber { get; set; }

	[Position(2)]
	public string DocumentMessageNameCoded { get; set; }

	[Position(3)]
	public string TotalNumberOfItems { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DMS_DocumentMessageSummary>(this);
		validator.Length(x => x.DocumentMessageNumber, 1, 35);
		validator.Length(x => x.DocumentMessageNameCoded, 1, 3);
		validator.Length(x => x.TotalNumberOfItems, 1, 15);
		return validator.Results;
	}
}
