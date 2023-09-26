using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("INJ")]
public class INJ_InjuryOrIllnessDetail : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string LocationIdentifier { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(05)]
	public string CauseOfInjuryCode { get; set; }

	[Position(06)]
	public string NatureOfInjuryCode { get; set; }

	[Position(07)]
	public string PartOfBodyCode { get; set; }

	[Position(08)]
	public string SourceOfInjuryCode { get; set; }

	[Position(09)]
	public string InitialTreatmentCode { get; set; }

	[Position(10)]
	public string CountyDesignator { get; set; }

	[Position(11)]
	public string PostalCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<INJ_InjuryOrIllnessDetail>(this);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.CauseOfInjuryCode, 2);
		validator.Length(x => x.NatureOfInjuryCode, 2);
		validator.Length(x => x.PartOfBodyCode, 2);
		validator.Length(x => x.SourceOfInjuryCode, 2);
		validator.Length(x => x.InitialTreatmentCode, 2);
		validator.Length(x => x.CountyDesignator, 5);
		validator.Length(x => x.PostalCode, 3, 15);
		return validator.Results;
	}
}
