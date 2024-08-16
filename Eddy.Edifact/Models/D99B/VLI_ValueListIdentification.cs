using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("VLI")]
public class VLI_ValueListIdentification : EdifactSegment
{
	[Position(1)]
	public C780_ValueListIdentification ValueListIdentification { get; set; }

	[Position(2)]
	public C082_PartyIdentificationDetails PartyIdentificationDetails { get; set; }

	[Position(3)]
	public string StatusDescriptionCode { get; set; }

	[Position(4)]
	public string ValueListName { get; set; }

	[Position(5)]
	public string ClassDesignatorCoded { get; set; }

	[Position(6)]
	public string ValueListTypeCoded { get; set; }

	[Position(7)]
	public C240_ProductCharacteristic ProductCharacteristic { get; set; }

	[Position(8)]
	public string MaintenanceOperationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<VLI_ValueListIdentification>(this);
		validator.Required(x=>x.ValueListIdentification);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		validator.Length(x => x.ValueListName, 1, 70);
		validator.Length(x => x.ClassDesignatorCoded, 1, 3);
		validator.Length(x => x.ValueListTypeCoded, 1, 3);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		return validator.Results;
	}
}
