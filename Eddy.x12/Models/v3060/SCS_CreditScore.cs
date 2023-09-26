using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("SCS")]
public class SCS_CreditScore : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string FreeFormMessageText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCS_CreditScore>(this);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		return validator.Results;
	}
}
