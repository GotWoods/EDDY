using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("C8")]
public class C8_CertificationsAndClauses : EdiX12Segment
{
	[Position(01)]
	public int? LadingLineItemNumber { get; set; }

	[Position(02)]
	public string CertificationClauseCode { get; set; }

	[Position(03)]
	public string CertificationClauseText { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C8_CertificationsAndClauses>(this);
		validator.Required(x=>x.LadingLineItemNumber);
		validator.AtLeastOneIsRequired(x=>x.CertificationClauseText, x=>x.CertificationClauseCode);
		validator.Length(x => x.LadingLineItemNumber, 1, 3);
		validator.Length(x => x.CertificationClauseCode, 2, 4);
		validator.Length(x => x.CertificationClauseText, 2, 60);
		return validator.Results;
	}
}
