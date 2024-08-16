using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96B.Composites;

[Segment("C838")]
public class C838_DosageDetails : EdifactComponent
{
	[Position(1)]
	public string DosageIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string Dosage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C838_DosageDetails>(this);
		validator.Length(x => x.DosageIdentification, 1, 8);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.Dosage, 1, 70);
		return validator.Results;
	}
}