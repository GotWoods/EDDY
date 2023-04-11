using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("PT")]
public class PT_Patron : EdiX12Segment
{
	[Position(01)]
	public string ConditionSegmentLogicalConnector { get; set; }

	[Position(02)]
	public string EntityIdentifierCode { get; set; }

	[Position(03)]
	public string Name { get; set; }

	[Position(04)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(05)]
	public string IdentificationCode { get; set; }

	[Position(06)]
	public string ChangeTypeCode { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(08)]
	public string DocketControlNumber { get; set; }

	[Position(09)]
	public string DocketIdentification { get; set; }

	[Position(10)]
	public string GroupTitle { get; set; }

	[Position(11)]
	public string EntityRelationshipCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PT_Patron>(this);
		validator.Required(x=>x.ConditionSegmentLogicalConnector);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.ARequiresB(x=>x.IdentificationCode, x=>x.EntityIdentifierCode);
		validator.OnlyOneOf(x=>x.StandardCarrierAlphaCode, x=>x.EntityIdentifierCode);
		validator.ARequiresB(x=>x.EntityRelationshipCode, x=>x.EntityIdentifierCode);
		validator.Length(x => x.ConditionSegmentLogicalConnector, 1, 3);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.ChangeTypeCode, 1);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.DocketControlNumber, 1, 7);
		validator.Length(x => x.DocketIdentification, 1, 11);
		validator.Length(x => x.GroupTitle, 2, 30);
		validator.Length(x => x.EntityRelationshipCode, 2);
		return validator.Results;
	}
}
