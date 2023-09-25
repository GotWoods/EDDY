using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("CRC")]
public class CRC_CertificationConditions : EdiX12Segment
{
	[Position(01)]
	public string CodeCategory { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(03)]
	public string CertificationConditionCode { get; set; }

	[Position(04)]
	public string CertificationConditionCode2 { get; set; }

	[Position(05)]
	public string CertificationConditionCode3 { get; set; }

	[Position(06)]
	public string CertificationConditionCode4 { get; set; }

	[Position(07)]
	public string CertificationConditionCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CRC_CertificationConditions>(this);
		validator.Required(x=>x.CodeCategory);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.CertificationConditionCode);
		validator.Length(x => x.CodeCategory, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.CertificationConditionCode, 2);
		validator.Length(x => x.CertificationConditionCode2, 2);
		validator.Length(x => x.CertificationConditionCode3, 2);
		validator.Length(x => x.CertificationConditionCode4, 2);
		validator.Length(x => x.CertificationConditionCode5, 2);
		return validator.Results;
	}
}
