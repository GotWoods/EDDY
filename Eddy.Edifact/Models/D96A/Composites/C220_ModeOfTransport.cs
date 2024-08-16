using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C220")]
public class C220_ModeOfTransport : EdifactComponent
{
	[Position(1)]
	public string ModeOfTransportCoded { get; set; }

	[Position(2)]
	public string ModeOfTransport { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C220_ModeOfTransport>(this);
		validator.Length(x => x.ModeOfTransportCoded, 1, 3);
		validator.Length(x => x.ModeOfTransport, 1, 17);
		return validator.Results;
	}
}
