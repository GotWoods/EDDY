using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Models.D06A;

[Segment("LIN")]
public class LIN_LineItem : EdifactSegment
{
	[Position(1)]
	public string LineItemIdentifier { get; set; }

	[Position(2)]
	public string ActionCode { get; set; }

	[Position(3)]
	public C212_ItemNumberIdentification ItemNumberIdentification { get; set; }

	[Position(4)]
	public C829_SubLineInformation SubLineInformation { get; set; }

	[Position(5)]
	public string ConfigurationLevelNumber { get; set; }

	[Position(6)]
	public string ConfigurationOperationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LIN_LineItem>(this);
		validator.Length(x => x.LineItemIdentifier, 1, 6);
		validator.Length(x => x.ActionCode, 1, 3);
		validator.Length(x => x.ConfigurationLevelNumber, 1, 2);
		validator.Length(x => x.ConfigurationOperationCode, 1, 3);
		return validator.Results;
	}
}
