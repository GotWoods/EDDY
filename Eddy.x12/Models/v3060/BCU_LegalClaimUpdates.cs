using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("BCU")]
public class BCU_LegalClaimUpdates : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode4 { get; set; }

	[Position(05)]
	public string ActionCode { get; set; }

	[Position(06)]
	public string ReferenceIdentification { get; set; }

	[Position(07)]
	public string Date { get; set; }

	[Position(08)]
	public int? Century { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BCU_LegalClaimUpdates>(this);
		validator.ARequiresB(x=>x.Century, x=>x.Date);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode4, 1);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Century, 2);
		return validator.Results;
	}
}
