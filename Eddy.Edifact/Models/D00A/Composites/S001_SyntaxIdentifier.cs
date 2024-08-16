using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S001")]
public class S001_SyntaxIdentifier : EdifactComponent
{
	[Position(1)]
	public string SyntaxIdentifier { get; set; }

	[Position(2)]
	public string SyntaxVersionNumber { get; set; }

	[Position(3)]
	public string ServiceCodeListDirectoryVersionNumber { get; set; }

	[Position(4)]
	public string CharacterEncodingCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S001_SyntaxIdentifier>(this);
		validator.Required(x=>x.SyntaxIdentifier);
		validator.Required(x=>x.SyntaxVersionNumber);
		validator.Length(x => x.SyntaxIdentifier, 4);
		validator.Length(x => x.SyntaxVersionNumber, 1);
		validator.Length(x => x.ServiceCodeListDirectoryVersionNumber, 1, 6);
		validator.Length(x => x.CharacterEncodingCoded, 1, 3);
		return validator.Results;
	}
}
