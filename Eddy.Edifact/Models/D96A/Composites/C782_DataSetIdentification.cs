using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C782")]
public class C782_DataSetIdentification : EdifactComponent
{
	[Position(1)]
	public string DataSetIdentifier { get; set; }

	[Position(2)]
	public string IdentityNumberQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C782_DataSetIdentification>(this);
		validator.Required(x=>x.DataSetIdentifier);
		validator.Length(x => x.DataSetIdentifier, 1, 35);
		validator.Length(x => x.IdentityNumberQualifier, 1, 3);
		return validator.Results;
	}
}