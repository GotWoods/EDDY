using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("PIT")]
public class PIT_PriceItemLine : EdifactSegment
{
	[Position(1)]
	public string LineItemNumber { get; set; }

	[Position(2)]
	public string ActionRequestNotificationCoded { get; set; }

	[Position(3)]
	public C292_PriceChangeInformation PriceChangeInformation { get; set; }

	[Position(4)]
	public string ArticleAvailabilityCoded { get; set; }

	[Position(5)]
	public string SubLineIndicatorCoded { get; set; }

	[Position(6)]
	public string ConfigurationLevel { get; set; }

	[Position(7)]
	public string ConfigurationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PIT_PriceItemLine>(this);
		validator.Length(x => x.LineItemNumber, 1, 6);
		validator.Length(x => x.ActionRequestNotificationCoded, 1, 3);
		validator.Length(x => x.ArticleAvailabilityCoded, 1, 3);
		validator.Length(x => x.SubLineIndicatorCoded, 1, 3);
		validator.Length(x => x.ConfigurationLevel, 1, 2);
		validator.Length(x => x.ConfigurationCoded, 1, 3);
		return validator.Results;
	}
}
