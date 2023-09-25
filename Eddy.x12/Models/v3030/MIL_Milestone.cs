using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("MIL")]
public class MIL_Milestone : EdiX12Segment
{
	[Position(01)]
	public string MilestoneNumberIdentification { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public string DateTimeQualifier { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string DateTimeQualifier2 { get; set; }

	[Position(06)]
	public string Date2 { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(08)]
	public decimal? Quantity { get; set; }

	[Position(09)]
	public string WorkStatusCode { get; set; }

	[Position(10)]
	public string ActionCode { get; set; }

	[Position(11)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(12)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MIL_Milestone>(this);
		validator.Required(x=>x.MilestoneNumberIdentification);
		validator.Length(x => x.MilestoneNumberIdentification, 1, 20);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.DateTimeQualifier2, 3);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.WorkStatusCode, 1, 2);
		validator.Length(x => x.ActionCode, 1);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
