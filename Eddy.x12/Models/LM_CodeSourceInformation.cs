using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("LM")]
public class LM_CodeSourceInformation : EdiX12Segment
{
	[Position(01)]
	public string AgencyQualifierCode { get; set; }

	[Position(02)]
	public string SourceSubqualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LM_CodeSourceInformation>(this);
		validator.Required(x=>x.AgencyQualifierCode);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		return validator.Results;
	}
}
