using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("E8")]
public class E8_BlockingAndResponseInformation : EdiX12Segment
{
	[Position(01)]
	public string BlockIdentifier { get; set; }

	[Position(02)]
	public string MovementAuthorityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E8_BlockingAndResponseInformation>(this);
		validator.AtLeastOneIsRequired(x=>x.BlockIdentifier, x=>x.MovementAuthorityCode);
		validator.Length(x => x.BlockIdentifier, 1, 12);
		validator.Length(x => x.MovementAuthorityCode, 1, 2);
		return validator.Results;
	}
}
