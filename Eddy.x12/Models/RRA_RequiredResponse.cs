using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("RRA")]
public class RRA_RequiredResponse : EdiX12Segment
{
	[Position(01)]
	public string InformationTypeCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RRA_RequiredResponse>(this);
		validator.Required(x=>x.InformationTypeCode);
		validator.Length(x => x.InformationTypeCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		return validator.Results;
	}
}
