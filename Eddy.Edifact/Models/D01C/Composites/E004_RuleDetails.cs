using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("E004")]
public class E004_RuleDetails : EdifactComponent
{
	[Position(1)]
	public string SpecialConditionCode { get; set; }

	[Position(2)]
	public string UnitsQuantity { get; set; }

	[Position(3)]
	public string UnitTypeCodeQualifier { get; set; }

	[Position(4)]
	public string RelationCode { get; set; }

	[Position(5)]
	public string DaysOfWeekSetIdentifier { get; set; }

	[Position(6)]
	public string MonetaryAmount { get; set; }

	[Position(7)]
	public string MonetaryAmountTypeCodeQualifier { get; set; }

	[Position(8)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(9)]
	public string FreeText { get; set; }

	[Position(10)]
	public string FreeText2 { get; set; }

	[Position(11)]
	public string FreeText3 { get; set; }

	[Position(12)]
	public string FreeText4 { get; set; }

	[Position(13)]
	public string FreeText5 { get; set; }

	[Position(14)]
	public string FreeText6 { get; set; }

	[Position(15)]
	public string FreeText7 { get; set; }

	[Position(16)]
	public string FreeText8 { get; set; }

	[Position(17)]
	public string FreeText9 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E004_RuleDetails>(this);
		validator.Required(x=>x.SpecialConditionCode);
		validator.Length(x => x.SpecialConditionCode, 1, 3);
		validator.Length(x => x.UnitsQuantity, 1, 15);
		validator.Length(x => x.UnitTypeCodeQualifier, 1, 3);
		validator.Length(x => x.RelationCode, 1, 3);
		validator.Length(x => x.DaysOfWeekSetIdentifier, 1, 7);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.MonetaryAmountTypeCodeQualifier, 1, 3);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.FreeText, 1, 512);
		validator.Length(x => x.FreeText2, 1, 512);
		validator.Length(x => x.FreeText3, 1, 512);
		validator.Length(x => x.FreeText4, 1, 512);
		validator.Length(x => x.FreeText5, 1, 512);
		validator.Length(x => x.FreeText6, 1, 512);
		validator.Length(x => x.FreeText7, 1, 512);
		validator.Length(x => x.FreeText8, 1, 512);
		validator.Length(x => x.FreeText9, 1, 512);
		return validator.Results;
	}
}
