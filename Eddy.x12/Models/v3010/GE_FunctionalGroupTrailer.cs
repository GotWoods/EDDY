using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("GE")]
public class GE_FunctionalGroupTrailer : EdiX12Segment
{
	[Position(01)]
	public int? NumberOfTransactionSetsIncluded { get; set; }

	[Position(02)]
	public int? GroupControlNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GE_FunctionalGroupTrailer>(this);
		validator.Required(x=>x.NumberOfTransactionSetsIncluded);
		validator.Required(x=>x.GroupControlNumber);
		validator.Length(x => x.NumberOfTransactionSetsIncluded, 1, 6);
		validator.Length(x => x.GroupControlNumber, 1, 9);
		return validator.Results;
	}
}
