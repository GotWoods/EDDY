using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("UD")]
public class UD_UnderwritingStatus : EdiX12Segment
{
	[Position(01)]
	public string StatusCode { get; set; }

	[Position(02)]
	public string StatusCode2 { get; set; }

	[Position(03)]
	public string UnderwritingDecisionCode { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Description { get; set; }

	[Position(06)]
	public string OfferBasisCode { get; set; }

	[Position(07)]
	public int? AssignedNumber { get; set; }

	[Position(08)]
	public string OfferBasisCode2 { get; set; }

	[Position(09)]
	public int? AssignedNumber2 { get; set; }

	[Position(10)]
	public string Description2 { get; set; }

	[Position(11)]
	public decimal? Percent { get; set; }

	[Position(12)]
	public string Amount { get; set; }

	[Position(13)]
	public int? Number { get; set; }

	[Position(14)]
	public string StateOrProvinceCode { get; set; }

	[Position(15)]
	public string CountryCode { get; set; }

	[Position(16)]
	public string StateOrProvinceCode2 { get; set; }

	[Position(17)]
	public string CountryCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UD_UnderwritingStatus>(this);
		validator.Required(x=>x.StatusCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Description2, x=>x.Percent, x=>x.Amount);
		validator.Length(x => x.StatusCode, 2);
		validator.Length(x => x.StatusCode2, 2);
		validator.Length(x => x.UnderwritingDecisionCode, 1);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.OfferBasisCode, 2, 3);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.OfferBasisCode2, 2, 3);
		validator.Length(x => x.AssignedNumber2, 1, 6);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.StateOrProvinceCode2, 2);
		validator.Length(x => x.CountryCode2, 2, 3);
		return validator.Results;
	}
}
