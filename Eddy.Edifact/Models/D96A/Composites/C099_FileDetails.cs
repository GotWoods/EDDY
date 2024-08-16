using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C099")]
public class C099_FileDetails : EdifactComponent
{
	[Position(1)]
	public string FileFormat { get; set; }

	[Position(2)]
	public string Version { get; set; }

	[Position(3)]
	public string DataFormatCoded { get; set; }

	[Position(4)]
	public string DataFormat { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C099_FileDetails>(this);
		validator.Required(x=>x.FileFormat);
		validator.Length(x => x.FileFormat, 1, 17);
		validator.Length(x => x.Version, 1, 9);
		validator.Length(x => x.DataFormatCoded, 1, 3);
		validator.Length(x => x.DataFormat, 1, 35);
		return validator.Results;
	}
}
