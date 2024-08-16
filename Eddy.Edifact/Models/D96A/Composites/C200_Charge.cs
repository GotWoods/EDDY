using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C200")]
public class C200_Charge : EdifactComponent
{
	[Position(1)]
	public string FreightAndChargesIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string FreightAndCharges { get; set; }

	[Position(5)]
	public string PrepaidCollectIndicatorCoded { get; set; }

	[Position(6)]
	public string ItemNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C200_Charge>(this);
		validator.Length(x => x.FreightAndChargesIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.FreightAndCharges, 1, 26);
		validator.Length(x => x.PrepaidCollectIndicatorCoded, 1, 3);
		validator.Length(x => x.ItemNumber, 1, 35);
		return validator.Results;
	}
}
