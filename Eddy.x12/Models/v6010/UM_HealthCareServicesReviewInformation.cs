using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010;

[Segment("UM")]
public class UM_HealthCareServicesReviewInformation : EdiX12Segment
{
	[Position(01)]
	public string RequestCategoryCode { get; set; }

	[Position(02)]
	public string CertificationTypeCode { get; set; }

	[Position(03)]
	public string IndustryCode { get; set; }

	[Position(04)]
	public C023_HealthCareServiceLocationInformation HealthCareServiceLocationInformation { get; set; }

	[Position(05)]
	public C024_RelatedCausesInformation RelatedCausesInformation { get; set; }

	[Position(06)]
	public string LevelOfServiceCode { get; set; }

	[Position(07)]
	public string CurrentHealthConditionCode { get; set; }

	[Position(08)]
	public string PrognosisCode { get; set; }

	[Position(09)]
	public string ReleaseOfInformationCode { get; set; }

	[Position(10)]
	public string DelayReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UM_HealthCareServicesReviewInformation>(this);
		validator.Required(x=>x.RequestCategoryCode);
		validator.Length(x => x.RequestCategoryCode, 1, 2);
		validator.Length(x => x.CertificationTypeCode, 1);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.LevelOfServiceCode, 1, 3);
		validator.Length(x => x.CurrentHealthConditionCode, 1);
		validator.Length(x => x.PrognosisCode, 1);
		validator.Length(x => x.ReleaseOfInformationCode, 1);
		validator.Length(x => x.DelayReasonCode, 1, 2);
		return validator.Results;
	}
}
