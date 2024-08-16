using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E998")]
public class E998_DiscountInformation : EdifactComponent
{
	[Position(1)]
	public string AdjustmentReasonCoded { get; set; }

	[Position(2)]
	public string Percentage { get; set; }

	[Position(3)]
	public string PartyName { get; set; }

	[Position(4)]
	public string NumberOfUnits { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E998_DiscountInformation>(this);
		validator.Required(x=>x.AdjustmentReasonCoded);
		validator.Length(x => x.AdjustmentReasonCoded, 1, 3);
		validator.Length(x => x.Percentage, 1, 10);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.NumberOfUnits, 1, 15);
		return validator.Results;
	}
}
