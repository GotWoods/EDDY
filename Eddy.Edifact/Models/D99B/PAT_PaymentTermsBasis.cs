using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("PAT")]
public class PAT_PaymentTermsBasis : EdifactSegment
{
	[Position(1)]
	public string PaymentTermsTypeCodeQualifier { get; set; }

	[Position(2)]
	public C110_PaymentTerms PaymentTerms { get; set; }

	[Position(3)]
	public C112_TermsTimeInformation TermsTimeInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PAT_PaymentTermsBasis>(this);
		validator.Required(x=>x.PaymentTermsTypeCodeQualifier);
		validator.Length(x => x.PaymentTermsTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
