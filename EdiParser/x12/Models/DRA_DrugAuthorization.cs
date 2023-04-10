using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;
using EdiParser.x12.Models.Elements;

namespace EdiParser.x12.Models;

[Segment("DRA")]
public class DRA_DrugAuthorization : EdiX12Segment
{
	[Position(01)]
	public string Description { get; set; }

	[Position(02)]
	public string CertificationTypeCode { get; set; }

	[Position(03)]
	public C003_CompositeMedicalProcedureIdentifier CompositeMedicalProcedureIdentifier { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string FreeFormMessageText { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(09)]
	public string DateTimeQualifier { get; set; }

	[Position(10)]
	public string Date { get; set; }

	[Position(11)]
	public string FreeFormMessageText2 { get; set; }

	[Position(12)]
	public decimal? Quantity2 { get; set; }

	[Position(13)]
	public C060_QuestionAndAnswer QuestionAndAnswer { get; set; }

	[Position(14)]
	public string DosageFormCode { get; set; }

	[Position(15)]
	public string FreeFormMessageText3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DRA_DrugAuthorization>(this);
		validator.Required(x=>x.Description);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.CertificationTypeCode, 1);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.FreeFormMessageText, 1, 264);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.FreeFormMessageText2, 1, 264);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.DosageFormCode, 2);
		validator.Length(x => x.FreeFormMessageText3, 1, 264);
		return validator.Results;
	}
}
