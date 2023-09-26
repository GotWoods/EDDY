using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("ATA")]
public class ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ATA_BeginningSegmentForMotorCarrierDeliveryTrailerManifest>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.Date, 8);
		return validator.Results;
	}
}
