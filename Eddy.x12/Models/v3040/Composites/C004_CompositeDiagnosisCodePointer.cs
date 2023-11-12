using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040.Composites;

[Segment("C004")]
public class C004_CompositeDiagnosisCodePointer : EdiX12Component
{
	[Position(00)]
	public int? DiagnosisCodePointer { get; set; }

	[Position(01)]
	public int? DiagnosisCodePointer2 { get; set; }

	[Position(02)]
	public int? DiagnosisCodePointer3 { get; set; }

	[Position(03)]
	public int? DiagnosisCodePointer4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C004_CompositeDiagnosisCodePointer>(this);
		validator.Required(x=>x.DiagnosisCodePointer);
		validator.Length(x => x.DiagnosisCodePointer, 1, 2);
		validator.Length(x => x.DiagnosisCodePointer2, 1, 2);
		validator.Length(x => x.DiagnosisCodePointer3, 1, 2);
		validator.Length(x => x.DiagnosisCodePointer4, 1, 2);
		return validator.Results;
	}
}
