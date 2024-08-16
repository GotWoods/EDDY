using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UNG")]
public class UNG_GroupHeader : EdifactSegment
{
	[Position(1)]
	public string MessageGroupIdentification { get; set; }

	[Position(2)]
	public S006_ApplicationSenderIdentification ApplicationSenderIdentification { get; set; }

	[Position(3)]
	public S007_ApplicationRecipientIdentification ApplicationRecipientIdentification { get; set; }

	[Position(4)]
	public S004_DateAndTimeOfPreparation DateAndTimeOfPreparation { get; set; }

	[Position(5)]
	public string GroupReferenceNumber { get; set; }

	[Position(6)]
	public string ControllingAgencyCoded { get; set; }

	[Position(7)]
	public S008_MessageVersion MessageVersion { get; set; }

	[Position(8)]
	public string ApplicationPassword { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UNG_GroupHeader>(this);
		validator.Required(x=>x.GroupReferenceNumber);
		validator.Length(x => x.MessageGroupIdentification, 1, 6);
		validator.Length(x => x.GroupReferenceNumber, 1, 14);
		validator.Length(x => x.ControllingAgencyCoded, 1, 3);
		validator.Length(x => x.ApplicationPassword, 1, 14);
		return validator.Results;
	}
}
