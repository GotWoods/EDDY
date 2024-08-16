using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("DSG")]
public class DSG_DosageAdministration : EdifactSegment
{
	[Position(1)]
	public string DosageAdministrationCodeQualifier { get; set; }

	[Position(2)]
	public C838_DosageDetails DosageDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DSG_DosageAdministration>(this);
		validator.Required(x=>x.DosageAdministrationCodeQualifier);
		validator.Length(x => x.DosageAdministrationCodeQualifier, 1, 3);
		return validator.Results;
	}
}
