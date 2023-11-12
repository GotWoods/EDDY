using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010.Composites;

namespace Eddy.x12.Models.v4010;

[Segment("PTF")]
public class PTF_PropertyTransactionFinancials : EdiX12Segment
{
	[Position(01)]
	public string AmountQualifierCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string FrequencyCode { get; set; }

	[Position(04)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(05)]
	public string EntityIdentifierCode { get; set; }

	[Position(06)]
	public string TaxTypeCode { get; set; }

	[Position(07)]
	public string TaxExemptCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PTF_PropertyTransactionFinancials>(this);
		validator.Required(x=>x.AmountQualifierCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.TaxTypeCode, 2);
		validator.Length(x => x.TaxExemptCode, 1);
		return validator.Results;
	}
}
