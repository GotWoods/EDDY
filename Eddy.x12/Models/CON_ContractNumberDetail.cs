using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CON")]
public class CON_ContractNumberDetail : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string ContractStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CON_ContractNumberDetail>(this);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.ContractStatusCode);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ContractStatusCode, 2);
		return validator.Results;
	}
}
