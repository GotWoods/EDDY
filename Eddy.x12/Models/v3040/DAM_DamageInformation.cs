using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("DAM")]
public class DAM_DamageInformation : EdiX12Segment
{
	[Position(01)]
	public string DamageStatusCode { get; set; }

	[Position(02)]
	public string DamageAreaCode { get; set; }

	[Position(03)]
	public string Amount { get; set; }

	[Position(04)]
	public string CurrencyCode { get; set; }

	[Position(05)]
	public string DamageStatusCode2 { get; set; }

	[Position(06)]
	public string DamageAreaCode2 { get; set; }

	[Position(07)]
	public string Amount2 { get; set; }

	[Position(08)]
	public string DamageStatusCode3 { get; set; }

	[Position(09)]
	public string DamageAreaCode3 { get; set; }

	[Position(10)]
	public string Amount3 { get; set; }

	[Position(11)]
	public string DamageStatusCode4 { get; set; }

	[Position(12)]
	public string DamageAreaCode4 { get; set; }

	[Position(13)]
	public string Amount4 { get; set; }

	[Position(14)]
	public string DamageStatusCode5 { get; set; }

	[Position(15)]
	public string DamageAreaCode5 { get; set; }

	[Position(16)]
	public string Amount5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DAM_DamageInformation>(this);
		validator.AtLeastOneIsRequired(x=>x.DamageStatusCode, x=>x.DamageAreaCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Amount2, x=>x.DamageStatusCode2, x=>x.DamageAreaCode2);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Amount3, x=>x.DamageStatusCode3, x=>x.DamageAreaCode3);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Amount4, x=>x.DamageStatusCode4, x=>x.DamageAreaCode4);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Amount5, x=>x.DamageStatusCode5, x=>x.DamageAreaCode5);
		validator.Length(x => x.DamageStatusCode, 2);
		validator.Length(x => x.DamageAreaCode, 2);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.DamageStatusCode2, 2);
		validator.Length(x => x.DamageAreaCode2, 2);
		validator.Length(x => x.Amount2, 1, 15);
		validator.Length(x => x.DamageStatusCode3, 2);
		validator.Length(x => x.DamageAreaCode3, 2);
		validator.Length(x => x.Amount3, 1, 15);
		validator.Length(x => x.DamageStatusCode4, 2);
		validator.Length(x => x.DamageAreaCode4, 2);
		validator.Length(x => x.Amount4, 1, 15);
		validator.Length(x => x.DamageStatusCode5, 2);
		validator.Length(x => x.DamageAreaCode5, 2);
		validator.Length(x => x.Amount5, 1, 15);
		return validator.Results;
	}
}
