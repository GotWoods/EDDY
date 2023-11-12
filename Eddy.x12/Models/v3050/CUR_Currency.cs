using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("CUR")]
public class CUR_Currency : EdiX12Segment
{
	[Position(01)]
	public string EntityIdentifierCode { get; set; }

	[Position(02)]
	public string CurrencyCode { get; set; }

	[Position(03)]
	public decimal? ExchangeRate { get; set; }

	[Position(04)]
	public string EntityIdentifierCode2 { get; set; }

	[Position(05)]
	public string CurrencyCode2 { get; set; }

	[Position(06)]
	public string CurrencyMarketExchangeCode { get; set; }

	[Position(07)]
	public string DateTimeQualifier { get; set; }

	[Position(08)]
	public string Date { get; set; }

	[Position(09)]
	public string Time { get; set; }

	[Position(10)]
	public string DateTimeQualifier2 { get; set; }

	[Position(11)]
	public string Date2 { get; set; }

	[Position(12)]
	public string Time2 { get; set; }

	[Position(13)]
	public string DateTimeQualifier3 { get; set; }

	[Position(14)]
	public string Date3 { get; set; }

	[Position(15)]
	public string Time3 { get; set; }

	[Position(16)]
	public string DateTimeQualifier4 { get; set; }

	[Position(17)]
	public string Date4 { get; set; }

	[Position(18)]
	public string Time4 { get; set; }

	[Position(19)]
	public string DateTimeQualifier5 { get; set; }

	[Position(20)]
	public string Date5 { get; set; }

	[Position(21)]
	public string Time5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CUR_Currency>(this);
		validator.Required(x=>x.EntityIdentifierCode);
		validator.Required(x=>x.CurrencyCode);
		validator.ARequiresB(x=>x.Date, x=>x.DateTimeQualifier);
		validator.ARequiresB(x=>x.Time, x=>x.DateTimeQualifier);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimeQualifier2, x=>x.Date2, x=>x.Time2);
		validator.ARequiresB(x=>x.Date2, x=>x.DateTimeQualifier2);
		validator.ARequiresB(x=>x.Time2, x=>x.DateTimeQualifier2);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimeQualifier3, x=>x.Date3, x=>x.Time3);
		validator.ARequiresB(x=>x.Date3, x=>x.DateTimeQualifier3);
		validator.ARequiresB(x=>x.Time3, x=>x.DateTimeQualifier3);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimeQualifier4, x=>x.Date4, x=>x.Time4);
		validator.ARequiresB(x=>x.Date4, x=>x.DateTimeQualifier4);
		validator.ARequiresB(x=>x.Time4, x=>x.DateTimeQualifier4);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimeQualifier5, x=>x.Date5, x=>x.Time5);
		validator.ARequiresB(x=>x.Date5, x=>x.DateTimeQualifier5);
		validator.ARequiresB(x=>x.Time5, x=>x.DateTimeQualifier5);
		validator.Length(x => x.EntityIdentifierCode, 2);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.ExchangeRate, 4, 6);
		validator.Length(x => x.EntityIdentifierCode2, 2);
		validator.Length(x => x.CurrencyCode2, 3);
		validator.Length(x => x.CurrencyMarketExchangeCode, 3);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.DateTimeQualifier2, 3);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.Time2, 4, 8);
		validator.Length(x => x.DateTimeQualifier3, 3);
		validator.Length(x => x.Date3, 6);
		validator.Length(x => x.Time3, 4, 8);
		validator.Length(x => x.DateTimeQualifier4, 3);
		validator.Length(x => x.Date4, 6);
		validator.Length(x => x.Time4, 4, 8);
		validator.Length(x => x.DateTimeQualifier5, 3);
		validator.Length(x => x.Date5, 6);
		validator.Length(x => x.Time5, 4, 8);
		return validator.Results;
	}
}
