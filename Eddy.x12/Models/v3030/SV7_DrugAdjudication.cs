using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("SV7")]
public class SV7_DrugAdjudication : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumber { get; set; }

	[Position(02)]
	public string ReferenceNumber2 { get; set; }

	[Position(03)]
	public string PrescriptionDenialOverrideCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SV7_DrugAdjudication>(this);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.PrescriptionDenialOverrideCode, 2);
		return validator.Results;
	}
}
