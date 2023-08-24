using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("BIN")]
public class BIN_BinaryData : EdiX12Segment
{
	[Position(01)]
	public int? LengthOfBinaryData { get; set; }

	[Position(02)]
	public string BinaryData { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BIN_BinaryData>(this);
		validator.Required(x=>x.LengthOfBinaryData);
		validator.Required(x=>x.BinaryData);
		validator.Length(x => x.LengthOfBinaryData, 1, 15);
		validator.Length(x => x.BinaryData, 1, 2147483647);
		return validator.Results;
	}
}
