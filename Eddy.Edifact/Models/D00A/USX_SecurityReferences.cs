using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("USX")]
public class USX_SecurityReferences : EdifactSegment
{
	[Position(1)]
	public string InterchangeControlReference { get; set; }

	[Position(2)]
	public S002_InterchangeSender InterchangeSender { get; set; }

	[Position(3)]
	public S003_InterchangeRecipient InterchangeRecipient { get; set; }

	[Position(4)]
	public string GroupReferenceNumber { get; set; }

	[Position(5)]
	public S006_ApplicationSenderIdentification ApplicationSenderIdentification { get; set; }

	[Position(6)]
	public S007_ApplicationRecipientIdentification ApplicationRecipientIdentification { get; set; }

	[Position(7)]
	public string MessageReferenceNumber { get; set; }

	[Position(8)]
	public S009_MessageIdentifier MessageIdentifier { get; set; }

	[Position(9)]
	public string PackageReferenceNumber { get; set; }

	[Position(10)]
	public S501_SecurityDateAndTime SecurityDateAndTime { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USX_SecurityReferences>(this);
		validator.Required(x=>x.InterchangeControlReference);
		validator.Length(x => x.InterchangeControlReference, 1, 14);
		validator.Length(x => x.GroupReferenceNumber, 1, 14);
		validator.Length(x => x.MessageReferenceNumber, 1, 14);
		validator.Length(x => x.PackageReferenceNumber, 1, 35);
		return validator.Results;
	}
}
