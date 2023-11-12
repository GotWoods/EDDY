using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("TRN")]
public class TRN_Trace : EdiX12Segment
{
	[Position(01)]
	public string TraceTypeCode { get; set; }

	[Position(02)]
	public string EntityIdentifierCode { get; set; }

	[Position(03)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(04)]
	public string IdentificationCode { get; set; }

	[Position(05)]
	public string ReferenceNumber { get; set; }

	[Position(06)]
	public string ApplicationBatchIdentifier { get; set; }

	[Position(07)]
	public string ApplicationItemIdentifier { get; set; }

	[Position(08)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(09)]
	public string ReferenceNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TRN_Trace>(this);
		validator.Required(x=>x.TraceTypeCode);
		validator.Required(x=>x.EntityIdentifierCode);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.Length(x => x.TraceTypeCode, 1, 2);
		validator.Length(x => x.EntityIdentifierCode, 2);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ApplicationBatchIdentifier, 1, 30);
		validator.Length(x => x.ApplicationItemIdentifier, 1, 30);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		return validator.Results;
	}
}
