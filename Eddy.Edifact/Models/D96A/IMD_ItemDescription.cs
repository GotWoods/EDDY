using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("IMD")]
public class IMD_ItemDescription : EdifactSegment
{
	[Position(1)]
	public string ItemDescriptionTypeCoded { get; set; }

	[Position(2)]
	public string ItemCharacteristicCoded { get; set; }

	[Position(3)]
	public C273_ItemDescription ItemDescription { get; set; }

	[Position(4)]
	public string SurfaceLayerIndicatorCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IMD_ItemDescription>(this);
		validator.Length(x => x.ItemDescriptionTypeCoded, 1, 3);
		validator.Length(x => x.ItemCharacteristicCoded, 1, 3);
		validator.Length(x => x.SurfaceLayerIndicatorCoded, 1, 3);
		return validator.Results;
	}
}
