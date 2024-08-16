using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Models.D98B;

[Segment("DMS")]
public class DMS_DocumentMessageSummary : EdifactSegment
{
	[Position(1)]
	public C106_DocumentMessageIdentification DocumentMessageIdentification { get; set; }

	[Position(2)]
	public C002_DocumentMessageName DocumentMessageName { get; set; }

	[Position(3)]
	public string TotalNumberOfItems { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DMS_DocumentMessageSummary>(this);
		validator.Length(x => x.TotalNumberOfItems, 1, 15);
		return validator.Results;
	}
}
