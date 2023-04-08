using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("ANI")]
public class ANI_AnimalIdentification : EdiX12Segment 
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Date2 { get; set; }

	[Position(04)]
	public int? TestPeriodOrIntervalValue { get; set; }

	[Position(05)]
	public string UnitOfTimePeriodOrIntervalCode { get; set; }

	[Position(06)]
	public string ReferenceIdentification2 { get; set; }

	[Position(07)]
	public string ReferenceIdentification3 { get; set; }

	[Position(08)]
	public string Date3 { get; set; }

	[Position(09)]
	public string ReferenceIdentification4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ANI_AnimalIdentification>(this);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Date2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TestPeriodOrIntervalValue, x=>x.UnitOfTimePeriodOrIntervalCode);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.TestPeriodOrIntervalValue, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrIntervalCode, 2);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.ReferenceIdentification3, 1, 80);
		validator.Length(x => x.Date3, 8);
		validator.Length(x => x.ReferenceIdentification4, 1, 80);
		return validator.Results;
	}
}
