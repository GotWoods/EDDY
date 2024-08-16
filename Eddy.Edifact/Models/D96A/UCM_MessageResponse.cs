using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("UCM")]
public class UCM_MessageResponse : EdifactSegment
{
	[Position(1)]
	public string MessageReferenceNumber { get; set; }

	[Position(2)]
	public S009_MessageIdentifier MessageIdentifier { get; set; }

	[Position(3)]
	public string ActionCoded { get; set; }

	[Position(4)]
	public string SyntaxErrorCoded { get; set; }

	[Position(5)]
	public string ServiceSegmentTagCoded { get; set; }

	[Position(6)]
	public S011_DataElementIdentification DataElementIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UCM_MessageResponse>(this);
		validator.Required(x=>x.MessageReferenceNumber);
		validator.Required(x=>x.MessageIdentifier);
		validator.Required(x=>x.ActionCoded);
		validator.Length(x => x.MessageReferenceNumber, 1, 14);
		validator.Length(x => x.ActionCoded, 1, 3);
		validator.Length(x => x.SyntaxErrorCoded, 1, 3);
		validator.Length(x => x.ServiceSegmentTagCoded, 3);
		return validator.Results;
	}
}
