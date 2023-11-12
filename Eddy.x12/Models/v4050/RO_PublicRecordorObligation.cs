using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("RO")]
public class RO_PublicRecordOrObligation : EdiX12Segment
{
	[Position(01)]
	public string PublicRecordOrObligationCode { get; set; }

	[Position(02)]
	public string DispositionStatusCode { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string AmountQualifierCode { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount { get; set; }

	[Position(06)]
	public string RateValueQualifier { get; set; }

	[Position(07)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(08)]
	public string ReferenceIdentification2 { get; set; }

	[Position(09)]
	public string TypeOfAccountCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RO_PublicRecordOrObligation>(this);
		validator.Required(x=>x.PublicRecordOrObligationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.ARequiresB(x=>x.MonetaryAmount, x=>x.RateValueQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification2);
		validator.Length(x => x.PublicRecordOrObligationCode, 2);
		validator.Length(x => x.DispositionStatusCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification2, 1, 50);
		validator.Length(x => x.TypeOfAccountCode, 2);
		return validator.Results;
	}
}
