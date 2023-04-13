using Eddy.Core.Attributes;
using Eddy.Core.Validation;

using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("ISI")]
public class ISI_InstitutionalStaffInformation : EdiX12Segment
{
	[Position(01)]
	public string CodeListQualifierCode { get; set; }

	[Position(02)]
	public string IndustryCode { get; set; }

	[Position(03)]
	public string LevelOfIndividualTestOrCourseCode { get; set; }

	[Position(04)]
	public C056_CompositeRaceOrEthnicityInformation CompositeRaceOrEthnicityInformation { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ISI_InstitutionalStaffInformation>(this);
		validator.Required(x=>x.CodeListQualifierCode);
		validator.Required(x=>x.IndustryCode);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.LevelOfIndividualTestOrCourseCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
