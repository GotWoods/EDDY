using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("SB")]
public class SB_DocketLevel : EdiX12Segment
{
	[Position(01)]
	public int? DocketLevelNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SB_DocketLevel>(this);
		validator.Required(x=>x.DocketLevelNumber);
		validator.Length(x => x.DocketLevelNumber, 1, 2);
		return validator.Results;
	}
}
