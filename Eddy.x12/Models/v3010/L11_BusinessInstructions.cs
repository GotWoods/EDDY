using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("L11")]
public class L11_BusinessInstructions : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumber { get; set; }

	[Position(02)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(03)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L11_BusinessInstructions>(this);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
