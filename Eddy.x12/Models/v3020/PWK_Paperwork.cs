using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

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
	public string PaperworkReportActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PWK_Paperwork>(this);
		validator.Required(x=>x.ReportTypeCode);
		validator.Required(x=>x.ReportTransmissionCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.ReportTypeCode, 2);
		validator.Length(x => x.ReportTransmissionCode, 2);
		validator.Length(x => x.ReportCopiesNeeded, 1, 2);
		validator.Length(x => x.EntityIdentifierCode, 2);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.PaperworkReportActionCode, 1, 2);
		return validator.Results;
	}
}
