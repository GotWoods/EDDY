using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("LH5")]
public class LH5_HazardousMaterialShipmentContacts : EdiX12Segment
{
	[Position(01)]
	public string CommunicationNumber { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public string CommunicationNumber2 { get; set; }

	[Position(04)]
	public string Name2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LH5_HazardousMaterialShipmentContacts>(this);
		validator.Required(x=>x.CommunicationNumber);
		validator.Length(x => x.CommunicationNumber, 1, 25);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.CommunicationNumber2, 1, 25);
		validator.Length(x => x.Name2, 1, 35);
		return validator.Results;
	}
}
