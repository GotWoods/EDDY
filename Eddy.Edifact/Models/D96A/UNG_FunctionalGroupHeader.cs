using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("UNG")]
public class UNG_FunctionalGroupHeader : EdifactSegment
{
	[Position(1)]
	public string FunctionalGroupIdentification { get; set; }

	[Position(2)]
	public S006_ApplicationSendersIdentification ApplicationSendersIdentification { get; set; }

	[Position(3)]
	public S007_ApplicationRecipientsIdentification ApplicationRecipientsIdentification { get; set; }

	[Position(4)]
	public S004_DateTimeOfPreparation DateTimeOfPreparation { get; set; }

	[Position(5)]
	public string FunctionalGroupReferenceNumber { get; set; }

	[Position(6)]
	public string ControllingAgency { get; set; }

	[Position(7)]
	public S008_MessageVersion MessageVersion { get; set; }

	[Position(8)]
	public string ApplicationPassword { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UNG_FunctionalGroupHeader>(this);
		validator.Required(x=>x.FunctionalGroupIdentification);
		validator.Required(x=>x.ApplicationSendersIdentification);
		validator.Required(x=>x.ApplicationRecipientsIdentification);
		validator.Required(x=>x.DateTimeOfPreparation);
		validator.Required(x=>x.FunctionalGroupReferenceNumber);
		validator.Required(x=>x.ControllingAgency);
		validator.Required(x=>x.MessageVersion);
		validator.Length(x => x.FunctionalGroupIdentification, 1, 6);
		validator.Length(x => x.FunctionalGroupReferenceNumber, 1, 14);
		validator.Length(x => x.ControllingAgency, 1, 2);
		validator.Length(x => x.ApplicationPassword, 1, 14);
		return validator.Results;
	}
}
