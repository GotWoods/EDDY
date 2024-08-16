using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S016")]
public class S016_MessageSubsetIdentification : EdifactComponent
{
	[Position(1)]
	public string MessageSubsetIdentification { get; set; }

	[Position(2)]
	public string MessageSubsetVersionNumber { get; set; }

	[Position(3)]
	public string MessageSubsetReleaseNumber { get; set; }

	[Position(4)]
	public string ControllingAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S016_MessageSubsetIdentification>(this);
		validator.Required(x=>x.MessageSubsetIdentification);
		validator.Length(x => x.MessageSubsetIdentification, 1, 14);
		validator.Length(x => x.MessageSubsetVersionNumber, 1, 3);
		validator.Length(x => x.MessageSubsetReleaseNumber, 1, 3);
		validator.Length(x => x.ControllingAgencyCoded, 1, 3);
		return validator.Results;
	}
}
