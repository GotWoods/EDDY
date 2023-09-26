using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("ASO")]
public class ASO_AssetOwnership : EdiX12Segment
{
	[Position(01)]
	public string PropertyOwnershipRightsCode { get; set; }

	[Position(02)]
	public string TypeOfPersonalOrBusinessAssetCode { get; set; }

	[Position(03)]
	public string TypeOfPersonalOrBusinessAssetCode2 { get; set; }

	[Position(04)]
	public string FreeFormMessageText { get; set; }

	[Position(05)]
	public string GeneralPropertyOwnershipCode { get; set; }

	[Position(06)]
	public C007_AmountQualifyingDescription AmountQualifyingDescription { get; set; }

	[Position(07)]
	public decimal? MonetaryAmount { get; set; }

	[Position(08)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(09)]
	public decimal? Quantity { get; set; }

	[Position(10)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(11)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ASO_AssetOwnership>(this);
		validator.Required(x=>x.PropertyOwnershipRightsCode);
		validator.Required(x=>x.TypeOfPersonalOrBusinessAssetCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.PropertyOwnershipRightsCode, 1);
		validator.Length(x => x.TypeOfPersonalOrBusinessAssetCode, 2);
		validator.Length(x => x.TypeOfPersonalOrBusinessAssetCode2, 2);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.GeneralPropertyOwnershipCode, 1);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		return validator.Results;
	}
}
