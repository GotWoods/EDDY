using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("FII")]
public class FII_FinancialInstitutionInformation : EdifactSegment
{
	[Position(1)]
	public string PartyQualifier { get; set; }

	[Position(2)]
	public C078_AccountIdentification AccountIdentification { get; set; }

	[Position(3)]
	public C088_InstitutionIdentification InstitutionIdentification { get; set; }

	[Position(4)]
	public string CountryCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FII_FinancialInstitutionInformation>(this);
		validator.Required(x=>x.PartyQualifier);
		validator.Length(x => x.PartyQualifier, 1, 3);
		validator.Length(x => x.CountryCoded, 1, 3);
		return validator.Results;
	}
}
