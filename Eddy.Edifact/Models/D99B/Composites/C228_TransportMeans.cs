using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C228")]
public class C228_TransportMeans : EdifactComponent
{
	[Position(1)]
	public string TransportMeansDescriptionCode { get; set; }

	[Position(2)]
	public string TransportMeansDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C228_TransportMeans>(this);
		validator.Length(x => x.TransportMeansDescriptionCode, 1, 8);
		validator.Length(x => x.TransportMeansDescription, 1, 17);
		return validator.Results;
	}
}
