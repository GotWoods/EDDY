using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C332")]
public class C332_SalesChannelIdentification : EdifactComponent
{
	[Position(1)]
	public string SalesChannelIdentifier { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C332_SalesChannelIdentification>(this);
		validator.Required(x=>x.SalesChannelIdentifier);
		validator.Length(x => x.SalesChannelIdentifier, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
