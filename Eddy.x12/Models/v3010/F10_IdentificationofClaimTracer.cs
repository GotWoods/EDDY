using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("F10")]
public class F10_IdentificationOfClaimTracer : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string ReferenceNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F10_IdentificationOfClaimTracer>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.ReferenceNumber);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		return validator.Results;
	}
}
