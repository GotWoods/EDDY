using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("LEP")]
public class LEP_EPARequiredData : EdiX12Segment
{
	[Position(01)]
	public string EPAWasteStreamNumberCode { get; set; }

	[Position(02)]
	public string WasteCharacteristicsCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LEP_EPARequiredData>(this);
		validator.Length(x => x.EPAWasteStreamNumberCode, 4);
		validator.Length(x => x.WasteCharacteristicsCode, 14, 16);
		return validator.Results;
	}
}
