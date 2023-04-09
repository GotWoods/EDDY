using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BAX")]
public class BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentId : EdiX12Segment 
{
	[Position(01)]
	public string StandardPointLocationCode { get; set; }

	[Position(02)]
	public string TypeOfConsistCode { get; set; }

	[Position(03)]
	public string DateTimeQualifier { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Time { get; set; }

	[Position(06)]
	public string InterchangeTrainIdentification { get; set; }

	[Position(07)]
	public string StandardPointLocationCode2 { get; set; }

	[Position(08)]
	public string ReferenceIdentification { get; set; }

	[Position(09)]
	public string DirectionIdentifierCode { get; set; }

	[Position(10)]
	public string Date2 { get; set; }

	[Position(11)]
	public string Time2 { get; set; }

	[Position(12)]
	public string TimeCode { get; set; }

	[Position(13)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(14)]
	public string ServiceLevelCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BAX_BeginningSegmentForAdvanceConsistAndTransportationAutomaticEquipmentId>(this);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.TypeOfConsistCode);
		validator.Required(x=>x.DateTimeQualifier);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Time);
		validator.ARequiresB(x=>x.Time2, x=>x.Date2);
		validator.ARequiresB(x=>x.TimeCode, x=>x.Time2);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.TypeOfConsistCode, 1);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.InterchangeTrainIdentification, 1, 10);
		validator.Length(x => x.StandardPointLocationCode2, 6, 9);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.DirectionIdentifierCode, 1);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Time2, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ServiceLevelCode, 2);
		return validator.Results;
	}
}
