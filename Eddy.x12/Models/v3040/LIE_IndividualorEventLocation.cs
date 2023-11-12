using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("LIE")]
public class LIE_IndividualOrEventLocation : EdiX12Segment
{
	[Position(01)]
	public string LocationTypeCode { get; set; }

	[Position(02)]
	public string ProximityCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string EntityIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LIE_IndividualOrEventLocation>(this);
		validator.Required(x=>x.LocationTypeCode);
		validator.Length(x => x.LocationTypeCode, 2);
		validator.Length(x => x.ProximityCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.EntityIdentifierCode, 2);
		return validator.Results;
	}
}
