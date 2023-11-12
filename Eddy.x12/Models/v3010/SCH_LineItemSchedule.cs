using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("SCH")]
public class SCH_LineItemSchedule : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string UnitOfMeasurementCode { get; set; }

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCH_LineItemSchedule>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Required(x=>x.DateTimeQualifier);
		validator.Required(x=>x.Date);
		validator.Length(x => x.Quantity, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.EntityIdentifierCode, 2);
		validator.Length(x => x.Name, 1, 35);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.DateTimeQualifier2, 3);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.Time2, 4);
		return validator.Results;
	}
}
