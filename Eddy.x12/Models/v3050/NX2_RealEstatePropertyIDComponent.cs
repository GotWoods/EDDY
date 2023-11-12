using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("NX2")]
public class NX2_RealEstatePropertyIDComponent : EdiX12Segment
{
	[Position(01)]
	public string AddressComponentQualifier { get; set; }

	[Position(02)]
	public string AddressInformation { get; set; }

	[Position(03)]
	public string CountyDesignator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NX2_RealEstatePropertyIDComponent>(this);
		validator.Required(x=>x.AddressComponentQualifier);
		validator.Required(x=>x.AddressInformation);
		validator.Length(x => x.AddressComponentQualifier, 2);
		validator.Length(x => x.AddressInformation, 1, 35);
		validator.Length(x => x.CountyDesignator, 5);
		return validator.Results;
	}
}
