using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UCF")]
public class UCF_GroupResponse : EdifactSegment
{
	[Position(1)]
	public string GroupReferenceNumber { get; set; }

	[Position(2)]
	public S006_ApplicationSenderIdentification ApplicationSenderIdentification { get; set; }

	[Position(3)]
	public S007_ApplicationRecipientIdentification ApplicationRecipientIdentification { get; set; }

	[Position(4)]
	public string ActionCoded { get; set; }

	[Position(5)]
	public string SyntaxErrorCoded { get; set; }

	[Position(6)]
	public string ServiceSegmentTagCoded { get; set; }

	[Position(7)]
	public S011_DataElementIdentification DataElementIdentification { get; set; }

	[Position(8)]
	public string SecurityReferenceNumber { get; set; }

	[Position(9)]
	public string SecuritySegmentPosition { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UCF_GroupResponse>(this);
		validator.Required(x=>x.GroupReferenceNumber);
		validator.Required(x=>x.ActionCoded);
		validator.Length(x => x.GroupReferenceNumber, 1, 14);
		validator.Length(x => x.ActionCoded, 1, 3);
		validator.Length(x => x.SyntaxErrorCoded, 1, 3);
		validator.Length(x => x.ServiceSegmentTagCoded, 1, 3);
		validator.Length(x => x.SecurityReferenceNumber, 1, 14);
		validator.Length(x => x.SecuritySegmentPosition, 1, 6);
		return validator.Results;
	}
}
