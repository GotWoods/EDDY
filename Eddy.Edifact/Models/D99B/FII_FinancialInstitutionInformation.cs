using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("FII")]
public class FII_FinancialInstitutionInformation : EdifactSegment
{
	[Position(1)]
	public string PartyFunctionCodeQualifier { get; set; }

	[Position(2)]
	public C078_AccountHolderIdentification AccountHolderIdentification { get; set; }

	[Position(3)]
	public C088_InstitutionIdentification InstitutionIdentification { get; set; }

	[Position(4)]
	public string CountryNameCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FII_FinancialInstitutionInformation>(this);
		validator.Required(x=>x.PartyFunctionCodeQualifier);
		validator.Length(x => x.PartyFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.CountryNameCode, 1, 3);
		return validator.Results;
	}
}
