using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010.Composites;

namespace Eddy.x12.Models.v5010;

[Segment("IK4")]
public class IK4_ImplementationDataElementNote : EdiX12Segment
{
	[Position(01)]
	public C030_PositionInSegment PositionInSegment { get; set; }

	[Position(02)]
	public int? DataElementReferenceNumber { get; set; }

	[Position(03)]
	public string ImplementationDataElementSyntaxErrorCode { get; set; }

	[Position(04)]
	public string CopyOfBadDataElement { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IK4_ImplementationDataElementNote>(this);
		validator.Required(x=>x.PositionInSegment);
		validator.Required(x=>x.ImplementationDataElementSyntaxErrorCode);
		validator.Length(x => x.DataElementReferenceNumber, 1, 4);
		validator.Length(x => x.ImplementationDataElementSyntaxErrorCode, 1, 3);
		validator.Length(x => x.CopyOfBadDataElement, 1, 99);
		return validator.Results;
	}
}
