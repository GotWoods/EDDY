using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("IMD")]
public class IMD_ItemDescription : EdifactSegment
{
	[Position(1)]
	public string DescriptionFormatCode { get; set; }

	[Position(2)]
	public C272_ItemCharacteristic ItemCharacteristic { get; set; }

	[Position(3)]
	public C273_ItemDescription ItemDescription { get; set; }

	[Position(4)]
	public string SurfaceOrLayerCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IMD_ItemDescription>(this);
		validator.Length(x => x.DescriptionFormatCode, 1, 3);
		validator.Length(x => x.SurfaceOrLayerCode, 1, 3);
		return validator.Results;
	}
}
