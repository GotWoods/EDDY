using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("N11")]
public class N11_StoreNumber : EdiX12Segment
{
	[Position(01)]
	public string StoreNumber { get; set; }

	[Position(02)]
	public string LocationIdentifier { get; set; }

	[Position(03)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N11_StoreNumber>(this);
		validator.Required(x=>x.StoreNumber);
		validator.Length(x => x.StoreNumber, 1, 10);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
