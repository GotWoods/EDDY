using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("ELU")]
public class ELU_DataElementUsageDetails : EdifactSegment
{
	[Position(1)]
	public string DataElementTagIdentifier { get; set; }

	[Position(2)]
	public string RequirementDesignatorCode { get; set; }

	[Position(3)]
	public string SequencePositionIdentifier { get; set; }

	[Position(4)]
	public string MaintenanceOperationCode { get; set; }

	[Position(5)]
	public string OccurrencesMaximumNumber { get; set; }

	[Position(6)]
	public string CodeValueSourceCode { get; set; }

	[Position(7)]
	public string ValidationCriteriaCode { get; set; }

	[Position(8)]
	public string DataElementUsageTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ELU_DataElementUsageDetails>(this);
		validator.Required(x=>x.DataElementTagIdentifier);
		validator.Length(x => x.DataElementTagIdentifier, 1, 4);
		validator.Length(x => x.RequirementDesignatorCode, 1, 3);
		validator.Length(x => x.SequencePositionIdentifier, 1, 10);
		validator.Length(x => x.MaintenanceOperationCode, 1, 3);
		validator.Length(x => x.OccurrencesMaximumNumber, 1, 7);
		validator.Length(x => x.CodeValueSourceCode, 1, 3);
		validator.Length(x => x.ValidationCriteriaCode, 1, 3);
		validator.Length(x => x.DataElementUsageTypeCode, 1, 3);
		return validator.Results;
	}
}
