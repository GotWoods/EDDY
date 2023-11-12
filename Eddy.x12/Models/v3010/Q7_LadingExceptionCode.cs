using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("Q7")]
public class Q7_LadingExceptionCode : EdiX12Segment
{
	[Position(01)]
	public string LadingExceptionCode { get; set; }

	[Position(02)]
	public string LadingQuantityQualifier { get; set; }

	[Position(03)]
	public int? LadingQuantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Q7_LadingExceptionCode>(this);
		validator.Required(x=>x.LadingExceptionCode);
		validator.Length(x => x.LadingExceptionCode, 1);
		validator.Length(x => x.LadingQuantityQualifier, 3);
		validator.Length(x => x.LadingQuantity, 1, 7);
		return validator.Results;
	}
}
