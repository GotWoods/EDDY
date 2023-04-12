using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("W1")]
public class W1_BlockIdentification : EdiX12Segment
{
	[Position(01)]
	public string BlockIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W1_BlockIdentification>(this);
		validator.Required(x=>x.BlockIdentifier);
		validator.Length(x => x.BlockIdentifier, 1, 12);
		return validator.Results;
	}
}
