using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("PAD")]
public class PAD_ProductAdjustmentDetail : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public string ProductTransferTypeCode { get; set; }

	[Position(03)]
	public string ChangeOrResponseTypeCode { get; set; }

	[Position(04)]
	public string PriceMultiplierQualifier { get; set; }

	[Position(05)]
	public decimal? Multiplier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PAD_ProductAdjustmentDetail>(this);
		validator.Length(x => x.AssignedIdentification, 1, 6);
		validator.Length(x => x.ProductTransferTypeCode, 2);
		validator.Length(x => x.ChangeOrResponseTypeCode, 2);
		validator.Length(x => x.PriceMultiplierQualifier, 3);
		validator.Length(x => x.Multiplier, 1, 10);
		return validator.Results;
	}
}
