using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Models.D96B;

[Segment("DSG")]
public class DSG_DosageAdministration : EdifactSegment
{
	[Position(1)]
	public string DosageAdministrationQualifier { get; set; }

	[Position(2)]
	public C838_DosageDetails DosageDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DSG_DosageAdministration>(this);
		validator.Required(x=>x.DosageAdministrationQualifier);
		validator.Length(x => x.DosageAdministrationQualifier, 1, 3);
		return validator.Results;
	}
}
