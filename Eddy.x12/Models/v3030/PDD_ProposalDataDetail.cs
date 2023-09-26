using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("PDD")]
public class PDD_ProposalDataDetail : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public decimal? Percent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PDD_ProposalDataDetail>(this);
		validator.Required(x=>x.AssignedIdentification);
		validator.Length(x => x.AssignedIdentification, 1, 11);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Percent, 1, 10);
		return validator.Results;
	}
}