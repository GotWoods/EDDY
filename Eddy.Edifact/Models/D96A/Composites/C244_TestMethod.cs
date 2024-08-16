using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C244")]
public class C244_TestMethod : EdifactComponent
{
	[Position(1)]
	public string TestMethodIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string TestDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C244_TestMethod>(this);
		validator.Length(x => x.TestMethodIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.TestDescription, 1, 70);
		return validator.Results;
	}
}