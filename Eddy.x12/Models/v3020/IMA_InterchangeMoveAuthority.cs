using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("IMA")]
public class IMA_InterchangeMoveAuthority : EdiX12Segment
{
	[Position(01)]
	public string MovementAuthorityCode { get; set; }

	[Position(02)]
	public string SpecialHandlingDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IMA_InterchangeMoveAuthority>(this);
		validator.OnlyOneOf(x=>x.MovementAuthorityCode, x=>x.SpecialHandlingDescription);
		validator.Length(x => x.MovementAuthorityCode, 1, 2);
		validator.Length(x => x.SpecialHandlingDescription, 2, 30);
		return validator.Results;
	}
}
