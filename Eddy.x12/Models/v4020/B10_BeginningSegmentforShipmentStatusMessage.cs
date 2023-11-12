using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("B10")]
public class B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(04)]
	public int? InquiryRequestNumber { get; set; }

	[Position(05)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(06)]
	public string ReferenceIdentification2 { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(08)]
	public string Date { get; set; }

	[Position(09)]
	public string Time { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage>(this);
		validator.AtLeastOneIsRequired(x=>x.ReferenceIdentification, x=>x.ReferenceIdentification2);
		validator.OnlyOneOf(x=>x.ReferenceIdentification, x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Date, x=>x.Time);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.InquiryRequestNumber, 1, 3);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		return validator.Results;
	}
}
