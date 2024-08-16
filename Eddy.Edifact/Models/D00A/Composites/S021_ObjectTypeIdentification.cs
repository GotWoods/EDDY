using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S021")]
public class S021_ObjectTypeIdentification : EdifactComponent
{
	[Position(1)]
	public string ObjectTypeQualifier { get; set; }

	[Position(2)]
	public string ObjectTypeAttributeIdentification { get; set; }

	[Position(3)]
	public string ObjectTypeAttribute { get; set; }

	[Position(4)]
	public string ControllingAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S021_ObjectTypeIdentification>(this);
		validator.Required(x=>x.ObjectTypeQualifier);
		validator.Length(x => x.ObjectTypeQualifier, 1, 3);
		validator.Length(x => x.ObjectTypeAttributeIdentification, 1, 256);
		validator.Length(x => x.ObjectTypeAttribute, 1, 256);
		validator.Length(x => x.ControllingAgencyCoded, 1, 3);
		return validator.Results;
	}
}
