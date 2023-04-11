using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("EMS")]
public class EMS_EmploymentPosition : EdiX12Segment
{
	[Position(01)]
	public string Description { get; set; }

	[Position(02)]
	public string EmploymentClassCode { get; set; }

	[Position(03)]
	public string OccupationCode { get; set; }

	[Position(04)]
	public string EmploymentStatusCode { get; set; }

	[Position(05)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(06)]
	public string ReferenceIdentification { get; set; }

	[Position(07)]
	public string ReferenceIdentification2 { get; set; }

	[Position(08)]
	public string ReferenceIdentificationQualifier2 { get; set; }

	[Position(09)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(10)]
	public string IdentificationCode { get; set; }

	[Position(11)]
	public decimal? PercentDecimalFormat { get; set; }

	[Position(12)]
	public string EmploymentStatusCode2 { get; set; }

	[Position(13)]
	public string IdentificationCodeQualifier2 { get; set; }

	[Position(14)]
	public string IdentificationCode2 { get; set; }

	[Position(15)]
	public string EmploymentClassCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EMS_EmploymentPosition>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentification2, x=>x.ReferenceIdentificationQualifier2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier2, x=>x.IdentificationCode2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.EmploymentClassCode, 2, 3);
		validator.Length(x => x.OccupationCode, 4, 6);
		validator.Length(x => x.EmploymentStatusCode, 2);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.ReferenceIdentificationQualifier2, 2, 3);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.PercentDecimalFormat, 1, 6);
		validator.Length(x => x.EmploymentStatusCode2, 2);
		validator.Length(x => x.IdentificationCodeQualifier2, 1, 2);
		validator.Length(x => x.IdentificationCode2, 2, 80);
		validator.Length(x => x.EmploymentClassCode2, 2, 3);
		return validator.Results;
	}
}
