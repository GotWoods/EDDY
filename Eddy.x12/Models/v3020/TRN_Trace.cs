using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("TRN")]
public class TRN_Trace : EdiX12Segment
{
	[Position(01)]
	public string TraceTypeCode { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string OriginatingCompanyIdentifier { get; set; }

	[Position(04)]
	public string ReferenceNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TRN_Trace>(this);
		validator.Required(x=>x.TraceTypeCode);
		validator.Required(x=>x.ReferenceNumber);
		validator.Length(x => x.TraceTypeCode, 1, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.OriginatingCompanyIdentifier, 10);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		return validator.Results;
	}
}
