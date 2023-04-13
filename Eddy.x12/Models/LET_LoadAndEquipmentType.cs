using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("LET")]
public class LET_LoadAndEquipmentType : EdiX12Segment
{
	[Position(01)]
	public string SurfaceLayerPositionCode { get; set; }

	[Position(02)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(03)]
	public string ShapeCode { get; set; }

	[Position(04)]
	public string CarTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LET_LoadAndEquipmentType>(this);
		validator.AtLeastOneIsRequired(x=>x.EquipmentDescriptionCode, x=>x.CarTypeCode);
		validator.Length(x => x.SurfaceLayerPositionCode, 2);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.ShapeCode, 1, 2);
		validator.Length(x => x.CarTypeCode, 1, 4);
		return validator.Results;
	}
}
