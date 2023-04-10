using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("E03")]
public class E03_InterchangeOrderOfSegments : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public string LevelNumberCode { get; set; }

	[Position(03)]
	public string SegmentIDCode { get; set; }

	[Position(04)]
	public string EnvelopeIndicatorCode { get; set; }

	[Position(05)]
	public string RequirementDesignatorCode { get; set; }

	[Position(06)]
	public int? MaximumUse { get; set; }

	[Position(07)]
	public int? NoteIdentificationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E03_InterchangeOrderOfSegments>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.LevelNumberCode);
		validator.Required(x=>x.SegmentIDCode);
		validator.Required(x=>x.EnvelopeIndicatorCode);
		validator.Required(x=>x.RequirementDesignatorCode);
		validator.Required(x=>x.MaximumUse);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.LevelNumberCode, 1);
		validator.Length(x => x.SegmentIDCode, 2, 3);
		validator.Length(x => x.EnvelopeIndicatorCode, 1);
		validator.Length(x => x.RequirementDesignatorCode, 1);
		validator.Length(x => x.MaximumUse, 1, 7);
		validator.Length(x => x.NoteIdentificationNumber, 1, 6);
		return validator.Results;
	}
}
