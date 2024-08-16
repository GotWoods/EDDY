using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Models.D01C;

[Segment("PSI")]
public class PSI_ServiceInformation : EdifactSegment
{
	[Position(1)]
	public string ObjectIdentifier { get; set; }

	[Position(2)]
	public E507_DateTimePeriod DateTimePeriod { get; set; }

	[Position(3)]
	public E021_Service Service { get; set; }

	[Position(4)]
	public string Quantity { get; set; }

	[Position(5)]
	public string MonetaryAmount { get; set; }

	[Position(6)]
	public string IndexText { get; set; }

	[Position(7)]
	public string FacilityTypeDescriptionCode { get; set; }

	[Position(8)]
	public string ServiceTypeCode { get; set; }

	[Position(9)]
	public string SpecialConditionCode { get; set; }

	[Position(10)]
	public E024_SupportingEvidence SupportingEvidence { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PSI_ServiceInformation>(this);
		validator.Required(x=>x.ObjectIdentifier);
		validator.Length(x => x.ObjectIdentifier, 1, 35);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.IndexText, 1, 35);
		validator.Length(x => x.FacilityTypeDescriptionCode, 1, 3);
		validator.Length(x => x.ServiceTypeCode, 1, 3);
		validator.Length(x => x.SpecialConditionCode, 1, 3);
		return validator.Results;
	}
}
