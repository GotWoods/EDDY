using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("PTD")]
public class PTD_ProductTransferAndResaleDetail : EdiX12Segment
{
	[Position(01)]
	public string ProductTransferTypeCode { get; set; }

	[Position(02)]
	public string PriceMultiplierQualifier { get; set; }

	[Position(03)]
	public decimal? Multiplier { get; set; }

	[Position(04)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(05)]
	public string ReferenceNumber { get; set; }

	[Position(06)]
	public string ProductTransferMovementTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PTD_ProductTransferAndResaleDetail>(this);
		validator.Required(x=>x.ProductTransferTypeCode);
		validator.Length(x => x.ProductTransferTypeCode, 2);
		validator.Length(x => x.PriceMultiplierQualifier, 3);
		validator.Length(x => x.Multiplier, 1, 10);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ProductTransferMovementTypeCode, 2);
		return validator.Results;
	}
}
