using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("LE")]
public class LE_LoopTrailer : EdiX12Segment
{
	[Position(01)]
	public string LoopIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LE_LoopTrailer>(this);
		validator.Required(x=>x.LoopIdentifierCode);
		validator.Length(x => x.LoopIdentifierCode, 1, 6);
		return validator.Results;
	}
}
