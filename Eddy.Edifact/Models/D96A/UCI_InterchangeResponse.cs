using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("UCI")]
public class UCI_InterchangeResponse : EdifactSegment
{
	[Position(1)]
	public string InterchangeControlReference { get; set; }

	[Position(2)]
	public S002_InterchangeSender InterchangeSender { get; set; }

	[Position(3)]
	public S003_InterchangeRecipient InterchangeRecipient { get; set; }

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
		var validator = new BasicValidator<UCI_InterchangeResponse>(this);
		validator.Required(x=>x.InterchangeControlReference);
		validator.Required(x=>x.InterchangeSender);
		validator.Required(x=>x.InterchangeRecipient);
		validator.Required(x=>x.ActionCoded);
		validator.Length(x => x.InterchangeControlReference, 1, 14);
		validator.Length(x => x.ActionCoded, 1, 3);
		validator.Length(x => x.SyntaxErrorCoded, 1, 3);
		validator.Length(x => x.ServiceSegmentTagCoded, 3);
		return validator.Results;
	}
}
