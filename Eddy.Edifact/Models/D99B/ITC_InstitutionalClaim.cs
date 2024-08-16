using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("ITC")]
public class ITC_InstitutionalClaim : EdifactSegment
{
	[Position(1)]
	public E027_InvoiceType InvoiceType { get; set; }

	[Position(2)]
	public string Quantity { get; set; }

	[Position(3)]
	public E026_Admission Admission { get; set; }

	[Position(4)]
	public string DischargeTypeDescriptionCode { get; set; }

	[Position(5)]
	public E025_BasisOfServiceInformation BasisOfServiceInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ITC_InstitutionalClaim>(this);
		validator.Required(x=>x.InvoiceType);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.Admission);
		validator.Required(x=>x.DischargeTypeDescriptionCode);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.DischargeTypeDescriptionCode, 1, 3);
		return validator.Results;
	}
}
