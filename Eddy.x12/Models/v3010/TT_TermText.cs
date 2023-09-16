using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("TT")]
public class TT_TermText : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public string FixedFormatInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TT_TermText>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.Required(x=>x.FixedFormatInformation);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.FixedFormatInformation, 1, 80);
		return validator.Results;
	}
}
