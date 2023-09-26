using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("SPK")]
public class SPK_SpecimenKitInformation : EdiX12Segment
{
	[Position(01)]
	public string SpecimenKitTypeCode { get; set; }

	[Position(02)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(03)]
	public decimal? Temperature { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SPK_SpecimenKitInformation>(this);
		validator.Required(x=>x.SpecimenKitTypeCode);
		validator.Length(x => x.SpecimenKitTypeCode, 1, 4);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.Temperature, 1, 4);
		return validator.Results;
	}
}
