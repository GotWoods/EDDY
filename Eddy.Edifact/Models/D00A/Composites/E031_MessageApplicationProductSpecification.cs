using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E031")]
public class E031_MessageApplicationProductSpecification : EdifactComponent
{
	[Position(1)]
	public string MessageFunctionCode { get; set; }

	[Position(2)]
	public string ProcessDescriptionCode { get; set; }

	[Position(3)]
	public string ProcessDescriptionCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E031_MessageApplicationProductSpecification>(this);
		validator.Length(x => x.MessageFunctionCode, 1, 3);
		validator.Length(x => x.ProcessDescriptionCode, 1, 17);
		validator.Length(x => x.ProcessDescriptionCode2, 1, 17);
		return validator.Results;
	}
}
