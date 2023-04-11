using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("F14")]
public class F14_LineItemReject : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public string DeclineAmendReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<F14_LineItemReject>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.Required(x=>x.DeclineAmendReasonCode);
		validator.Length(x => x.AssignedNumber, 1, 9);
		validator.Length(x => x.DeclineAmendReasonCode, 3);
		return validator.Results;
	}
}
