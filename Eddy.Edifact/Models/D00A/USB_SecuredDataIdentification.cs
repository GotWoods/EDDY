using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("USB")]
public class USB_SecuredDataIdentification : EdifactSegment
{
	[Position(1)]
	public string ResponseTypeCoded { get; set; }

	[Position(2)]
	public S501_SecurityDateAndTime SecurityDateAndTime { get; set; }

	[Position(3)]
	public S002_InterchangeSender InterchangeSender { get; set; }

	[Position(4)]
	public S003_InterchangeRecipient InterchangeRecipient { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USB_SecuredDataIdentification>(this);
		validator.Required(x=>x.ResponseTypeCoded);
		validator.Required(x=>x.InterchangeSender);
		validator.Required(x=>x.InterchangeRecipient);
		validator.Length(x => x.ResponseTypeCoded, 1, 3);
		return validator.Results;
	}
}
