using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C521")]
public class C521_BusinessFunction : EdifactComponent
{
	[Position(1)]
	public string BusinessFunctionQualifier { get; set; }

	[Position(2)]
	public string BusinessFunctionCode { get; set; }

	[Position(3)]
	public string CodeListIdentificationCode { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(5)]
	public string BusinessDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C521_BusinessFunction>(this);
		validator.Required(x=>x.BusinessFunctionQualifier);
		validator.Required(x=>x.BusinessFunctionCode);
		validator.Length(x => x.BusinessFunctionQualifier, 1, 3);
		validator.Length(x => x.BusinessFunctionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.BusinessDescription, 1, 70);
		return validator.Results;
	}
}
