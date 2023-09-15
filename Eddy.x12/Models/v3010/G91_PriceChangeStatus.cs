using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G91")]
public class G91_PriceChangeStatus : EdiX12Segment
{
	[Position(01)]
	public string ChangeTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G91_PriceChangeStatus>(this);
		validator.Required(x=>x.ChangeTypeCode);
		validator.Length(x => x.ChangeTypeCode, 1);
		return validator.Results;
	}
}
