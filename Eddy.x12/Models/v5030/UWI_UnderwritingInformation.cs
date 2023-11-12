using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("UWI")]
public class UWI_UnderwritingInformation : EdiX12Segment
{
	[Position(01)]
	public string UnderwritingMethodCode { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public string DispositionStatusCode { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UWI_UnderwritingInformation>(this);
		validator.Required(x=>x.UnderwritingMethodCode);
		validator.Length(x => x.UnderwritingMethodCode, 1);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.DispositionStatusCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		return validator.Results;
	}
}
