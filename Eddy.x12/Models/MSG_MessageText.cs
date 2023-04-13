using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("MSG")]
public class MSG_MessageText : EdiX12Segment
{
	[Position(01)]
	public string FreeFormMessageText { get; set; }

	[Position(02)]
	public string PrinterCarriageControlCode { get; set; }

	[Position(03)]
	public int? Number { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MSG_MessageText>(this);
		validator.Required(x=>x.FreeFormMessageText);
		validator.ARequiresB(x=>x.Number, x=>x.PrinterCarriageControlCode);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.PrinterCarriageControlCode, 2);
		validator.Length(x => x.Number, 1, 9);
		return validator.Results;
	}
}
