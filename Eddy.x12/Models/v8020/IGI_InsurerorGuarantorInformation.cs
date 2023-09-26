using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v8020;

[Segment("IGI")]
public class IGI_InsurerOrGuarantorInformation : EdiX12Segment
{
	[Position(01)]
	public string InsurerGuarantorTypeCode { get; set; }

	[Position(02)]
	public string CodeListQualifierCode { get; set; }

	[Position(03)]
	public string IndustryCode { get; set; }

	[Position(04)]
	public string MortgageInsuranceCoverageTypeCode { get; set; }

	[Position(05)]
	public string InsurerCoverageIndicatorCode { get; set; }

	[Position(06)]
	public string PayerResponsibilitySequenceNumberCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IGI_InsurerOrGuarantorInformation>(this);
		validator.Required(x=>x.InsurerGuarantorTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.Length(x => x.InsurerGuarantorTypeCode, 1);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.MortgageInsuranceCoverageTypeCode, 1);
		validator.Length(x => x.InsurerCoverageIndicatorCode, 1);
		validator.Length(x => x.PayerResponsibilitySequenceNumberCode, 1);
		return validator.Results;
	}
}
