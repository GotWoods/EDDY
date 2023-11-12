using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("B10")]
public class B10_BeginningSegmentForStatusDiscrepancyAndAppointmentSchedule : EdiX12Segment
{
	[Position(01)]
	public string InvoiceNumber { get; set; }

	[Position(02)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(04)]
	public int? InquiryRequestNumber { get; set; }

	[Position(05)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(06)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B10_BeginningSegmentForStatusDiscrepancyAndAppointmentSchedule>(this);
		validator.AtLeastOneIsRequired(x=>x.InvoiceNumber, x=>x.ReferenceIdentification);
		validator.ARequiresB(x=>x.InvoiceNumber, x=>x.StandardCarrierAlphaCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.InquiryRequestNumber, 1, 3);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		return validator.Results;
	}
}
