using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("SCD")]
public class SCD_StructureComponentDefinition : EdifactSegment
{
	[Position(1)]
	public string StructureComponentFunctionCodeQualifier { get; set; }

	[Position(2)]
	public C786_StructureComponentIdentification StructureComponentIdentification { get; set; }

	[Position(3)]
	public C082_PartyIdentificationDetails PartyIdentificationDetails { get; set; }

	[Position(4)]
	public string StatusDescriptionCode { get; set; }

	[Position(5)]
	public string ConfigurationLevel { get; set; }

	[Position(6)]
	public C778_PositionIdentification PositionIdentification { get; set; }

	[Position(7)]
	public C240_ProductCharacteristic ProductCharacteristic { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCD_StructureComponentDefinition>(this);
		validator.Required(x=>x.StructureComponentFunctionCodeQualifier);
		validator.Length(x => x.StructureComponentFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		validator.Length(x => x.ConfigurationLevel, 1, 2);
		return validator.Results;
	}
}
