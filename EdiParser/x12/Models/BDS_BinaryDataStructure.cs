using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BDS")]
public class BDS_BinaryDataStructure : EdiX12Segment
{
	[Position(01)]
	public string FilterIDCode { get; set; }

	[Position(02)]
	public int? LengthOfBinaryData { get; set; }

	[Position(03)]
	public string BinaryData { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BDS_BinaryDataStructure>(this);
		validator.Required(x=>x.FilterIDCode);
		validator.Required(x=>x.LengthOfBinaryData);
		validator.Required(x=>x.BinaryData);
		validator.Length(x => x.FilterIDCode, 3);
		validator.Length(x => x.LengthOfBinaryData, 1, 15);
		validator.Length(x => x.BinaryData, 1, 2147483647);
		return validator.Results;
	}
}
