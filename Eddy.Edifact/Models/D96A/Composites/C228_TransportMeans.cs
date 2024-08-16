using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C228")]
public class C228_TransportMeans : EdifactComponent
{
	[Position(1)]
	public string TypeOfMeansOfTransportIdentification { get; set; }

	[Position(2)]
	public string TypeOfMeansOfTransport { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C228_TransportMeans>(this);
		validator.Length(x => x.TypeOfMeansOfTransportIdentification, 1, 8);
		validator.Length(x => x.TypeOfMeansOfTransport, 1, 17);
		return validator.Results;
	}
}
