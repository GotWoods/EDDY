using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("MKS")]
public class MKS_MarketSalesChannelInformation : EdifactSegment
{
	[Position(1)]
	public string SectorAreaIdentificationCodeQualifier { get; set; }

	[Position(2)]
	public C332_SalesChannelIdentification SalesChannelIdentification { get; set; }

	[Position(3)]
	public string ActionRequestNotificationDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MKS_MarketSalesChannelInformation>(this);
		validator.Required(x=>x.SectorAreaIdentificationCodeQualifier);
		validator.Required(x=>x.SalesChannelIdentification);
		validator.Length(x => x.SectorAreaIdentificationCodeQualifier, 1, 3);
		validator.Length(x => x.ActionRequestNotificationDescriptionCode, 1, 3);
		return validator.Results;
	}
}
