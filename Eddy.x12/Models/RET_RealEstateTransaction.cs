using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("RET")]
public class RET_RealEstateTransaction : EdiX12Segment
{
	[Position(01)]
	public string InformationStatusCode { get; set; }

	[Position(02)]
	public string TransactionTypeCode { get; set; }

	[Position(03)]
	public string StatusCode { get; set; }

	[Position(04)]
	public string StatusOfPlansForRealEstateAssetCode { get; set; }

	[Position(05)]
	public string ContractTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RET_RealEstateTransaction>(this);
		validator.Length(x => x.InformationStatusCode, 1);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.StatusCode, 2);
		validator.Length(x => x.StatusOfPlansForRealEstateAssetCode, 1);
		validator.Length(x => x.ContractTypeCode, 2);
		return validator.Results;
	}
}
