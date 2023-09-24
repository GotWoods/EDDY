using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("D1")]
public class D1_ConsigneeName : EdiX12Segment
{
	[Position(01)]
	public string Name30CharacterFormat { get; set; }

	[Position(02)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(03)]
	public string IdentificationCode { get; set; }

	[Position(04)]
	public string EntityIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<D1_ConsigneeName>(this);
		validator.Required(x=>x.Name30CharacterFormat);
		validator.Length(x => x.Name30CharacterFormat, 2, 30);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		validator.Length(x => x.EntityIdentifierCode, 2);
		return validator.Results;
	}
}
