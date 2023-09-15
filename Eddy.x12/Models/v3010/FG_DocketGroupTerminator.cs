using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("FG")]
public class FG_DocketGroupTerminator : EdiX12Segment
{
	[Position(01)]
	public string TerminatorTypeCode { get; set; }

	[Position(02)]
	public int? GroupControlNumber { get; set; }

	[Position(03)]
	public int? NumberOfTransactionSetsIncluded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FG_DocketGroupTerminator>(this);
		validator.Required(x=>x.TerminatorTypeCode);
		validator.Required(x=>x.GroupControlNumber);
		validator.Required(x=>x.NumberOfTransactionSetsIncluded);
		validator.Length(x => x.TerminatorTypeCode, 1);
		validator.Length(x => x.GroupControlNumber, 1, 9);
		validator.Length(x => x.NumberOfTransactionSetsIncluded, 1, 6);
		return validator.Results;
	}
}
