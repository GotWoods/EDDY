using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("PWK")]
public class PWK_Paperwork : EdiX12Segment
{
	[Position(01)]
	public string ReportTypeCode { get; set; }

	[Position(02)]
	public string ReportTransmissionCode { get; set; }

	[Position(03)]
	public int? ReportCopiesNeeded { get; set; }

	[Position(04)]
	public string EntityIdentifierCode { get; set; }

	[Position(05)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(06)]
	public string IdentificationCode { get; set; }

	[Position(07)]
	public string Description { get; set; }

	[Position(08)]
	public C002_ActionsIndicated ActionsIndicated { get; set; }

	[Position(09)]
	public string RequestCategoryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PWK_Paperwork>(this);
		validator.Required(x=>x.ReportTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.ReportTypeCode, 2);
		validator.Length(x => x.ReportTransmissionCode, 1, 2);
		validator.Length(x => x.ReportCopiesNeeded, 1, 2);
		validator.Length(x => x.EntityIdentifierCode, 2);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.RequestCategoryCode, 1, 2);
		return validator.Results;
	}
}
