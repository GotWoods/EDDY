using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010.Composites;

namespace Eddy.x12.Models.v6010;

[Segment("HLH")]
public class HLH_HealthInformation : EdiX12Segment
{
	[Position(01)]
	public C061_MemberHealthAndTreatmentInformation MemberHealthAndTreatmentInformation { get; set; }

	[Position(02)]
	public decimal? Height { get; set; }

	[Position(03)]
	public decimal? Weight { get; set; }

	[Position(04)]
	public decimal? Weight2 { get; set; }

	[Position(05)]
	public string Description { get; set; }

	[Position(06)]
	public string CurrentHealthConditionCode { get; set; }

	[Position(07)]
	public string Description2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HLH_HealthInformation>(this);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.Weight2, 1, 10);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.CurrentHealthConditionCode, 1);
		validator.Length(x => x.Description2, 1, 80);
		return validator.Results;
	}
}
