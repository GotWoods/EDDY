using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("HI")]
public class HI_HealthCareInformationCodes : EdiX12Segment
{
	[Position(01)]
	public C022_HealthCareCodeInformation HealthCareCodeInformation { get; set; }

	[Position(02)]
	public C022_HealthCareCodeInformation HealthCareCodeInformation2 { get; set; }

	[Position(03)]
	public C022_HealthCareCodeInformation HealthCareCodeInformation3 { get; set; }

	[Position(04)]
	public C022_HealthCareCodeInformation HealthCareCodeInformation4 { get; set; }

	[Position(05)]
	public C022_HealthCareCodeInformation HealthCareCodeInformation5 { get; set; }

	[Position(06)]
	public C022_HealthCareCodeInformation HealthCareCodeInformation6 { get; set; }

	[Position(07)]
	public C022_HealthCareCodeInformation HealthCareCodeInformation7 { get; set; }

	[Position(08)]
	public C022_HealthCareCodeInformation HealthCareCodeInformation8 { get; set; }

	[Position(09)]
	public C022_HealthCareCodeInformation HealthCareCodeInformation9 { get; set; }

	[Position(10)]
	public C022_HealthCareCodeInformation HealthCareCodeInformation10 { get; set; }

	[Position(11)]
	public C022_HealthCareCodeInformation HealthCareCodeInformation11 { get; set; }

	[Position(12)]
	public C022_HealthCareCodeInformation HealthCareCodeInformation12 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HI_HealthCareInformationCodes>(this);
		validator.Required(x=>x.HealthCareCodeInformation);
		return validator.Results;
	}
}
