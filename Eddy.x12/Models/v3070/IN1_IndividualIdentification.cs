using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("IN1")]
public class IN1_IndividualIdentification : EdiX12Segment
{
	[Position(01)]
	public string EntityTypeQualifier { get; set; }

	[Position(02)]
	public string NameTypeCode { get; set; }

	[Position(03)]
	public string EntityIdentifierCode { get; set; }

	[Position(04)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public string IndividualRelationshipCode { get; set; }

	[Position(07)]
	public string LevelOfIndividualTestOrCourseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IN1_IndividualIdentification>(this);
		validator.Required(x=>x.EntityTypeQualifier);
		validator.Required(x=>x.NameTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.EntityTypeQualifier, 1);
		validator.Length(x => x.NameTypeCode, 2);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.IndividualRelationshipCode, 2);
		validator.Length(x => x.LevelOfIndividualTestOrCourseCode, 2);
		return validator.Results;
	}
}
