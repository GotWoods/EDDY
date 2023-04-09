using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BCU_LegalClaimUpdates>(this);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode4, 1);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date, 8);
		return validator.Results;
	}
}
