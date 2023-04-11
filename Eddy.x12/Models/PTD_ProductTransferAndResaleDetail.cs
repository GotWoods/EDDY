using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

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
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public string ProductTransferMovementTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PTD_ProductTransferAndResaleDetail>(this);
		validator.Required(x=>x.ProductTransferTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.PriceMultiplierQualifier, x=>x.Multiplier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.ProductTransferTypeCode, 2);
		validator.Length(x => x.PriceMultiplierQualifier, 3);
		validator.Length(x => x.Multiplier, 1, 10);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ProductTransferMovementTypeCode, 2);
		return validator.Results;
	}
}
