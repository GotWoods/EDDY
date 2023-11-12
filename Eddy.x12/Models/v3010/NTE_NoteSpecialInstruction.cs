using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("NTE")]
public class NTE_NoteSpecialInstruction : EdiX12Segment
{
	[Position(01)]
	public string NoteReferenceCode { get; set; }

	[Position(02)]
	public string FreeFormMessage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NTE_NoteSpecialInstruction>(this);
		validator.Required(x=>x.FreeFormMessage);
		validator.Length(x => x.NoteReferenceCode, 3);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		return validator.Results;
	}
}
