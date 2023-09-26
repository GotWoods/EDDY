using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("RDI")]
public class RDI_RetailAccountDemographicInformation : EdiX12Segment
{
	[Position(01)]
	public string EntityIdentifierCode { get; set; }

	[Position(02)]
	public string CountryCode { get; set; }

	[Position(03)]
	public string AmountQualifierCode { get; set; }

	[Position(04)]
	public string Amount { get; set; }

	[Position(05)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RDI_RetailAccountDemographicInformation>(this);
		validator.Required(x=>x.EntityIdentifierCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountQualifierCode, x=>x.Amount);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
