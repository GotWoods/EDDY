using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("B13")]
public class B13_BeginningSegmentForAppointmentSchedule : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B13_BeginningSegmentForAppointmentSchedule>(this);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		return validator.Results;
	}
}
