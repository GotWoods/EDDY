using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("INR")]
public class INR_InformationRequest : EdiX12Segment
{
	[Position(01)]
	public string CodeCategory { get; set; }

	[Position(02)]
	public string InformationType { get; set; }

	[Position(03)]
	public string InformationStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<INR_InformationRequest>(this);
		validator.Required(x=>x.CodeCategory);
		validator.Required(x=>x.InformationType);
		validator.Length(x => x.CodeCategory, 2);
		validator.Length(x => x.InformationType, 2);
		validator.Length(x => x.InformationStatusCode, 1);
		return validator.Results;
	}
}
