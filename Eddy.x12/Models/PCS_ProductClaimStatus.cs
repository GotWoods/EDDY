using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("PCS")]
public class PCS_ProductClaimStatus : EdiX12Segment
{
	[Position(01)]
	public string ClaimStatusCode { get; set; }

	[Position(02)]
	public string AgencyQualifierCode { get; set; }

	[Position(03)]
	public string SourceSubqualifier { get; set; }

	[Position(04)]
	public string ClaimResponseReasonCode { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount { get; set; }

	[Position(06)]
	public string FollowUpActionCode { get; set; }

	[Position(07)]
	public string AgencyQualifierCode2 { get; set; }

	[Position(08)]
	public string SourceSubqualifier2 { get; set; }

	[Position(09)]
	public string DispositionCode { get; set; }

	[Position(10)]
	public string Description { get; set; }

	[Position(11)]
	public string AuthorizationIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PCS_ProductClaimStatus>(this);
		validator.AtLeastOneIsRequired(x=>x.ClaimStatusCode, x=>x.ClaimResponseReasonCode);
		validator.ARequiresB(x=>x.AgencyQualifierCode, x=>x.ClaimResponseReasonCode);
		validator.ARequiresB(x=>x.SourceSubqualifier, x=>x.AgencyQualifierCode);
		validator.ARequiresB(x=>x.AgencyQualifierCode2, x=>x.DispositionCode);
		validator.ARequiresB(x=>x.SourceSubqualifier2, x=>x.AgencyQualifierCode2);
		validator.Length(x => x.ClaimStatusCode, 1, 2);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SourceSubqualifier, 1, 15);
		validator.Length(x => x.ClaimResponseReasonCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.FollowUpActionCode, 1);
		validator.Length(x => x.AgencyQualifierCode2, 2);
		validator.Length(x => x.SourceSubqualifier2, 1, 15);
		validator.Length(x => x.DispositionCode, 3);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.AuthorizationIdentification, 1, 4);
		return validator.Results;
	}
}
