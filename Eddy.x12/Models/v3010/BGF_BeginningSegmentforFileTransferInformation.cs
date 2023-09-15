using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("BGF")]
public class BGF_BeginningSegmentForFileTransferInformation : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetIdentifierCode { get; set; }

	[Position(02)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(03)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BGF_BeginningSegmentForFileTransferInformation>(this);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
