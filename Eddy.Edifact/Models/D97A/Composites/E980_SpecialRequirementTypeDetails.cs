using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E980")]
public class E980_SpecialRequirementTypeDetails : EdifactComponent
{
	[Position(1)]
	public string SpecialRequirementTypeIdentification { get; set; }

	[Position(2)]
	public string StatusCoded { get; set; }

	[Position(3)]
	public string Quantity { get; set; }

	[Position(4)]
	public string PartyName { get; set; }

	[Position(5)]
	public string ProcessingIndicatorCoded { get; set; }

	[Position(6)]
	public string PlaceLocationIdentification { get; set; }

	[Position(7)]
	public string PlaceLocationIdentification2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E980_SpecialRequirementTypeDetails>(this);
		validator.Required(x=>x.SpecialRequirementTypeIdentification);
		validator.Length(x => x.SpecialRequirementTypeIdentification, 1, 4);
		validator.Length(x => x.StatusCoded, 1, 3);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.ProcessingIndicatorCoded, 1, 3);
		validator.Length(x => x.PlaceLocationIdentification, 1, 25);
		validator.Length(x => x.PlaceLocationIdentification2, 1, 25);
		return validator.Results;
	}
}
