using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E972")]
public class E972_MessageProcessingDetails : EdifactComponent
{
	[Position(1)]
	public string BusinessFunctionCoded { get; set; }

	[Position(2)]
	public string MessageFunctionCoded { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E972_MessageProcessingDetails>(this);
		validator.Length(x => x.BusinessFunctionCoded, 1, 3);
		validator.Length(x => x.MessageFunctionCoded, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
