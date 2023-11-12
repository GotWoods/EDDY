using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("REQ")]
public class REQ_RequestInformation : EdiX12Segment
{
	[Position(01)]
	public string InquiryResponseCode { get; set; }

	[Position(02)]
	public string InquirySelectionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<REQ_RequestInformation>(this);
		validator.Length(x => x.InquiryResponseCode, 1, 2);
		validator.Length(x => x.InquirySelectionCode, 1);
		return validator.Results;
	}
}
