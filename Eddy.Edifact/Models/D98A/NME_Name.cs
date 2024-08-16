using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Models.D98A;

[Segment("NME")]
public class NME_Name : EdifactSegment
{
	[Position(1)]
	public E012_NameInformation NameInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NME_Name>(this);
		validator.Required(x=>x.NameInformation);
		return validator.Results;
	}
}
