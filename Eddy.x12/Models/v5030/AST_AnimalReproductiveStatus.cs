using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("AST")]
public class AST_AnimalReproductiveStatus : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public int? TestPeriodOrIntervalValue { get; set; }

	[Position(05)]
	public string UnitOfTimePeriodOrInterval { get; set; }

	[Position(06)]
	public string Date2 { get; set; }

	[Position(07)]
	public int? TestPeriodOrIntervalValue2 { get; set; }

	[Position(08)]
	public string UnitOfTimePeriodOrInterval2 { get; set; }

	[Position(09)]
	public string Date3 { get; set; }

	[Position(10)]
	public int? TestPeriodOrIntervalValue3 { get; set; }

	[Position(11)]
	public string UnitOfTimePeriodOrInterval3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AST_AnimalReproductiveStatus>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TestPeriodOrIntervalValue, x=>x.UnitOfTimePeriodOrInterval);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TestPeriodOrIntervalValue2, x=>x.UnitOfTimePeriodOrInterval2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TestPeriodOrIntervalValue3, x=>x.UnitOfTimePeriodOrInterval3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.TestPeriodOrIntervalValue, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.TestPeriodOrIntervalValue2, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrInterval2, 2);
		validator.Length(x => x.Date3, 8);
		validator.Length(x => x.TestPeriodOrIntervalValue3, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrInterval3, 2);
		return validator.Results;
	}
}
