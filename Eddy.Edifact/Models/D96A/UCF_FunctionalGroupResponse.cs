using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("UCF")]
public class UCF_FunctionalGroupResponse : EdifactSegment
{
	[Position(1)]
	public string FunctionalGroupReferenceNumber { get; set; }

	[Position(2)]
	public S006_ApplicationSendersIdentification ApplicationSendersIdentification { get; set; }

	[Position(3)]
	public S007_ApplicationRecipientsIdentification ApplicationRecipientsIdentification { get; set; }

	[Position(4)]
	public string ActionCoded { get; set; }

	[Position(5)]
	public string SyntaxErrorCoded { get; set; }

	[Position(6)]
	public string ServiceSegmentTagCoded { get; set; }

	[Position(7)]
	public S011_DataElementIdentification DataElementIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UCF_FunctionalGroupResponse>(this);
		validator.Required(x=>x.FunctionalGroupReferenceNumber);
		validator.Required(x=>x.ApplicationSendersIdentification);
		validator.Required(x=>x.ApplicationRecipientsIdentification);
		validator.Required(x=>x.ActionCoded);
		validator.Length(x => x.FunctionalGroupReferenceNumber, 1, 14);
		validator.Length(x => x.ActionCoded, 1, 3);
		validator.Length(x => x.SyntaxErrorCoded, 1, 3);
		validator.Length(x => x.ServiceSegmentTagCoded, 3);
		return validator.Results;
	}
}
