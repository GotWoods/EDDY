using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("W6")]
public class W6_SpecialHandlingInformation : EdiX12Segment
{
	[Position(01)]
	public string SpecialHandlingCode { get; set; }

	[Position(02)]
	public string SpecialHandlingCode2 { get; set; }

	[Position(03)]
	public string SpecialHandlingCode3 { get; set; }

	[Position(04)]
	public string SpecialHandlingCode4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W6_SpecialHandlingInformation>(this);
		validator.Required(x=>x.SpecialHandlingCode);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		validator.Length(x => x.SpecialHandlingCode2, 2, 3);
		validator.Length(x => x.SpecialHandlingCode3, 2, 3);
		validator.Length(x => x.SpecialHandlingCode4, 2, 3);
		return validator.Results;
	}
}
