using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("SOM")]
public class SOM_StatusOfMortgage : EdiX12Segment
{
	[Position(01)]
	public string LoanStatusCode { get; set; }

	[Position(02)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(03)]
	public string DateTimePeriod { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public string TypeOfBankruptcyCode { get; set; }

	[Position(06)]
	public string Date { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(08)]
	public string LoanStatusCode2 { get; set; }

	[Position(09)]
	public string DateTimePeriodFormatQualifier2 { get; set; }

	[Position(10)]
	public string DateTimePeriod2 { get; set; }

	[Position(11)]
	public string LoanStatusCode3 { get; set; }

	[Position(12)]
	public string DateTimePeriodFormatQualifier3 { get; set; }

	[Position(13)]
	public string DateTimePeriod3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SOM_StatusOfMortgage>(this);
		validator.Required(x=>x.LoanStatusCode);
		validator.Required(x=>x.DateTimePeriodFormatQualifier);
		validator.Required(x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TypeOfBankruptcyCode, x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier2, x=>x.DateTimePeriod2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier3, x=>x.DateTimePeriod3);
		validator.Length(x => x.LoanStatusCode, 1, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.TypeOfBankruptcyCode, 1);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.LoanStatusCode2, 1, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier2, 2, 3);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.LoanStatusCode3, 1, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier3, 2, 3);
		validator.Length(x => x.DateTimePeriod3, 1, 35);
		return validator.Results;
	}
}
