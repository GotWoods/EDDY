using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

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
	public decimal? Percent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TER_Territory>(this);
		validator.Required(x=>x.ClassOfTradeCode);
		validator.Length(x => x.ClassOfTradeCode, 2);
		validator.Length(x => x.GeneralTerritoryCode, 1, 2);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.Percent, 1, 10);
		return validator.Results;
	}
}
