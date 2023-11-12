using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("RRA")]
public class RRA_RequiredResponse : EdiX12Segment
{
	[Position(01)]
	public string InformationType { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RRA_RequiredResponse>(this);
		validator.Required(x=>x.InformationType);
		validator.Length(x => x.InformationType, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
