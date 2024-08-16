using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C816")]
public class C816_NameComponentDetails : EdifactComponent
{
	[Position(1)]
	public string NameComponentTypeCodeQualifier { get; set; }

	[Position(2)]
	public string NameComponentDescription { get; set; }

	[Position(3)]
	public string NameComponentUsageCode { get; set; }

	[Position(4)]
	public string NameOriginalAlphabetCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C816_NameComponentDetails>(this);
		validator.Required(x=>x.NameComponentTypeCodeQualifier);
		validator.Length(x => x.NameComponentTypeCodeQualifier, 1, 3);
		validator.Length(x => x.NameComponentDescription, 1, 70);
		validator.Length(x => x.NameComponentUsageCode, 1, 3);
		validator.Length(x => x.NameOriginalAlphabetCode, 1, 3);
		return validator.Results;
	}
}
