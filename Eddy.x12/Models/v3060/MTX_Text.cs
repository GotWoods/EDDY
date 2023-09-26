using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("MTX")]
public class MTX_Text : EdiX12Segment
{
	[Position(01)]
	public string NoteReferenceCode { get; set; }

	[Position(02)]
	public string MessageText { get; set; }

	[Position(03)]
	public string MessageText2 { get; set; }

	[Position(04)]
	public string PrinterCarriageControlCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MTX_Text>(this);
		validator.ARequiresB(x=>x.NoteReferenceCode, x=>x.MessageText);
		validator.ARequiresB(x=>x.MessageText2, x=>x.MessageText);
		validator.Length(x => x.NoteReferenceCode, 3);
		validator.Length(x => x.MessageText, 1, 4096);
		validator.Length(x => x.MessageText2, 1, 4096);
		validator.Length(x => x.PrinterCarriageControlCode, 2);
		return validator.Results;
	}
}
