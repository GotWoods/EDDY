using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("UR")]
public class UR_PeerReviewOrganizationOrUtilizationReview : EdiX12Segment
{
	[Position(01)]
	public string ApprovalCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UR_PeerReviewOrganizationOrUtilizationReview>(this);
		validator.Required(x=>x.ApprovalCode);
		validator.Length(x => x.ApprovalCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
