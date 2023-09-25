using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("ENT")]
public class ENT_Entity : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public string EntityIdentifierCode { get; set; }

	[Position(03)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(04)]
	public string IdentificationCode { get; set; }

	[Position(05)]
	public string EntityIdentifierCode2 { get; set; }

	[Position(06)]
	public string IdentificationCodeQualifier2 { get; set; }

	[Position(07)]
	public string IdentificationCode2 { get; set; }

	[Position(08)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(09)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ENT_Entity>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.EntityIdentifierCode2, 2, 3);
		validator.Length(x => x.IdentificationCodeQualifier2, 1, 2);
		validator.Length(x => x.IdentificationCode2, 2, 80);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		return validator.Results;
	}
}
