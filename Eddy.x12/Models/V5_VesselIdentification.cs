using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("V5")]
public class V5_VesselIdentification : EdiX12Segment
{
	[Position(01)]
	public string VesselCodeQualifier { get; set; }

	[Position(02)]
	public string VesselCode { get; set; }

	[Position(03)]
	public string CountryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<V5_VesselIdentification>(this);
		validator.Required(x=>x.VesselCodeQualifier);
		validator.Required(x=>x.VesselCode);
		validator.Required(x=>x.CountryCode);
		validator.Length(x => x.VesselCodeQualifier, 1);
		validator.Length(x => x.VesselCode, 1, 8);
		validator.Length(x => x.CountryCode, 2, 3);
		return validator.Results;
	}
}
