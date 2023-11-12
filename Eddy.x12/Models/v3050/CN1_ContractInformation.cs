using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("CN1")]
public class CN1_ContractInformation : EdiX12Segment
{
	[Position(01)]
	public string ContractTypeCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? Percent { get; set; }

	[Position(04)]
	public string ReferenceNumber { get; set; }

	[Position(05)]
	public decimal? TermsDiscountPercent { get; set; }

	[Position(06)]
	public string VersionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CN1_ContractInformation>(this);
		validator.Required(x=>x.ContractTypeCode);
		validator.Length(x => x.ContractTypeCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Percent, 1, 6);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.TermsDiscountPercent, 1, 6);
		validator.Length(x => x.VersionIdentifier, 1, 30);
		return validator.Results;
	}
}
