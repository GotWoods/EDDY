using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7060;

[Segment("TXI")]
public class TXI_TaxInformation : EdiX12Segment
{
	[Position(01)]
	public string TaxTypeCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(04)]
	public string TaxJurisdictionCodeQualifier { get; set; }

	[Position(05)]
	public string TaxJurisdictionCode { get; set; }

	[Position(06)]
	public string TaxExemptCode { get; set; }

	[Position(07)]
	public string RelationshipCode { get; set; }

	[Position(08)]
	public decimal? DollarBasisForPercent { get; set; }

	[Position(09)]
	public string TaxIdentificationNumber { get; set; }

	[Position(10)]
	public string AssignedIdentification { get; set; }

	[Position(11)]
	public string Description { get; set; }

	[Position(12)]
	public decimal? Quantity { get; set; }

	[Position(13)]
	public string NameLastOrOrganizationName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TXI_TaxInformation>(this);
		validator.Required(x=>x.TaxTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TaxJurisdictionCodeQualifier, x=>x.TaxJurisdictionCode);
		validator.ARequiresB(x=>x.DollarBasisForPercent, x=>x.PercentageAsDecimal);
		validator.Length(x => x.TaxTypeCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.TaxJurisdictionCodeQualifier, 2);
		validator.Length(x => x.TaxJurisdictionCode, 1, 10);
		validator.Length(x => x.TaxExemptCode, 1);
		validator.Length(x => x.RelationshipCode, 1);
		validator.Length(x => x.DollarBasisForPercent, 1, 9);
		validator.Length(x => x.TaxIdentificationNumber, 1, 20);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.NameLastOrOrganizationName, 1, 80);
		return validator.Results;
	}
}
