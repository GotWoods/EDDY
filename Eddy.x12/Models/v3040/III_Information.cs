using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("III")]
public class III_Information : EdiX12Segment
{
	[Position(01)]
	public string CodeListQualifierCode { get; set; }

	[Position(02)]
	public string IndustryCode { get; set; }

	[Position(03)]
	public string CodeCategory { get; set; }

	[Position(04)]
	public string FreeFormMessageText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<III_Information>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeCategory, x=>x.FreeFormMessageText);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 20);
		validator.Length(x => x.CodeCategory, 2);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		return validator.Results;
	}
}
