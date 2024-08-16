using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D02B.Composites;

[Segment("C001")]
public class C001_TransportMeans : EdifactComponent
{
	[Position(1)]
	public string TransportMeansDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string TransportMeansDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C001_TransportMeans>(this);
		validator.Length(x => x.TransportMeansDescriptionCode, 1, 8);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.TransportMeansDescription, 1, 17);
		return validator.Results;
	}
}
