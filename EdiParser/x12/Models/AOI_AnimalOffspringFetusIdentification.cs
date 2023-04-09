using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("AOI")]
public class AOI_AnimalOffspringFetusIdentification : EdiX12Segment 
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string GenderCode { get; set; }

	[Position(04)]
	public string OffspringFetusStatusCode { get; set; }

	[Position(05)]
	public int? TestPeriodOrIntervalValue { get; set; }

	[Position(06)]
	public string UnitOfTimePeriodOrIntervalCode { get; set; }

	[Position(07)]
	public string AnimalDispositionCode { get; set; }

	[Position(08)]
	public int? TestPeriodOrIntervalValue2 { get; set; }

	[Position(09)]
	public string UnitOfTimePeriodOrIntervalCode2 { get; set; }

	[Position(10)]
	public string ReferenceIdentification2 { get; set; }

	[Position(11)]
	public string Date { get; set; }

	[Position(12)]
	public int? TestPeriodOrIntervalValue3 { get; set; }

	[Position(13)]
	public string UnitOfTimePeriodOrIntervalCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AOI_AnimalOffspringFetusIdentification>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.GenderCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AnimalDispositionCode, x=>x.TestPeriodOrIntervalValue2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TestPeriodOrIntervalValue2, x=>x.UnitOfTimePeriodOrIntervalCode2);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.ReferenceIdentification2, x=>x.Date, x=>x.TestPeriodOrIntervalValue3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TestPeriodOrIntervalValue3, x=>x.UnitOfTimePeriodOrIntervalCode3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.GenderCode, 1);
		validator.Length(x => x.OffspringFetusStatusCode, 2);
		validator.Length(x => x.TestPeriodOrIntervalValue, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrIntervalCode, 2);
		validator.Length(x => x.AnimalDispositionCode, 2);
		validator.Length(x => x.TestPeriodOrIntervalValue2, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrIntervalCode2, 2);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.TestPeriodOrIntervalValue3, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrIntervalCode3, 2);
		return validator.Results;
	}
}
