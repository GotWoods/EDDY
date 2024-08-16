using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("MKS")]
public class MKS_MarketSalesChannelInformation : EdifactSegment
{
	[Position(1)]
	public string SectorSubjectIdentificationQualifier { get; set; }

	[Position(2)]
	public C332_SalesChannelIdentification SalesChannelIdentification { get; set; }

	[Position(3)]
	public string ActionRequestNotificationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MKS_MarketSalesChannelInformation>(this);
		validator.Required(x=>x.SectorSubjectIdentificationQualifier);
		validator.Required(x=>x.SalesChannelIdentification);
		validator.Length(x => x.SectorSubjectIdentificationQualifier, 1, 3);
		validator.Length(x => x.ActionRequestNotificationCoded, 1, 3);
		return validator.Results;
	}
}
