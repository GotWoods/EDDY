using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("IMP")]
public class IMP_ImpairmentDetail : EdiX12Segment
{
	[Position(01)]
	public string PartOfBodyCode { get; set; }

	[Position(02)]
	public decimal? Percent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IMP_ImpairmentDetail>(this);
		validator.Required(x=>x.PartOfBodyCode);
		validator.Length(x => x.PartOfBodyCode, 2);
		validator.Length(x => x.Percent, 1, 10);
		return validator.Results;
	}
}
