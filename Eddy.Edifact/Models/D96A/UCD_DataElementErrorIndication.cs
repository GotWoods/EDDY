using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("UCD")]
public class UCD_DataElementErrorIndication : EdifactSegment
{
	[Position(1)]
	public string SyntaxErrorCoded { get; set; }

	[Position(2)]
	public S011_DataElementIdentification DataElementIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UCD_DataElementErrorIndication>(this);
		validator.Required(x=>x.SyntaxErrorCoded);
		validator.Required(x=>x.DataElementIdentification);
		validator.Length(x => x.SyntaxErrorCoded, 1, 3);
		return validator.Results;
	}
}
