using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G91")]
public class G91_PriceChangeStatus : EdiX12Segment
{
	[Position(01)]
	public string ChangeTypeCode { get; set; }

	[Position(02)]
	public string PriceIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G91_PriceChangeStatus>(this);
		validator.Required(x=>x.ChangeTypeCode);
		validator.Length(x => x.ChangeTypeCode, 1);
		validator.Length(x => x.PriceIdentifierCode, 3);
		return validator.Results;
	}
}
