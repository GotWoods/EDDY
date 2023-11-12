using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("SUP")]
public class SUP_SupplementaryInformation : EdiX12Segment
{
	[Position(01)]
	public string SupplementaryInformationQualifier { get; set; }

	[Position(02)]
	public string CertificationClauseCode { get; set; }

	[Position(03)]
	public string FreeFormMessage { get; set; }

	[Position(04)]
	public string PrintOptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SUP_SupplementaryInformation>(this);
		validator.Required(x=>x.SupplementaryInformationQualifier);
		validator.Length(x => x.SupplementaryInformationQualifier, 3);
		validator.Length(x => x.CertificationClauseCode, 2, 4);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		validator.Length(x => x.PrintOptionCode, 2);
		return validator.Results;
	}
}
