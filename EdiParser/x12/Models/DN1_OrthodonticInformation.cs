using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("DN1")]
public class DN1_OrthodonticInformation : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public decimal? Quantity2 { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(04)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DN1_OrthodonticInformation>(this);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
