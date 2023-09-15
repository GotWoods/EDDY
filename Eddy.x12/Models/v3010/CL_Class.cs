using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("CL")]
public class CL_Class : EdiX12Segment
{
	[Position(01)]
	public string FreightClassCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CL_Class>(this);
		validator.Required(x=>x.FreightClassCode);
		validator.Length(x => x.FreightClassCode, 2, 5);
		return validator.Results;
	}
}
