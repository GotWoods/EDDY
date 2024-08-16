using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C058")]
public class C058_NameAndAddress : EdifactComponent
{
	[Position(1)]
	public string NameAndAddressDescription { get; set; }

	[Position(2)]
	public string NameAndAddressDescription2 { get; set; }

	[Position(3)]
	public string NameAndAddressDescription3 { get; set; }

	[Position(4)]
	public string NameAndAddressDescription4 { get; set; }

	[Position(5)]
	public string NameAndAddressDescription5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C058_NameAndAddress>(this);
		validator.Required(x=>x.NameAndAddressDescription);
		validator.Length(x => x.NameAndAddressDescription, 1, 35);
		validator.Length(x => x.NameAndAddressDescription2, 1, 35);
		validator.Length(x => x.NameAndAddressDescription3, 1, 35);
		validator.Length(x => x.NameAndAddressDescription4, 1, 35);
		validator.Length(x => x.NameAndAddressDescription5, 1, 35);
		return validator.Results;
	}
}
