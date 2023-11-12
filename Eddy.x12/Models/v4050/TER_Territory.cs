using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("TER")]
public class TER_Territory : EdiX12Segment
{
	[Position(01)]
	public string ClassOfTradeCode { get; set; }

	[Position(02)]
	public string GeneralTerritoryCode { get; set; }

	[Position(03)]
	public string FreeFormMessageText { get; set; }

	[Position(04)]
	public string CountryCode { get; set; }

	[Position(05)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(06)]
	public string FreeFormMessageText2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TER_Territory>(this);
		validator.Required(x=>x.ClassOfTradeCode);
		validator.Length(x => x.ClassOfTradeCode, 2);
		validator.Length(x => x.GeneralTerritoryCode, 1, 2);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.FreeFormMessageText2, 1, 264);
		return validator.Results;
	}
}
