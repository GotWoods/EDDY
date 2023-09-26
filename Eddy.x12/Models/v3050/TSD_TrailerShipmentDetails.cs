using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("TSD")]
public class TSD_TrailerShipmentDetails : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public string Position { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TSD_TrailerShipmentDetails>(this);
		validator.Length(x => x.AssignedIdentification, 1, 11);
		validator.Length(x => x.Position, 1, 3);
		return validator.Results;
	}
}
