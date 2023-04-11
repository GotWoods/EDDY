using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("ATH")]
public class ATH_ResourceAuthorization : EdiX12Segment 
{
	[Position(01)]
	public string ResourceAuthorizationCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public decimal? Quantity2 { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ATH_ResourceAuthorization>(this);
		validator.Required(x=>x.ResourceAuthorizationCode);
		validator.AtLeastOneIsRequired(x=>x.Date, x=>x.Quantity);
		validator.ARequiresB(x=>x.Quantity, x=>x.Date2);
		validator.ARequiresB(x=>x.Quantity2, x=>x.Date2);
		validator.Length(x => x.ResourceAuthorizationCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Date2, 8);
		return validator.Results;
	}
}
