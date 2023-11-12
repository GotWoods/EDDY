using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("LE")]
public class LE_LoopTrailer : EdiX12Segment
{
	[Position(01)]
	public string LoopIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LE_LoopTrailer>(this);
		validator.Required(x=>x.LoopIdentifierCode);
		validator.Length(x => x.LoopIdentifierCode, 1, 4);
		return validator.Results;
	}
}
