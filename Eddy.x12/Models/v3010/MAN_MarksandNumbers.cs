using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("MAN")]
public class MAN_MarksAndNumbers : EdiX12Segment
{
	[Position(01)]
	public string MarksAndNumbersQualifier { get; set; }

	[Position(02)]
	public string MarksAndNumbers { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MAN_MarksAndNumbers>(this);
		validator.Required(x=>x.MarksAndNumbersQualifier);
		validator.Required(x=>x.MarksAndNumbers);
		validator.Length(x => x.MarksAndNumbersQualifier, 1, 2);
		validator.Length(x => x.MarksAndNumbers, 1, 45);
		return validator.Results;
	}
}
