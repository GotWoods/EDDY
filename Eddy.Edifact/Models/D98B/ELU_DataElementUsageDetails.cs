using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Models.D98B;

[Segment("ELU")]
public class ELU_DataElementUsageDetails : EdifactSegment
{
	[Position(1)]
	public string DataElementTag { get; set; }

	[Position(2)]
	public string RequirementDesignatorCoded { get; set; }

	[Position(3)]
	public string SequenceNumber { get; set; }

	[Position(4)]
	public string MaintenanceOperationCoded { get; set; }

	[Position(5)]
	public string MaximumNumberOfOccurrences { get; set; }

	[Position(6)]
	public string CodeValueSourceCoded { get; set; }

	[Position(7)]
	public string ValidationCriteriaCoded { get; set; }

	[Position(8)]
	public string DataElementUsageTypeCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ELU_DataElementUsageDetails>(this);
		validator.Required(x=>x.DataElementTag);
		validator.Length(x => x.DataElementTag, 1, 4);
		validator.Length(x => x.RequirementDesignatorCoded, 1, 3);
		validator.Length(x => x.SequenceNumber, 1, 10);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		validator.Length(x => x.MaximumNumberOfOccurrences, 1, 7);
		validator.Length(x => x.CodeValueSourceCoded, 1, 3);
		validator.Length(x => x.ValidationCriteriaCoded, 1, 3);
		validator.Length(x => x.DataElementUsageTypeCoded, 1, 3);
		return validator.Results;
	}
}
