using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C090")]
public class C090_AddressDetails : EdifactComponent
{
	[Position(1)]
	public string AddressFormatCode { get; set; }

	[Position(2)]
	public string AddressComponent { get; set; }

	[Position(3)]
	public string AddressComponent2 { get; set; }

	[Position(4)]
	public string AddressComponent3 { get; set; }

	[Position(5)]
	public string AddressComponent4 { get; set; }

	[Position(6)]
	public string AddressComponent5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C090_AddressDetails>(this);
		validator.Required(x=>x.AddressFormatCode);
		validator.Required(x=>x.AddressComponent);
		validator.Length(x => x.AddressFormatCode, 1, 3);
		validator.Length(x => x.AddressComponent, 1, 70);
		validator.Length(x => x.AddressComponent2, 1, 70);
		validator.Length(x => x.AddressComponent3, 1, 70);
		validator.Length(x => x.AddressComponent4, 1, 70);
		validator.Length(x => x.AddressComponent5, 1, 70);
		return validator.Results;
	}
}
