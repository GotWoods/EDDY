using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("C8C")]
public class C8C_CertificationsClausesContinuation : EdiX12Segment
{
	[Position(01)]
	public string CertificationClauseText { get; set; }

	[Position(02)]
	public string CertificationClauseText2 { get; set; }

	[Position(03)]
	public string CertificationClauseText3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C8C_CertificationsClausesContinuation>(this);
		validator.Required(x=>x.CertificationClauseText);
		validator.Length(x => x.CertificationClauseText, 2, 60);
		validator.Length(x => x.CertificationClauseText2, 2, 60);
		validator.Length(x => x.CertificationClauseText3, 2, 60);
		return validator.Results;
	}
}
