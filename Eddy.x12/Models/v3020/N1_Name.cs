using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("N1")]
public class N1_Name : EdiX12Segment
{
	[Position(01)]
	public string EntityIdentifierCode { get; set; }

	[Position(02)]
	public string Name { get; set; }

	[Position(03)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(04)]
	public string IdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N1_Name>(this);
		validator.Required(x=>x.EntityIdentifierCode);
		validator.AtLeastOneIsRequired(x=>x.Name, x=>x.IdentificationCodeQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.EntityIdentifierCode, 2);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		return validator.Results;
	}
}
