using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("AWD")]
public class AWD_AmountWithDescription : EdiX12Segment 
{
	
	[Position(01)]
	public C007_AmountQualifyingDescription AmountQualifyingDescription { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string FreeFormInformation { get; set; }

	[Position(04)]
	public string CurrencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AWD_AmountWithDescription>(this);
		//TODO: validate composite?
//		validator.Required(x=>x.AmountQualifyingDescription);
		validator.AtLeastOneIsRequired(x=>x.MonetaryAmount, x=>x.FreeFormInformation);
		validator.OnlyOneOf(x=>x.MonetaryAmount, x=>x.FreeFormInformation);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.FreeFormInformation, 1, 30);
		validator.Length(x => x.CurrencyCode, 3);
		return validator.Results;
	}
}
