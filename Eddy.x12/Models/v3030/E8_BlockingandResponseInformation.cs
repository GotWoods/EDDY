using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("E8")]
public class E8_BlockingAndResponseInformation : EdiX12Segment
{
	[Position(01)]
	public string BlockIdentification { get; set; }

	[Position(02)]
	public string MovementAuthorityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E8_BlockingAndResponseInformation>(this);
		validator.Length(x => x.BlockIdentification, 1, 12);
		validator.Length(x => x.MovementAuthorityCode, 1, 2);
		return validator.Results;
	}
}
