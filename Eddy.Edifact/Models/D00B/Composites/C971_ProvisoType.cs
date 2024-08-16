using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C971")]
public class C971_ProvisoType : EdifactComponent
{
	[Position(1)]
	public string ProvisoTypeDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ProvisoTypeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C971_ProvisoType>(this);
		validator.Length(x => x.ProvisoTypeDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ProvisoTypeDescription, 1, 35);
		return validator.Results;
	}
}
