using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("TPL")]
public class TPL_TransportPlacement : EdifactSegment
{
	[Position(1)]
	public C222_TransportIdentification TransportIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TPL_TransportPlacement>(this);
		validator.Required(x=>x.TransportIdentification);
		return validator.Results;
	}
}
