using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("PDD")]
public class PDD_PricingDataDetail : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(05)]
	public string ProposalDataDetailIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PDD_PricingDataDetail>(this);
		validator.Required(x=>x.AssignedIdentification);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.ProposalDataDetailIdentifierCode, 1, 3);
		return validator.Results;
	}
}
