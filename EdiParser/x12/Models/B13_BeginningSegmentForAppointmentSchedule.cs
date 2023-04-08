using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

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
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		return validator.Results;
	}
}
