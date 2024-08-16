using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98B.Composites;

[Segment("C077")]
public class C077_FileIdentification : EdifactComponent
{
	[Position(1)]
	public string FileName { get; set; }

	[Position(2)]
	public string ItemDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C077_FileIdentification>(this);
		validator.Length(x => x.FileName, 1, 35);
		validator.Length(x => x.ItemDescription, 1, 256);
		return validator.Results;
	}
}
