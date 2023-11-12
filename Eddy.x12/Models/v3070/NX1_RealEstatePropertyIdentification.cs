using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("NX1")]
public class NX1_PropertyOrEntityIdentification : EdiX12Segment
{
	[Position(01)]
	public string EntityIdentifierCode { get; set; }

	[Position(02)]
	public string EntityIdentifierCode2 { get; set; }

	[Position(03)]
	public string EntityIdentifierCode3 { get; set; }

	[Position(04)]
	public string EntityIdentifierCode4 { get; set; }

	[Position(05)]
	public string EntityIdentifierCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NX1_PropertyOrEntityIdentification>(this);
		validator.Required(x=>x.EntityIdentifierCode);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.EntityIdentifierCode2, 2, 3);
		validator.Length(x => x.EntityIdentifierCode3, 2, 3);
		validator.Length(x => x.EntityIdentifierCode4, 2, 3);
		validator.Length(x => x.EntityIdentifierCode5, 2, 3);
		return validator.Results;
	}
}
