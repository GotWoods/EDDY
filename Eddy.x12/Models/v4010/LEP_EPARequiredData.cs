using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("LEP")]
public class LEP_EPARequiredData : EdiX12Segment
{
	[Position(01)]
	public string EPAWasteStreamNumberCode { get; set; }

	[Position(02)]
	public string WasteCharacteristicsCode { get; set; }

	[Position(03)]
	public string StateOrProvinceCode { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LEP_EPARequiredData>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.StateOrProvinceCode, x=>x.ReferenceIdentification);
		validator.Length(x => x.EPAWasteStreamNumberCode, 4, 6);
		validator.Length(x => x.WasteCharacteristicsCode, 12, 16);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		return validator.Results;
	}
}
