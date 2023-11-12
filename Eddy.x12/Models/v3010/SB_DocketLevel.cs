using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("SB")]
public class SB_DocketLevel : EdiX12Segment
{
	[Position(01)]
	public int? Level { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SB_DocketLevel>(this);
		validator.Required(x=>x.Level);
		validator.Length(x => x.Level, 1, 2);
		return validator.Results;
	}
}
