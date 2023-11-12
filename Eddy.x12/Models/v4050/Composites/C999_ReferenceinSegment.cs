using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050.Composites;

[Segment("C999")]
public class C999_ReferenceInSegment : EdiX12Component
{
	[Position(00)]
	public int? DataElementReferenceNumber { get; set; }

	[Position(01)]
	public int? DataElementReferenceNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C999_ReferenceInSegment>(this);
		validator.Required(x=>x.DataElementReferenceNumber);
		validator.Length(x => x.DataElementReferenceNumber, 1, 4);
		validator.Length(x => x.DataElementReferenceNumber2, 1, 4);
		return validator.Results;
	}
}
