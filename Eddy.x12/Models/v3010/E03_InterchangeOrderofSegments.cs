using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("E03")]
public class E03_InterchangeOrderOfSegments : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public string LevelNumber { get; set; }

	[Position(03)]
	public string SegmentIDCode { get; set; }

	[Position(04)]
	public string EnvelopeIndicator { get; set; }

	[Position(05)]
	public string RequirementDesignator { get; set; }

	[Position(06)]
	public int? MaximumUse { get; set; }

	[Position(07)]
	public int? NoteIdentificationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E03_InterchangeOrderOfSegments>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.LevelNumber);
		validator.Required(x=>x.SegmentIDCode);
		validator.Required(x=>x.EnvelopeIndicator);
		validator.Required(x=>x.RequirementDesignator);
		validator.Required(x=>x.MaximumUse);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.LevelNumber, 1);
		validator.Length(x => x.SegmentIDCode, 2, 3);
		validator.Length(x => x.EnvelopeIndicator, 1);
		validator.Length(x => x.RequirementDesignator, 1);
		validator.Length(x => x.MaximumUse, 1, 7);
		validator.Length(x => x.NoteIdentificationNumber, 1, 6);
		return validator.Results;
	}
}
