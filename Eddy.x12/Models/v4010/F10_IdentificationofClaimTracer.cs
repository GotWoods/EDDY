using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("F10")]
public class F10_IdentificationOfClaimTracer : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string ReferenceIdentification2 { get; set; }

	[Position(04)]
	public string ReferenceIdentificationQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F10_IdentificationOfClaimTracer>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentification2, x=>x.ReferenceIdentificationQualifier);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		return validator.Results;
	}
}
