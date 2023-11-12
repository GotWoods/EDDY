using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("SCH")]
public class SCH_LineItemSchedule : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public string EntityIdentifierCode { get; set; }

	[Position(04)]
	public string Name { get; set; }

	[Position(05)]
	public string DateTimeQualifier { get; set; }

	[Position(06)]
	public string Date { get; set; }

	[Position(07)]
	public string Time { get; set; }

	[Position(08)]
	public string DateTimeQualifier2 { get; set; }

	[Position(09)]
	public string Date2 { get; set; }

	[Position(10)]
	public string Time2 { get; set; }

	[Position(11)]
	public string RequestReferenceNumber { get; set; }

	[Position(12)]
	public string AssignedIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCH_LineItemSchedule>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.ARequiresB(x=>x.EntityIdentifierCode, x=>x.Name);
		validator.Required(x=>x.DateTimeQualifier);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimeQualifier2, x=>x.Date2, x=>x.Time2);
		validator.ARequiresB(x=>x.Date2, x=>x.DateTimeQualifier2);
		validator.ARequiresB(x=>x.Time2, x=>x.DateTimeQualifier2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.EntityIdentifierCode, 2, 3);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.DateTimeQualifier2, 3);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Time2, 4, 8);
		validator.Length(x => x.RequestReferenceNumber, 1, 45);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		return validator.Results;
	}
}
