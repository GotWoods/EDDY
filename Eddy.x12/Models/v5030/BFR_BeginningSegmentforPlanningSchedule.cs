using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("BFR")]
public class BFR_BeginningSegmentForPlanningSchedule : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string ReleaseNumber { get; set; }

	[Position(04)]
	public string ScheduleTypeQualifier { get; set; }

	[Position(05)]
	public string ScheduleQuantityQualifier { get; set; }

	[Position(06)]
	public string Date { get; set; }

	[Position(07)]
	public string Date2 { get; set; }

	[Position(08)]
	public string Date3 { get; set; }

	[Position(09)]
	public string Date4 { get; set; }

	[Position(10)]
	public string ContractNumber { get; set; }

	[Position(11)]
	public string PurchaseOrderNumber { get; set; }

	[Position(12)]
	public string PlanningScheduleTypeCode { get; set; }

	[Position(13)]
	public string ActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BFR_BeginningSegmentForPlanningSchedule>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.AtLeastOneIsRequired(x=>x.ReferenceIdentification, x=>x.ReleaseNumber);
		validator.Required(x=>x.ScheduleTypeQualifier);
		validator.Required(x=>x.ScheduleQuantityQualifier);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Date3);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReleaseNumber, 1, 30);
		validator.Length(x => x.ScheduleTypeQualifier, 2);
		validator.Length(x => x.ScheduleQuantityQualifier, 1);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Date3, 8);
		validator.Length(x => x.Date4, 8);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.PlanningScheduleTypeCode, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}
