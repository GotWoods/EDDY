using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("CT")]
public class CT_CarType : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string CarTypeCode { get; set; }

	[Position(03)]
	public string CarTypeCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CT_CarType>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.CarTypeCode);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.CarTypeCode, 1, 4);
		validator.Length(x => x.CarTypeCode2, 1, 4);
		return validator.Results;
	}
}
