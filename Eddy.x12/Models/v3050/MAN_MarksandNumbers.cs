using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("MAN")]
public class MAN_MarksAndNumbers : EdiX12Segment
{
	[Position(01)]
	public string MarksAndNumbersQualifier { get; set; }

	[Position(02)]
	public string MarksAndNumbers { get; set; }

	[Position(03)]
	public string MarksAndNumbers2 { get; set; }

	[Position(04)]
	public string MarksAndNumbersQualifier2 { get; set; }

	[Position(05)]
	public string MarksAndNumbers3 { get; set; }

	[Position(06)]
	public string MarksAndNumbers4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MAN_MarksAndNumbers>(this);
		validator.Required(x=>x.MarksAndNumbersQualifier);
		validator.Required(x=>x.MarksAndNumbers);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MarksAndNumbersQualifier2, x=>x.MarksAndNumbers3);
		validator.ARequiresB(x=>x.MarksAndNumbers4, x=>x.MarksAndNumbers3);
		validator.Length(x => x.MarksAndNumbersQualifier, 1, 2);
		validator.Length(x => x.MarksAndNumbers, 1, 45);
		validator.Length(x => x.MarksAndNumbers2, 1, 45);
		validator.Length(x => x.MarksAndNumbersQualifier2, 1, 2);
		validator.Length(x => x.MarksAndNumbers3, 1, 45);
		validator.Length(x => x.MarksAndNumbers4, 1, 45);
		return validator.Results;
	}
}
