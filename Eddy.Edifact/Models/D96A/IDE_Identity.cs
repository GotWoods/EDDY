using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("IDE")]
public class IDE_Identity : EdifactSegment
{
	[Position(1)]
	public string IdentificationQualifier { get; set; }

	[Position(2)]
	public C206_IdentificationNumber IdentificationNumber { get; set; }

	[Position(3)]
	public C082_PartyIdentificationDetails PartyIdentificationDetails { get; set; }

	[Position(4)]
	public string StatusCoded { get; set; }

	[Position(5)]
	public string ConfigurationLevel { get; set; }

	[Position(6)]
	public C778_PositionIdentification PositionIdentification { get; set; }

	[Position(7)]
	public C240_ProductCharacteristic ProductCharacteristic { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IDE_Identity>(this);
		validator.Required(x=>x.IdentificationQualifier);
		validator.Required(x=>x.IdentificationNumber);
		validator.Length(x => x.IdentificationQualifier, 1, 3);
		validator.Length(x => x.StatusCoded, 1, 3);
		validator.Length(x => x.ConfigurationLevel, 1, 2);
		return validator.Results;
	}
}
