using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("FOS")]
public class FOS_FieldOfStudy : EdiX12Segment
{
	[Position(01)]
	public string AcademicFieldOfStudyLevelOrTypeCode { get; set; }

	[Position(02)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(03)]
	public string IdentificationCode { get; set; }

	[Position(04)]
	public string Description { get; set; }

	[Position(05)]
	public string Description2 { get; set; }

	[Position(06)]
	public decimal? Quantity { get; set; }

	[Position(07)]
	public decimal? Quantity2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FOS_FieldOfStudy>(this);
		validator.Required(x=>x.AcademicFieldOfStudyLevelOrTypeCode);
		validator.AtLeastOneIsRequired(x=>x.IdentificationCodeQualifier, x=>x.Description);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.AcademicFieldOfStudyLevelOrTypeCode, 1);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		return validator.Results;
	}
}
