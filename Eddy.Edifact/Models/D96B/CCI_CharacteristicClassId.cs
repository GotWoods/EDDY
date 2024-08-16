using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Models.D96B;

[Segment("CCI")]
public class CCI_CharacteristicClassId : EdifactSegment
{
	[Position(1)]
	public string PropertyClassCoded { get; set; }

	[Position(2)]
	public C502_MeasurementDetails MeasurementDetails { get; set; }

	[Position(3)]
	public C240_ProductCharacteristic ProductCharacteristic { get; set; }

	[Position(4)]
	public string CharacteristicRelevanceCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CCI_CharacteristicClassId>(this);
		validator.Length(x => x.PropertyClassCoded, 1, 3);
		validator.Length(x => x.CharacteristicRelevanceCoded, 1, 3);
		return validator.Results;
	}
}
