using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("NX2")]
public class NX2_LocationIDComponent : EdiX12Segment
{
	[Position(01)]
	public string AddressComponentQualifier { get; set; }

	[Position(02)]
	public string AddressInformation { get; set; }

	[Position(03)]
	public string CountyDesignatorCode { get; set; }

	[Position(04)]
	public string AddressComponentQualifier2 { get; set; }

	[Position(05)]
	public string AddressInformation2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NX2_LocationIDComponent>(this);
		validator.Required(x=>x.AddressComponentQualifier);
		validator.Required(x=>x.AddressInformation);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AddressComponentQualifier2, x=>x.AddressInformation2);
		validator.Length(x => x.AddressComponentQualifier, 2);
		validator.Length(x => x.AddressInformation, 1, 55);
		validator.Length(x => x.CountyDesignatorCode, 5);
		validator.Length(x => x.AddressComponentQualifier2, 2);
		validator.Length(x => x.AddressInformation2, 1, 55);
		return validator.Results;
	}
}
