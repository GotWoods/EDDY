using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("TRN")]
public class TRN_Trace : EdiX12Segment
{
	[Position(01)]
	public string TraceTypeCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string OriginatingCompanyIdentifier { get; set; }

	[Position(04)]
	public string ReferenceIdentification2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TRN_Trace>(this);
		validator.Required(x=>x.TraceTypeCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Length(x => x.TraceTypeCode, 1, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.OriginatingCompanyIdentifier, 10);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		return validator.Results;
	}
}
