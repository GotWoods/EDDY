using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("MSG")]
public class MSG_MessageText : EdiX12Segment
{
	[Position(01)]
	public string FreeFormMessageText { get; set; }

	[Position(02)]
	public string PrinterCarriageControlCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MSG_MessageText>(this);
		validator.Required(x=>x.FreeFormMessageText);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.PrinterCarriageControlCode, 2);
		return validator.Results;
	}
}
