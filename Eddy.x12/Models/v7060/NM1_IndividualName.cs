using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7060;

[Segment("NM1")]
public class NM1_IndividualOrOrganizationalName : EdiX12Segment
{
	[Position(01)]
	public string EntityIdentifierCode { get; set; }

	[Position(02)]
	public string EntityTypeQualifier { get; set; }

	[Position(03)]
	public string NameLastOrOrganizationName { get; set; }

	[Position(04)]
	public string NameFirst { get; set; }

	[Position(05)]
	public string NameMiddle { get; set; }

	[Position(06)]
	public string NamePrefix { get; set; }

	[Position(07)]
	public string NameSuffix { get; set; }

	[Position(08)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(09)]
	public string IdentificationCode { get; set; }

	[Position(10)]
	public string EntityRelationshipCode { get; set; }

	[Position(11)]
	public string EntityIdentifierCode2 { get; set; }

	[Position(12)]
	public string NameLastOrOrganizationName2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NM1_IndividualOrOrganizationalName>(this);
		validator.Required(x=>x.EntityIdentifierCode);
		validator.Required(x=>x.EntityTypeQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.ARequiresB(x=>x.EntityIdentifierCode2, x=>x.EntityRelationshipCode);
		validator.ARequiresB(x=>x.NameLastOrOrganizationName2, x=>x.NameLastOrOrganizationName);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.EntityTypeQualifier, 1);
		validator.Length(x => x.NameLastOrOrganizationName, 1, 80);
		validator.Length(x => x.NameFirst, 1, 35);
		validator.Length(x => x.NameMiddle, 1, 25);
		validator.Length(x => x.NamePrefix, 1, 10);
		validator.Length(x => x.NameSuffix, 1, 10);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.EntityRelationshipCode, 2);
		validator.Length(x => x.EntityIdentifierCode2, 2, 3);
		validator.Length(x => x.NameLastOrOrganizationName2, 1, 80);
		return validator.Results;
	}
}
