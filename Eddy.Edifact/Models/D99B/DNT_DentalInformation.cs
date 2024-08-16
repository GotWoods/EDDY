using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("DNT")]
public class DNT_DentalInformation : EdifactSegment
{
	[Position(1)]
	public string ObjectIdentifier { get; set; }

	[Position(2)]
	public string SurfaceLayerCode { get; set; }

	[Position(3)]
	public string CavityZoneCode { get; set; }

	[Position(4)]
	public string Quantity { get; set; }

	[Position(5)]
	public string StatusDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DNT_DentalInformation>(this);
		validator.Length(x => x.ObjectIdentifier, 1, 35);
		validator.Length(x => x.SurfaceLayerCode, 1, 3);
		validator.Length(x => x.CavityZoneCode, 1, 3);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		return validator.Results;
	}
}
