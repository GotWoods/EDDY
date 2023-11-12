using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("SV7")]
public class SV7_DrugAdjudication : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string ReferenceIdentification2 { get; set; }

	[Position(03)]
	public string PrescriptionDenialOverrideCode { get; set; }

	[Position(04)]
	public string CoverageLevelCode { get; set; }

	[Position(05)]
	public string ProductProcessCharacteristicCode { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SV7_DrugAdjudication>(this);
		validator.Required(x=>x.CoverageLevelCode);
		validator.Required(x=>x.ProductProcessCharacteristicCode);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.ReferenceIdentification2, 1, 50);
		validator.Length(x => x.PrescriptionDenialOverrideCode, 2);
		validator.Length(x => x.CoverageLevelCode, 3);
		validator.Length(x => x.ProductProcessCharacteristicCode, 2, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
