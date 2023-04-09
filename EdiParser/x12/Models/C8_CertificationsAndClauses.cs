using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("C8")]
public class C8_CertificationsAndClauses : EdiX12Segment
{
	[Position(01)]
	public int? LadingLineItemNumber { get; set; }

	[Position(02)]
	public string CertificationClauseCode { get; set; }

	[Position(03)]
	public string CertificationClauseText { get; set; }

	[Position(04)]
	public string ShippersExportDeclarationRequirements { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C8_CertificationsAndClauses>(this);
		validator.AtLeastOneIsRequired(x=>x.CertificationClauseText, x=>x.CertificationClauseCode);
		validator.Length(x => x.LadingLineItemNumber, 1, 6);
		validator.Length(x => x.CertificationClauseCode, 2, 4);
		validator.Length(x => x.CertificationClauseText, 2, 60);
		validator.Length(x => x.ShippersExportDeclarationRequirements, 1, 2);
		return validator.Results;
	}
}
