using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C200")]
public class C200_Charge : EdifactComponent
{
	[Position(1)]
	public string FreightAndOtherChargesDescriptionIdentifier { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string FreightAndOtherChargesDescription { get; set; }

	[Position(5)]
	public string PaymentArrangementCode { get; set; }

	[Position(6)]
	public string ItemIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C200_Charge>(this);
		validator.Length(x => x.FreightAndOtherChargesDescriptionIdentifier, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.FreightAndOtherChargesDescription, 1, 26);
		validator.Length(x => x.PaymentArrangementCode, 1, 3);
		validator.Length(x => x.ItemIdentifier, 1, 35);
		return validator.Results;
	}
}
