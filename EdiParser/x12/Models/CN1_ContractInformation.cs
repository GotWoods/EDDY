using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("CN1")]
public class CN1_ContractInformation : EdiX12Segment
{
	[Position(01)]
	public string ContractTypeCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? PercentDecimalFormat { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public decimal? TermsDiscountPercent { get; set; }

	[Position(06)]
	public string VersionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CN1_ContractInformation>(this);
		validator.Required(x=>x.ContractTypeCode);
		validator.Length(x => x.ContractTypeCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.PercentDecimalFormat, 1, 6);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.TermsDiscountPercent, 1, 6);
		validator.Length(x => x.VersionIdentifier, 1, 30);
		return validator.Results;
	}
}
