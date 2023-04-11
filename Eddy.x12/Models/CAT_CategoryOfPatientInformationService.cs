using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CAT")]
public class CAT_CategoryOfPatientInformationService : EdiX12Segment
{
	[Position(01)]
	public string ReportTypeCode { get; set; }

	[Position(02)]
	public string ReportTransmissionCode { get; set; }

	[Position(03)]
	public string VersionIdentifier { get; set; }

	[Position(04)]
	public string CodeListQualifierCode { get; set; }

	[Position(05)]
	public string IndustryCode { get; set; }

	[Position(06)]
	public string IndustryCode2 { get; set; }

	[Position(07)]
	public string VersionIdentifier2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CAT_CategoryOfPatientInformationService>(this);
		validator.ARequiresB(x=>x.VersionIdentifier, x=>x.ReportTransmissionCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.ARequiresB(x=>x.IndustryCode2, x=>x.IndustryCode);
		validator.ARequiresB(x=>x.VersionIdentifier2, x=>x.CodeListQualifierCode);
		validator.Length(x => x.ReportTypeCode, 2);
		validator.Length(x => x.ReportTransmissionCode, 1, 2);
		validator.Length(x => x.VersionIdentifier, 1, 30);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.IndustryCode2, 1, 30);
		validator.Length(x => x.VersionIdentifier2, 1, 30);
		return validator.Results;
	}
}
