using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E004")]
public class E004_RuleDetails : EdifactComponent
{
	[Position(1)]
	public string SpecialConditionsCoded { get; set; }

	[Position(2)]
	public string NumberOfUnits { get; set; }

	[Position(3)]
	public string NumberOfUnitsQualifier { get; set; }

	[Position(4)]
	public string RelationCoded { get; set; }

	[Position(5)]
	public string DaysOfOperation { get; set; }

	[Position(6)]
	public string MonetaryAmount { get; set; }

	[Position(7)]
	public string MonetaryAmountTypeQualifier { get; set; }

	[Position(8)]
	public string CurrencyCoded { get; set; }

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
		validator.Required(x=>x.SpecialConditionsCoded);
		validator.Length(x => x.SpecialConditionsCoded, 1, 3);
		validator.Length(x => x.NumberOfUnits, 1, 15);
		validator.Length(x => x.NumberOfUnitsQualifier, 1, 3);
		validator.Length(x => x.RelationCoded, 1, 3);
		validator.Length(x => x.DaysOfOperation, 1, 7);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.MonetaryAmountTypeQualifier, 1, 3);
		validator.Length(x => x.CurrencyCoded, 1, 3);
		validator.Length(x => x.FreeText, 1, 70);
		validator.Length(x => x.FreeText2, 1, 70);
		validator.Length(x => x.FreeText3, 1, 70);
		validator.Length(x => x.FreeText4, 1, 70);
		validator.Length(x => x.FreeText5, 1, 70);
		validator.Length(x => x.FreeText6, 1, 70);
		validator.Length(x => x.FreeText7, 1, 70);
		validator.Length(x => x.FreeText8, 1, 70);
		validator.Length(x => x.FreeText9, 1, 70);
		return validator.Results;
	}
}
