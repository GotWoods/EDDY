using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("FST")]
public class FST_ForecastSchedule : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string ForecastQualifier { get; set; }

	[Position(03)]
	public string TimingQualifier { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	[Position(06)]
	public string DateTimeQualifier { get; set; }

	[Position(07)]
	public string Time { get; set; }

	[Position(08)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(09)]
	public string ReferenceIdentification { get; set; }

	[Position(10)]
	public string PlanningScheduleTypeCode { get; set; }

	[Position(11)]
	public string QuantityQualifier { get; set; }

	[Position(12)]
	public string AdjustmentReasonCode { get; set; }

	[Position(13)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FST_ForecastSchedule>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.ForecastQualifier);
		validator.Required(x=>x.TimingQualifier);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimeQualifier, x=>x.Time);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.ARequiresB(x=>x.Description, x=>x.AdjustmentReasonCode);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ForecastQualifier, 1);
		validator.Length(x => x.TimingQualifier, 1);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.PlanningScheduleTypeCode, 2);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.AdjustmentReasonCode, 2);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
