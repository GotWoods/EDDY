using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("MTX")]
public class MTX_Text : EdiX12Segment
{
	[Position(01)]
	public string NoteReferenceCode { get; set; }

	[Position(02)]
	public string TextualData { get; set; }

	[Position(03)]
	public string TextualData2 { get; set; }

	[Position(04)]
	public string PrinterCarriageControlCode { get; set; }

	[Position(05)]
	public int? Number { get; set; }

	[Position(06)]
	public string LanguageCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MTX_Text>(this);
		validator.ARequiresB(x=>x.NoteReferenceCode, x=>x.TextualData);
		validator.ARequiresB(x=>x.TextualData2, x=>x.TextualData);
		validator.ARequiresB(x=>x.Number, x=>x.PrinterCarriageControlCode);
		validator.Length(x => x.NoteReferenceCode, 3);
		validator.Length(x => x.TextualData, 1, 4096);
		validator.Length(x => x.TextualData2, 1, 4096);
		validator.Length(x => x.PrinterCarriageControlCode, 2);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.LanguageCode, 2, 3);
		return validator.Results;
	}
}
