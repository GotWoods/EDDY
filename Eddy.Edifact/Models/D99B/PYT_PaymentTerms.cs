using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("PYT")]
public class PYT_PaymentTerms : EdifactSegment
{
	[Position(1)]
	public string PaymentTermsTypeCodeQualifier { get; set; }

	[Position(2)]
	public C019_PaymentTerms PaymentTerms { get; set; }

	[Position(3)]
	public string TimeReferenceCode { get; set; }

	[Position(4)]
	public string TermsTimeRelationCode { get; set; }

	[Position(5)]
	public string PeriodTypeCode { get; set; }

	[Position(6)]
	public string PeriodCountQuantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PYT_PaymentTerms>(this);
		validator.Required(x=>x.PaymentTermsTypeCodeQualifier);
		validator.Length(x => x.PaymentTermsTypeCodeQualifier, 1, 3);
		validator.Length(x => x.TimeReferenceCode, 1, 3);
		validator.Length(x => x.TermsTimeRelationCode, 1, 3);
		validator.Length(x => x.PeriodTypeCode, 1, 3);
		validator.Length(x => x.PeriodCountQuantity, 1, 3);
		return validator.Results;
	}
}
