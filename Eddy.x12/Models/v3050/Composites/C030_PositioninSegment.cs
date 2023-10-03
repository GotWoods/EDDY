using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050.Composites;

[Segment("C030")]
public class C030_PositionInSegment : EdiX12Component
{
	[Position(00)]
	public int? ElementPositionInSegment { get; set; }

	[Position(01)]
	public int? ComponentDataElementPositionInComposite { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C030_PositionInSegment>(this);
		validator.Required(x=>x.ElementPositionInSegment);
		validator.Length(x => x.ElementPositionInSegment, 1, 2);
		validator.Length(x => x.ComponentDataElementPositionInComposite, 1, 2);
		return validator.Results;
	}
}
