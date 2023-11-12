using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Models.v3060;

[Segment("ATV")]
public class ATV_StudentActivitiesAndAwards : EdiX12Segment
{
	[Position(01)]
	public string CodeListQualifierCode { get; set; }

	[Position(02)]
	public string IndustryCode { get; set; }

	[Position(03)]
	public string EntityTitle { get; set; }

	[Position(04)]
	public string EntityTitle2 { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(07)]
	public string LevelOfIndividualTestOrCourseCode { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(10)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ATV_StudentActivitiesAndAwards>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Quantity, x=>x.CompositeUnitOfMeasure);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.EntityTitle, 1, 132);
		validator.Length(x => x.EntityTitle2, 1, 132);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.LevelOfIndividualTestOrCourseCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		return validator.Results;
	}
}
