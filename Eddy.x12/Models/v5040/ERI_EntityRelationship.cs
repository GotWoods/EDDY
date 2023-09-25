using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5040;

[Segment("ERI")]
public class ERI_EntityRelationship : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(02)]
	public string IdentificationCode { get; set; }

	[Position(03)]
	public string EntityRelationshipCode { get; set; }

	[Position(04)]
	public string IdentificationCodeQualifier2 { get; set; }

	[Position(05)]
	public string IdentificationCode2 { get; set; }

	[Position(06)]
	public string EntityRelationshipCode2 { get; set; }

	[Position(07)]
	public string EntityRelationshipCode3 { get; set; }

	[Position(08)]
	public string EntityRelationshipCode4 { get; set; }

	[Position(09)]
	public string HierarchyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ERI_EntityRelationship>(this);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.Required(x=>x.EntityRelationshipCode);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.EntityRelationshipCode, 2);
		validator.Length(x => x.IdentificationCodeQualifier2, 1, 2);
		validator.Length(x => x.IdentificationCode2, 2, 80);
		validator.Length(x => x.EntityRelationshipCode2, 2);
		validator.Length(x => x.EntityRelationshipCode3, 2);
		validator.Length(x => x.EntityRelationshipCode4, 2);
		validator.Length(x => x.HierarchyCode, 2);
		return validator.Results;
	}
}
