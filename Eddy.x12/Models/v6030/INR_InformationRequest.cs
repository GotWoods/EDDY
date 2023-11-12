using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("INR")]
public class INR_InformationRequest : EdiX12Segment
{
	[Position(01)]
	public string CodeCategory { get; set; }

	[Position(02)]
	public string InformationTypeCode { get; set; }

	[Position(03)]
	public string InformationStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<INR_InformationRequest>(this);
		validator.Required(x=>x.CodeCategory);
		validator.Required(x=>x.InformationTypeCode);
		validator.Length(x => x.CodeCategory, 2);
		validator.Length(x => x.InformationTypeCode, 2);
		validator.Length(x => x.InformationStatusCode, 1);
		return validator.Results;
	}
}
