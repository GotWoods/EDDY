using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("RST")]
public class RST_CarrierRestriction : EdiX12Segment
{
	[Position(01)]
	public string CarrierRestrictionCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RST_CarrierRestriction>(this);
		validator.Length(x => x.CarrierRestrictionCode, 1, 10);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
