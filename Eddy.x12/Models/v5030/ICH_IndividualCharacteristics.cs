using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("ICH")]
public class ICH_IndividualCharacteristics : EdiX12Segment
{
	[Position(01)]
	public int? Count { get; set; }

	[Position(02)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(03)]
	public string DateTimePeriod { get; set; }

	[Position(04)]
	public string GenderCode { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public string ReferenceIdentification2 { get; set; }

	[Position(07)]
	public string StateOrProvinceCode { get; set; }

	[Position(08)]
	public string OccupationCode { get; set; }

	[Position(09)]
	public string IndividualRelationshipCode { get; set; }

	[Position(10)]
	public string Description { get; set; }

	[Position(11)]
	public string Description2 { get; set; }

	[Position(12)]
	public string PoliticalPartyAffiliationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ICH_IndividualCharacteristics>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.Count, 1, 9);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.GenderCode, 1);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.OccupationCode, 4, 6);
		validator.Length(x => x.IndividualRelationshipCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.PoliticalPartyAffiliationCode, 2);
		return validator.Results;
	}
}
