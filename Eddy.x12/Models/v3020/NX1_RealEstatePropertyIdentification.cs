using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("NX1")]
public class NX1_RealEstatePropertyIdentification : EdiX12Segment
{
	[Position(01)]
	public string EntityIdentifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NX1_RealEstatePropertyIdentification>(this);
		validator.Required(x=>x.EntityIdentifierCode);
		validator.Length(x => x.EntityIdentifierCode, 2);
		return validator.Results;
	}
}
