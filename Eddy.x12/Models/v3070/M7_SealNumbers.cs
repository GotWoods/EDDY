using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("M7")]
public class M7_SealNumbers : EdiX12Segment
{
	[Position(01)]
	public string SealNumber { get; set; }

	[Position(02)]
	public string SealNumber2 { get; set; }

	[Position(03)]
	public string SealNumber3 { get; set; }

	[Position(04)]
	public string SealNumber4 { get; set; }

	[Position(05)]
	public string EntityIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M7_SealNumbers>(this);
		validator.Required(x=>x.SealNumber);
		validator.Length(x => x.SealNumber, 2, 15);
		validator.Length(x => x.SealNumber2, 2, 15);
		validator.Length(x => x.SealNumber3, 2, 15);
		validator.Length(x => x.SealNumber4, 2, 15);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		return validator.Results;
	}
}
