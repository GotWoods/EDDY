using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("N11")]
public class N11_StoreLocation : EdiX12Segment
{
	[Position(01)]
	public string StoreNumber { get; set; }

	[Position(02)]
	public string LocationIdentifier { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N11_StoreLocation>(this);
		validator.Required(x=>x.StoreNumber);
		validator.Length(x => x.StoreNumber, 1, 10);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		return validator.Results;
	}
}
