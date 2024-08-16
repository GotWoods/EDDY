using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E001")]
public class E001_AddressDetails : EdifactComponent
{
	[Position(1)]
	public string AddressFormatCode { get; set; }

	[Position(2)]
	public string AddressComponentDescription { get; set; }

	[Position(3)]
	public string AddressComponentDescription2 { get; set; }

	[Position(4)]
	public string AddressComponentDescription3 { get; set; }

	[Position(5)]
	public string AddressComponentDescription4 { get; set; }

	[Position(6)]
	public string AddressComponentDescription5 { get; set; }

	[Position(7)]
	public string AddressComponentDescription6 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E001_AddressDetails>(this);
		validator.Required(x=>x.AddressFormatCode);
		validator.Required(x=>x.AddressComponentDescription);
		validator.Length(x => x.AddressFormatCode, 1, 3);
		validator.Length(x => x.AddressComponentDescription, 1, 70);
		validator.Length(x => x.AddressComponentDescription2, 1, 70);
		validator.Length(x => x.AddressComponentDescription3, 1, 70);
		validator.Length(x => x.AddressComponentDescription4, 1, 70);
		validator.Length(x => x.AddressComponentDescription5, 1, 70);
		validator.Length(x => x.AddressComponentDescription6, 1, 70);
		return validator.Results;
	}
}
