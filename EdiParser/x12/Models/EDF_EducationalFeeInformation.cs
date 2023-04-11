using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("EDF")]
public class EDF_EducationalFeeInformation : EdiX12Segment
{
	[Position(01)]
	public string CodeListQualifierCode { get; set; }

	[Position(02)]
	public string IndustryCode { get; set; }

	[Position(03)]
	public string InstitutionalGovernanceOrFundingSourceLevelCode { get; set; }

	[Position(04)]
	public string CodeListQualifierCode2 { get; set; }

	[Position(05)]
	public string IndustryCode2 { get; set; }

	[Position(06)]
	public string Description { get; set; }

	[Position(07)]
	public string LevelOfIndividualTestOrCourseCode { get; set; }

	[Position(08)]
	public string IdentificationCode { get; set; }

	[Position(09)]
	public decimal? Quantity { get; set; }

	[Position(10)]
	public decimal? Quantity2 { get; set; }

	[Position(11)]
	public decimal? MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EDF_EducationalFeeInformation>(this);
		validator.Required(x=>x.CodeListQualifierCode);
		validator.Required(x=>x.IndustryCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode2, x=>x.IndustryCode2);
		validator.ARequiresB(x=>x.Description, x=>x.CodeListQualifierCode2);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.InstitutionalGovernanceOrFundingSourceLevelCode, 1);
		validator.Length(x => x.CodeListQualifierCode2, 1, 3);
		validator.Length(x => x.IndustryCode2, 1, 30);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.LevelOfIndividualTestOrCourseCode, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		return validator.Results;
	}
}
