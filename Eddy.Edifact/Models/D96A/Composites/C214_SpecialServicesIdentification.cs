using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C214")]
public class C214_SpecialServicesIdentification : EdifactComponent
{
	[Position(1)]
	public string SpecialServicesCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string SpecialService { get; set; }

	[Position(5)]
	public string SpecialService2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C214_SpecialServicesIdentification>(this);
		validator.Length(x => x.SpecialServicesCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.SpecialService, 1, 35);
		validator.Length(x => x.SpecialService2, 1, 35);
		return validator.Results;
	}
}
