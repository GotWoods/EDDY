using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C213")]
public class C213_NumberAndTypeOfPackages : EdifactComponent
{
	[Position(1)]
	public string NumberOfPackages { get; set; }

	[Position(2)]
	public string TypeOfPackagesIdentification { get; set; }

	[Position(3)]
	public string CodeListQualifier { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(5)]
	public string TypeOfPackages { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C213_NumberAndTypeOfPackages>(this);
		validator.Length(x => x.NumberOfPackages, 1, 8);
		validator.Length(x => x.TypeOfPackagesIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.TypeOfPackages, 1, 35);
		return validator.Results;
	}
}
