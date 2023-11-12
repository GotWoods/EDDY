using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("CDS")]
public class CDS_CaseDescription : EdiX12Segment
{
	[Position(01)]
	public string CaseTypeCode { get; set; }

	[Position(02)]
	public string CourtTypeCode { get; set; }

	[Position(03)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(04)]
	public string ReferenceNumber { get; set; }

	[Position(05)]
	public string Description { get; set; }

	[Position(06)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(07)]
	public string IdentificationCode { get; set; }

	[Position(08)]
	public string IdentificationCodeQualifier2 { get; set; }

	[Position(09)]
	public string IdentificationCode2 { get; set; }

	[Position(10)]
	public string IdentificationCodeQualifier3 { get; set; }

	[Position(11)]
	public string IdentificationCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CDS_CaseDescription>(this);
		validator.Required(x=>x.CaseTypeCode);
		validator.Required(x=>x.CourtTypeCode);
		validator.ARequiresB(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier2, x=>x.IdentificationCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier3, x=>x.IdentificationCode3);
		validator.Length(x => x.CaseTypeCode, 1, 2);
		validator.Length(x => x.CourtTypeCode, 1, 2);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.IdentificationCodeQualifier2, 1, 2);
		validator.Length(x => x.IdentificationCode2, 2, 20);
		validator.Length(x => x.IdentificationCodeQualifier3, 1, 2);
		validator.Length(x => x.IdentificationCode3, 2, 20);
		return validator.Results;
	}
}
