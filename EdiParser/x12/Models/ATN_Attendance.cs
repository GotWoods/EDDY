using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("ATN")]
public class ATN_Attendance : EdiX12Segment 
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public string QuantityQualifier { get; set; }

	[Position(04)]
	public string FrequencyCode { get; set; }

	[Position(05)]
	public string AttendanceTypeCode { get; set; }

	[Position(06)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ATN_Attendance>(this);
		validator.Required(x=>x.Quantity);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.AttendanceTypeCode, 1, 4);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
