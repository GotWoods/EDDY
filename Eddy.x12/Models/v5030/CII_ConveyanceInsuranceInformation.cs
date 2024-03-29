using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("CII")]
public class CII_ConveyanceInsuranceInformation : EdiX12Segment
{
	[Position(01)]
	public string Name { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public int? Year { get; set; }

	[Position(04)]
	public string CurrencyCode { get; set; }

	[Position(05)]
	public string Amount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CII_ConveyanceInsuranceInformation>(this);
		validator.Required(x=>x.Name);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Year);
		validator.Required(x=>x.Amount);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Year, 4);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.Amount, 1, 15);
		return validator.Results;
	}
}
