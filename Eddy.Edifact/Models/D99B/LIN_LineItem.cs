using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("LIN")]
public class LIN_LineItem : EdifactSegment
{
	[Position(1)]
	public string LineItemNumber { get; set; }

	[Position(2)]
	public string ActionRequestNotificationDescriptionCode { get; set; }

	[Position(3)]
	public C212_ItemNumberIdentification ItemNumberIdentification { get; set; }

	[Position(4)]
	public C829_SubLineInformation SubLineInformation { get; set; }

	[Position(5)]
	public string ConfigurationLevel { get; set; }

	[Position(6)]
	public string ConfigurationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LIN_LineItem>(this);
		validator.Length(x => x.LineItemNumber, 1, 6);
		validator.Length(x => x.ActionRequestNotificationDescriptionCode, 1, 3);
		validator.Length(x => x.ConfigurationLevel, 1, 2);
		validator.Length(x => x.ConfigurationCoded, 1, 3);
		return validator.Results;
	}
}
